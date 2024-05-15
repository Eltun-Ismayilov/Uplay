using Uplay.Domain.Entities.Models.Miscs;

namespace Uplay.Domain.Entities.Models.Landing
{
    public class Partner : CommonEntity
    {
        public string Name { get; set; }
        public int FileId { get; set; }
        public AppFile File { get; set; }
    }
}
