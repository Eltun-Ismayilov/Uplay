namespace Uplay.Domain.Entities.Models
{
    public class Service:CommonEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int FileId { get; set; }
        public AppFile File { get; set; }
        public int ServiceTypeId { get; set; }
        public ServiceType ServiceType { get; set; }
    }
}
    