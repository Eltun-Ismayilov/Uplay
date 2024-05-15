namespace Uplay.Domain.Entities.Models.Users
{
    /// <summary>
    /// UserName -Branch eger var onun name olacaq sisteme giris ucun
    /// Email-Corpatativ ve sexsi giris ucun olacaq
    /// Name-User name
    /// </summary>
    public class User
    {
        public string Name { get; set; } 
        public string UserName { get; set; } 
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }  
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
    }
}
