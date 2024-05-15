namespace Uplay.Domain.Entities.Models
{
    public class About : CommonEntity
    {
        public ICollection<AboutFile> AboutFiles { get; set; }
        public ICollection<AboutType> AboutTypes{ get; set; }
    }
}
