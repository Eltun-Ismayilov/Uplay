namespace Uplay.Domain.Entities.Models
{
    public class Registration:CommonEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<RegistrationFile> RegistrationFiles { get; set; }
    }
}
