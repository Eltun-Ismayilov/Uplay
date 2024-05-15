namespace Uplay.Domain.Entities.Models
{
    public class PublicReview
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int FileId { get; set; }
        public AppFile File { get; set; }
    }
}
