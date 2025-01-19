using Uplay.Application.Models.Admins;
using Uplay.Domain.Entities.Models.Users;
using Uplay.Domain.Enums.User;
using Uplay.Domain.Extension;

namespace Uplay.Application.Mappings
{
    public static class UserDetailMapper
    {
        public static GetUserDetail MapUserDetail(User user, int userTypeId)
        {
            var response = new GetUserDetail();

            response.Data.UserName = user.UserName;
            response.Data.Name = user.Name;
            response.Data.Surname = user.Surname;
            response.Data.Email = user.Email;
            response.Data.Phone = user.Phone;

            if (userTypeId == UserTypeEnum.Corporative.ToInt())
            {
                var companyDto = new UserCompanyDto();
                var company = user.Companies.FirstOrDefault();
                companyDto.BrandName = company.BrandName;
                companyDto.CompanyName = company.CompanyName;
                companyDto.Tin = company.Tin;
                companyDto.BranchCount = company.BranchCount;
                companyDto.City = company.City;
                companyDto.Location = company.Location;
                response.Data.CompanyData = companyDto;

                var branches = new List<CompanyBranchData>();

                foreach (var branch in company.CompanyBranchs.Select(x => x.Branch))
                {
                    branches.Add(new CompanyBranchData()
                    {
                        BrachName = branch.Name,
                        City = branch.City,
                        OwnerId = branch.OnwerId,
                        UserType = branch.Onwer.UserType.ToInt(),
                    });
                }

                response.Data.CompanyData.Branches = branches;
            }
            else
            {
                var branchDto = new UserBranchDto();
                var branch = user.Branches.FirstOrDefault();
                branchDto.BrachName = branch.Name;
                branchDto.Tin = branch.Tin;
                branchDto.City = branch.City;
                branchDto.Location = branch.Location;
                response.Data.BranchData = branchDto;
            }

            return response;
        }
    }
}
