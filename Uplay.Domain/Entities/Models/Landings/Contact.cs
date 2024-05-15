namespace Uplay.Domain.Entities.Models.Landing
{
    public class Contact : CommonEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public bool IsARead { get; set; } = false;
    }
}
