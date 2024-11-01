using System.Diagnostics;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using MimeKit;
using Uplay.Application.Exceptions;
using Uplay.Application.Extensions;
using Uplay.Application.Models.Users;
using Uplay.Domain.Entities.Models.Companies;
using Uplay.Domain.Entities.Models.Users;
using Uplay.Domain.Enum;
using Uplay.Persistence.Repository;

namespace Uplay.Application.Services.Users
{
    public class UserManager : BaseManager, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IBranchRepository _branchRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IConfiguration _configuration;

        public UserManager(IUserRepository userRepository, IMapper mapper, ICompanyRepository companyRepository,
            IConfiguration configuration, IBranchRepository branchRepository,
            IHttpContextAccessor contextAccessor) : base(mapper)
        {
            _userRepository = userRepository;
            _companyRepository = companyRepository;
            _configuration = configuration;
            _branchRepository = branchRepository;
            _contextAccessor = contextAccessor;
        }

        public string Username
        {
            get => ParseJwt(_contextAccessor);
            set { throw new NotImplementedException(); }
        }

        public async Task<UserLoginResponse> Login(UserLoginRequest request)
        {
            var user = await ValidateUser(request.Username, request.Password);
            var company = await _companyRepository.GetByUserId(user.Id);

            if (company.Aktiv == false)
                throw new NotFoundException("Qeydiyyat uğurla tamamlanib, biraz gözləyin.");

            return new(GenerateToken(user, company.Id));
        }

        public async Task<UserLoginResponse> BranchLogin(UserLoginRequest request)
        {
            var user = await ValidateUser(request.Username, request.Password);

            var branch = await _branchRepository.GetByUserId(user.Id);

            if (branch.Status == AccauntStatusEnum.Disabled)
                throw new NotFoundException("Qeydiyyat uğurla tamamlanib, biraz gözləyin.");

            return new(GenerateToken(user, branch.Id));
        }

        public async Task<string> SubscibeConfirm(int otpCode)
        {
            var user = await _userRepository.CheckOtpCode(otpCode);

            if (user is null)
                return "OTP codu yanlisdir.";

            user.EmailConfirmed = true;

            await _userRepository.SaveChangesAsync();

            return "Qeydiyyat uğurla tamamlandi";
        }

        public async Task<string> ResetPassword(ResetPasswordRequest request)
        {
            var user = await ValidateUser(Username, request.CurrentPassword);

            user.Salt = Guid.NewGuid();
            string passHash = AesOperation.ComputeSha256Hash(user.Email + request.NewPassword + user.Salt);
            user.Password = passHash;

            var a = await _userRepository.SaveChangesAsync();

            return "Qeydiyyat uğurla tamamlandi";
        }

        public async Task<string> SendForgotPasswordEmail(string emailAddress)
        {
            var user = await _userRepository.GetUserByEmail(emailAddress);

            if (user is null)
                throw new NotFoundException($"Daxil Etdiyiniz {emailAddress} yoxdur");

            var randomValue = GenerateRandomSixDigitNumber();

            user.OtpCode = randomValue;

            await _userRepository.SaveChangesAsync();

            var email = new MimeMessage();

            email.From.Add(MailboxAddress.Parse(_configuration["EmailSettings:UserName"]));

            email.To.Add(MailboxAddress.Parse(emailAddress));

            email.Subject = _configuration["EmailSettings:displayName"];

            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = $"Zehmet olmasa {randomValue} OTP codu ile girisivizi testiqleyin" };

            using var smtp = new SmtpClient();
            smtp.Connect(_configuration["EmailSettings:smtpServer"],
                Convert.ToInt32(_configuration["EmailSettings:smtpPort"]), SecureSocketOptions.StartTls);
            smtp.Authenticate(_configuration["EmailSettings:UserName"], _configuration["EmailSettings:password"]);
            smtp.Send(email);
            smtp.Disconnect(true);

