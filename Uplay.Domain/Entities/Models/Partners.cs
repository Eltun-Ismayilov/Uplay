namespace Uplay.Domain.Entities.Models
{
    public class Partners:CommonEntity
    {
        public string Name { get; set; }
        public int FileId { get; set; }
        public AppFile File { get; set; }
    }
}
