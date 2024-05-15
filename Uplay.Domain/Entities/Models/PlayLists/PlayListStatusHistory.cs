using Uplay.Domain.Enum;

namespace Uplay.Domain.Entities.Models.PlayLists
{
    public class PlayListStatusHistory:CommonEntity
    {
        public int PlayListId { get; set; }
        public PlayList PlayList { get; set; }
        public PlayListEnum StatusId { get; set; }
    }
}