            return "Qeydiyyat uğurla tamamlandi";
        }
        public static int GenerateRandomSixDigitNumber()
        {
            Random random = new Random();

            return random.Next(100000, 999999 + 1);
        }
        public async Task<string> ConfirmResetPassword(ConfirmResetPasswordRequest request)
        {
            var user = await _userRepository.GetUserByEmail(request.Email);

            user.Salt = Guid.NewGuid();
            string passHash = AesOperation.ComputeSha256Hash(user.Email + request.NewPassword + user.Salt);
            user.Password = passHash;

            await _userRepository.SaveChangesAsync();

            return "Qeydiyyat uğurla tamamlandi";
        }

        private async Task<User> ValidateUser(string username, string password)
        {
            var user = await _userRepository.Login(username);

            if (user is null)
                throw new NotFoundException("Daxil etdiyiniz Username ve ya Email adinda isdifadeci movcud deyil.");

            string passHash = AesOperation.ComputeSha256Hash(user.Email + password + user.Salt.ToString());

            if (user.Password != passHash)
                throw new NotFoundException("Daxil etdiyiniz Username ve ya Email adinda isdifadeci movcud deyil.");

            if (user.EmailConfirmed == false)
                throw new NotFoundException("Zehmet olmasa Email testiq edin.");

            return user;
        }

        private string GenerateToken(User user, int id)
        {
            List<Claim> authClaims = new()
            {
                //TODO ELAVE EDERIK NE LAZIM OLSA 
                new("Name", user.Name),
                new("UserName", user.UserName),
                new("Surname", user.Surname),
                new("Phone", user.Phone),
                new("Email", user.Email),
                new("DashId", $"{id}"),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            SymmetricSecurityKey authSigningKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.UtcNow.ToLocalTime().AddDays(1), //OZUM 1 GUN QOYDUM ISDESEN CHAN EDERIK
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256Signature)
            );

            var result = new JwtSecurityTokenHandler().WriteToken(token);

            return result;
        }

        private string ParseJwt(IHttpContextAccessor _contextAccessor)
        {
            Debug.Assert(_contextAccessor.HttpContext != null, "_contextAccessor.HttpContext != null");
            var jwtToken = _contextAccessor.HttpContext.Request.Headers.Authorization.ToString().Split(" ")[1];
            var tokenHandler = new JwtSecurityTokenHandler();

            SecurityToken validatedToken;

            try
            {
                // No validation is performed here, adjust based on your needs
                validatedToken = tokenHandler.ReadToken(jwtToken);
            }
            catch (ArgumentException ex)
            {
                // Handle invalid token exception
                Console.WriteLine("Invalid JWT token format");
                return "";
            }

            var jwtSecurityToken = (JwtSecurityToken)validatedToken;

            return jwtSecurityToken.Payload.Claims.FirstOrDefault(x => x.Type == "UserName")?.ToString()
                       .Split(" ")[1] ??
                   string.Empty;
        }

        public async Task<string> SendOtpAsync(string emailAddress)
        {
            var user = await _userRepository.GetUserByEmail(emailAddress);

            if (user is null)
                throw new NotFoundException($"Daxil Etdiyiniz {emailAddress} yoxdur");

            var randomValue = GenerateRandomSixDigitNumber();

            user.OtpCode = randomValue;

            await _userRepository.SaveChangesAsync();

            var email = new MimeMessage();

            email.From.Add(MailboxAddress.Parse(_configuration["EmailSettings:UserName"]));

            email.To.Add(MailboxAddress.Parse(emailAddress));

            email.Subject = _configuration["EmailSettings:displayName"];

            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = $"Zehmet olmasa {randomValue} OTP codu ile girisivizi testiqleyin" };

            using var smtp = new SmtpClient();
            smtp.Connect(_configuration["EmailSettings:smtpServer"],
                Convert.ToInt32(_configuration["EmailSettings:smtpPort"]), SecureSocketOptions.StartTls);
            smtp.Authenticate(_configuration["EmailSettings:UserName"], _configuration["EmailSettings:password"]);
            smtp.Send(email);
            smtp.Disconnect(true);

            return "Qeydiyyat uğurla tamamlandi";
        }
        
        public async Task DeleteBranchAccount(int branchId)
        {
            var user = await ValidateBranch(branchId);
            var branch = user.Branches.FirstOrDefault(x=>x.Id == branchId);
            if (branch is null)
                throw new BadHttpRequestException("Cannot delete account");
            
            branch.Deleted = true;
            user.Branches = new List<Branch>() { branch };
            
            await _userRepository.DeleteAsync(user);
        }

        public async Task DeleteCorporateAccount(int companyId)
        {
            var user = await ValidateCompany(companyId);
            var company = user.Companies.FirstOrDefault(x=>x.Id == companyId);
            if (company is null)
                throw new BadHttpRequestException("Cannot delete account");
            
            company.Deleted = true;
            user.Companies = new List<Company>() { company };
            
            await _userRepository.DeleteAsync(user);
        }

        public async Task<UserDto> GetBranchAccountInfo(int branchId)
        {
            var user = await ValidateBranch(branchId);
            var branch = user.Branches.FirstOrDefault(x=>x.Id == branchId);
            if (branch is null)
                throw new BadHttpRequestException("Cannot get account");
            
            var company = user.Companies.FirstOrDefault();
            if (company is null)
                throw new BadHttpRequestException("Cannot get account");
            
            var mappedAccountInfo = Mapper.Map<UserDto>(user);
            mappedAccountInfo.BrandName = company.BrandName;
            return mappedAccountInfo;
        }
        
        public async Task<CompanyAccountInfoDto> GetCompanyAccountInfo(int companyId)
        {
            var user = await ValidateCompany(companyId);
            var company = user.Companies.FirstOrDefault(x=>x.Id == companyId);
            if (company is null)
                throw new BadHttpRequestException("Cannot get account");
            
            var mappedAccountInfo = Mapper.Map<CompanyAccountInfoDto>(user);
            return mappedAccountInfo;
        }

        public async Task UpdateBranchAccountInfo(int branchId, BranchAccountRequest request)
        {
            var user = await ValidateBranch(branchId);
            var branch = user.Branches.FirstOrDefault(x=>x.Id == branchId);
            if (branch is null)
                throw new BadHttpRequestException("Cannot update account");

            user.Name = request.Name;
            user.Surname = request.Surname;
            user.Phone = request.Phone;
            branch.City = request.City;
            branch.Location = request.Location;
            user.Branches = new List<Branch>() { branch };

            await  _userRepository.UpdateAsync(user);
        }
        
        public async Task UpdateCompanyAccountInfo(int companyId, BranchAccountRequest request)
        {
            var user = await ValidateCompany(companyId);
            var company = user.Companies.FirstOrDefault(x=>x.Id == companyId);
            if (company is null)
                throw new BadHttpRequestException("Cannot update account");

            user.Name = request.Name;
            user.Surname = request.Surname;
            user.Phone = request.Phone;
            company.City = request.City;
            company.Location = request.Location;
            user.Companies = new List<Company>() { company };

            await  _userRepository.UpdateAsync(user);
        }

        private async Task<User> ValidateBranch(int branchId)
        {
            var user = await _userRepository.GetUserByUsernameWithBranch(Username);
            if (user is null) throw new BadHttpRequestException("User not found");
            if (user.Branches is null || user.Branches.Count == 0) 
                throw new BadHttpRequestException("Branches not found");

            return user;
        }
        
        private async Task<User> ValidateCompany(int branchId)
        {
            var user = await _userRepository.GetUserByUsername(Username);
            if (user is null) throw new BadHttpRequestException("User not found");
            if (user.Companies is null || user.Companies.Count == 0) 
                throw new BadHttpRequestException("Branches not found");

            return user;
        }
    }
}