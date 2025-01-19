using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uplay.Domain.Entities.Models.Companies;

namespace Uplay.Application.Models.Admins
{
    public class UserCompanyDto
    {
        public string BrandName { get; set; }
        public string CompanyName { get; set; }
        public string? Tin { get; set; }
        public int BranchCount { get; set; }
        public string City { get; set; }
        public string Location { get; set; }

        public List<CompanyBranchData> Branches { get; set; } = null!;
    }

    public class CompanyBranchData
    {
        public string BrachName { get; set; }
        public int OwnerId { get; set; }
        public int UserType { get; set; }
        public string City { get; set; }
    }
}
