using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Server.IIS;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using Uplay.Application.Exceptions;
using Uplay.Application.Extensions;
using Uplay.Application.Models.Users;
using Uplay.Persistence.Repository;

namespace Uplay.Application.Services.Users
{
    public class UserManager : BaseManager, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IConfiguration _configuration;
        public UserManager(IUserRepository userRepository, IMapper mapper, ICompanyRepository companyRepository, IConfiguration configuration) : base(mapper)
        {
            _userRepository = userRepository;
            _companyRepository = companyRepository;
            _configuration = configuration;
        }

        public async Task<UserLoginResponse> Login(UserLoginRequest request)
        {
            var user = await _userRepository.Login(request.Username);

            if (user is null)
                throw new NotFoundException("Daxil etdiyiniz Username ve ya Email adinda isdifadeci movcud deyil.");

            string passHash = AesOperation.ComputeSha256Hash(user.Email + request.Password + user.Salt.ToString());

            if (user.Password != passHash)
                throw new NotFoundException("Daxil etdiyiniz Username ve ya Email adinda isdifadeci movcud deyil.");

            if (user.EmailConfirmed == false)
                throw new NotFoundException("Zehmet olmasa Email testiq edin.");

            var company = await _companyRepository.GetByUserId(user.Id);

            if (company.Aktiv == false)
                throw new NotFoundException("Qeydiyyat uğurla tamamlanib, biraz gözləyin.");

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

            return new(result);
        }

        public async Task<string> SubscibeConfirm(string token)
        {
            token = token.Decrypte("");

            Match match = Regex.Match(token, @"subscribetoken-(?<id>[a-zA-Z0-9]*)(.*)-(?<timeStampt>\d{14})");

            if (match.Success)
            {
                int companyId = Convert.ToInt32(match.Groups["id"].Value);

                var company = await _companyRepository.SubscibeConfirmByCompanyId(companyId);

                var user = await _userRepository.GetByIdAsync(company.OnwerId);

                user.EmailConfirmed = true;

                await _userRepository.SaveChangesAsync();

                return "Qeydiyyat uğurla tamamlandi";
            }
            else
            {
                return "Nese düz getmədi";
            }
        }
    }
}
