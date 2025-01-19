using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Uplay.Application.Models.Admins
{
    public class UserDetailDto
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        [JsonPropertyName("branchData")]
        public UserBranchDto BranchData { get; set; }

        [JsonPropertyName("companyData")]
        public UserCompanyDto CompanyData { get; set; }
    }
}
