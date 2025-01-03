namespace Uplay.Domain.Entities.Models.Users
{
    public class UserRole: CommonEntity
    {

        public int RoleId { get; set; }
        public Role Role { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
