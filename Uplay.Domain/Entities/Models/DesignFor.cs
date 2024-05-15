namespace Uplay.Domain.Entities.Models
{
    public class DesignFor:CommonEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int FileId { get; set; }
        public AppFile File { get; set; }
        public int DesignForTypeId { get; set; }
        public DesignForType DesignForType { get; set; }
    }
}
    