using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uplay.Application.Exceptions;
using Uplay.Application.Extensions;
using Uplay.Application.Mappings;
using Uplay.Application.Models;
using Uplay.Application.Models.Admins;
using Uplay.Application.Models.Users;
using Uplay.Application.Services.Users;
using Uplay.Domain.Entities.Models.Users;
using Uplay.Domain.Enums;
using Uplay.Domain.Enums.User;
using Uplay.Domain.Extension;
using Uplay.Persistence.Repository;

namespace Uplay.Application.Services.Admins
{
    internal class AdminManager : BaseManager, IAdminService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRepository<RoleClaim> _roleClaimRepository;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IConfiguration _configuration;

        public AdminManager(
            IUserRepository userRepository,
            IMapper mapper,
            IConfiguration configuration,
            IHttpContextAccessor contextAccessor,
            IRepository<RoleClaim> roleClaimRepository) : base(mapper)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _contextAccessor = contextAccessor;
            _roleClaimRepository = roleClaimRepository;
        }

        public bool CheckIfRoleHasClaim(int roleId, int claimId)
        {
            return _roleClaimRepository.GetQuery().Any(x => x.RoleId == roleId && x.ClaimId == claimId);
        }


        public async Task<UserLoginResponse> Login(UserLoginRequest request)
        {
            var user = await ValidateUser(request.Username, request.Password);

            return new(GenerateToken(user));
        }

        public async Task<GetAllUsersResponse> GetAllUsers(PaginationFilter paging)
        {
            var response = new GetAllUsersResponse();

            var users = _userRepository.GetAllQuery().AsNoTracking();

            response.UserDtos = await users.PaginatedMappedListAsync<Models.Admins.UserDto, User>(Mapper, paging.PageNumber, paging.PageSize);
            return response;
        }

        public async Task AddUser(CreateUserDto request)
        {
            if (request.RoleId == RoleEnum.SuperAdmin.ToInt())
                throw new BadHttpRequestException("Bu rolda istifadechi yarada bilmersiniz.");

            var userExist = await _userRepository.CheckUser(x => x.UserName == request.Username);

            if (userExist is not null)
                throw new BadHttpRequestException("Daxil etdiyiniz Username ve ya Email ile bagli isdifadeci movcudur.");

            var user = new User
            {
                Salt = Guid.NewGuid(),
                Name = "",
                Surname = "",
                Email = request.Email,
                Phone = "",
                EmailConfirmed = true,
                UserName = request.Username,
                UserType = UserTypeEnum.Administrative,
                UserRoles = new List<UserRole>()
                {
                    new(){RoleId = request.RoleId}
                }
            };

            string passHash =
                AesOperation.ComputeSha256Hash(request.Password + user.Salt);

            user.Password = passHash;
            await _userRepository.InsertAsync(user);
        }

        public async Task<int> Update(int userId, CreateUserDto request)
        {
            if (request.RoleId == RoleEnum.SuperAdmin.ToInt())
                throw new BadHttpRequestException("Bu rolda istifadechi Update ede bilmersiniz.");

            var userExist = await _userRepository.CheckUser(x => x.UserName == request.Username);

            if (userExist is not null)
                throw new BadHttpRequestException("Daxil etdiyiniz Username ve ya Email ile bagli isdifadeci movcudur.");

            var user = _userRepository.GetAllQuery()
                                      .Include(x => x.UserRoles)
                                      .FirstOrDefault(x => x.Id == userId);

            if (user is null)
                throw new BadHttpRequestException($"Bu {userId}-Idli istifadechi movcud deyil.");

            user.Salt = Guid.NewGuid();
            user.Email = request.Email;
            user.UserName = request.Username;
            user.UserRoles = new List<UserRole>() { new UserRole { RoleId = request.RoleId } };

            string passHash = AesOperation.ComputeSha256Hash(request.Password + user.Salt);

            user.Password = passHash;

            await _userRepository.UpdateAsync(user);

            return 200;
        }

        private async Task<User> ValidateUser(string username, string password)
        {
            var user = await _userRepository.Login(username);

            if (user is null)
                throw new NotFoundException("Daxil etdiyiniz Username ve ya Email adinda isdifadeci movcud deyil.");

            string passHash = AesOperation.ComputeSha256Hash(password + user.Salt.ToString());

            if (user.Password != passHash)
                throw new NotFoundException("Daxil etdiyiniz Username ve ya Email adinda isdifadeci movcud deyil.");

            return user;
        }

        private string GenerateToken(User user)
        {
            List<System.Security.Claims.Claim> authClaims = new()
            {
                //TODO ELAVE EDERIK NE LAZIM OLSA 
                new("Name", user.Name),
                new("UserName", user.UserName),
                new("Surname", user.Surname),
                new("Phone", user.Phone),
                new("Email", user.Email),
                new("Role", $"{user.UserRoles.FirstOrDefault().Role.Id}"),
                new("Claims", string.Join(",", user.UserRoles.FirstOrDefault()?.Role.RoleClaims.Select(c => c.Claim.Name))),

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

        public async Task<GetUserDetail> GetUserDetail(int id,int userTypeId)
        {
            var user = await _userRepository.GetTable()
                                      .Include(x => x.Companies)
                                      .ThenInclude(x => x.CompanyBranchs)
                                      .ThenInclude(x => x.Branch)
                                      .ThenInclude(x => x.Onwer)
                                      .FirstOrDefaultAsync(x => x.Id == id) 
                                      ?? throw new NotFoundException("User not found");

            return UserDetailMapper.MapUserDetail(user, userTypeId);
        }
    }
}
