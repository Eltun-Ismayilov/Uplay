using Uplay.Application.Models;
using Uplay.Domain.Entities.Models.Companies;
using Uplay.Domain.Entities.Models.Miscs;
using Uplay.Domain.Enums;

namespace Uplay.Domain.Entities.Models.PlayLists
{
    public class PlayList:CommonEntity, IFilterable
    {
        public string Title { get; set; }
        public string YoutubeId { get; set; }
        public int FileId { get; set; }
        public AppFile File { get; set; }
        public string Duration { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        
        public PlayListEnum Status { get; set; }
        public virtual ICollection<PlayListStatusHistory> PlayListStatusHistories { get; set; }
    }
}
