namespace Uplay.Domain.Entities.Models
{
    public class About : CommonEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<AboutFile> AboutFiles { get; set; }
    }
}
