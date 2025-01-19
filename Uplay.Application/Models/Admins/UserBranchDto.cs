using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uplay.Domain.Entities.Models.Companies;

namespace Uplay.Application.Models.Admins
{
    public class UserBranchDto
    {
        //Brach 
        public string BrachName { get; set; }
        public string? Tin { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
    }
}
