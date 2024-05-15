namespace Uplay.Domain.Entities.Models.Landing
{
    public class About : CommonEntity
    {
        public ICollection<AboutFile> AboutFiles { get; set; }
        public ICollection<AboutType> AboutTypes { get; set; }
    }
}
