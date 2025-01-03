using System.Reflection.Metadata.Ecma335;
using Uplay.Domain.Entities.Models.Companies;
using Uplay.Domain.Entities.Models.Pricings;

namespace Uplay.Domain.Entities.Models.Users
{
    /// <summary>
    /// UserName -Branch eger var onun name olacaq sisteme giris ucun
    /// Email-Corpatativ ve sexsi giris ucun olacaq
    /// Name-User name
    /// </summary>
    public class User:CommonEntity
    {
        public string Name { get; set; } 
        public string UserName { get; set; } 
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid Salt { get; set; }
        public bool EmailConfirmed { get; set; }
        public int OtpCode { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<Branch> Branches { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
