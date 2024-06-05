using AutoMapper;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Uplay.Application.Extensions;
using Uplay.Persistence.Repository;

namespace Uplay.Application.Services.Users
{
    public class UserManager : BaseManager, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICompanyRepository _companyRepository;
        public UserManager(IUserRepository userRepository, IMapper mapper, ICompanyRepository companyRepository) : base(mapper)
        {
            _userRepository = userRepository;
            _companyRepository = companyRepository;
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
