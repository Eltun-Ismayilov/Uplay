namespace Uplay.Domain.Entities.Models
{
    public class RegistrationFile
    {
        public int FileId { get; set; }
        public AppFile File { get; set; }
        public int RegistrationId { get; set; }
        public Registration Registration { get; set; }
    }
}
