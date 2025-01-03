namespace Uplay.Domain.Entities.Models.Users
{
    public class RoleClaim: CommonEntity
    {
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public int ClaimId { get; set; }
        public Claim Claim { get; set; }
    }
}
