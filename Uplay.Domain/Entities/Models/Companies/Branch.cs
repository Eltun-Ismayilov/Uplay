using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uplay.Domain.Entities.Models.PlayLists;
using Uplay.Domain.Entities.Models.Users;

namespace Uplay.Domain.Entities.Models.Companies
{
    public class Branch
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
        public int OnwerId { get; set; }
        public User Onwer { get; set; }
        public virtual ICollection<PlayList> PlayLists { get; set; }
    }
}
