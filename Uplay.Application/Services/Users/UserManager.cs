using System.Diagnostics;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using MimeKit;
using Uplay.Application.Exceptions;
using Uplay.Application.Extensions;
using Uplay.Application.Models.Users;
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

            return new(GenerateToken(user));
        }

        public async Task<UserLoginResponse> BranchLogin(UserLoginRequest request)
        {
            var user = await ValidateUser(request.Username, request.Password);

            var company = await _branchRepository.GetByUserId(user.Id);

            if (company.Status == AccauntStatusEnum.Disabled)
                throw new NotFoundException("Qeydiyyat uğurla tamamlanib, biraz gözləyin.");

            return new(GenerateToken(user));
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
            string token = $"confirmforgotpassword-{emailAddress}-{DateTime.Now:yyyyMMddHHmmss}";

            token = token.Encrypt("");

            string path =
                $"{_contextAccessor.HttpContext?.Request.Scheme}://{_contextAccessor.HttpContext?.Request.Host.Value}/confirmforgotpassword?token={token}";

            var email = new MimeMessage();

            email.From.Add(MailboxAddress.Parse(_configuration["EmailSettings:UserName"]));

            email.To.Add(MailboxAddress.Parse(emailAddress));

            email.Subject = _configuration["EmailSettings:displayName"];

            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            { Text = $"Zehmet olmasa <a href={path}=>Link</a> vasitesile sifreni deyishin" };

            using var smtp = new SmtpClient();
            smtp.Connect(_configuration["EmailSettings:smtpServer"],
                Convert.ToInt32(_configuration["EmailSettings:smtpPort"]), SecureSocketOptions.StartTls);
            smtp.Authenticate(_configuration["EmailSettings:UserName"], _configuration["EmailSettings:password"]);
            smtp.Send(email);
            smtp.Disconnect(true);

            return "Qeydiyyat uğurla tamamlandi";
        }

        public async Task<string> ConfirmResetPassword(string token, ConfirmResetPasswordRequest request)
        {
            token = token.Decrypte("");

            Match match = Regex.Match(token, @"confirmforgotpassword-(?<email>[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,})");

            if (!match.Success) return "Error";

            string email = match.Groups["email"].Value;
            var user = await _userRepository.GetUserByEmail(email);

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

        private string GenerateToken(User user)
        {
            List<Claim> authClaims = new()
            {
                //TODO ELAVE EDERIK NE LAZIM OLSA 
                new("Name", user.Name),
                new("UserName", user.UserName),
                new("Surname", user.Surname),
                new("Phone", user.Phone),
                new("Email", user.Email),
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
    }
}