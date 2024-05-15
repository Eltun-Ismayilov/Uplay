using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uplay.Domain.Entities.Models.Companies;
using Uplay.Domain.Entities.Models.Miscs;

namespace Uplay.Domain.Entities.Models.PlayLists
{
    public class PlayList:CommonEntity
    {
        public string Title { get; set; }
        public int FileId { get; set; }
        public AppFile File { get; set; }
        public string Duration { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public virtual ICollection<PlayListStatusHistory> PlayListStatusHistories { get; set; }
    }
}
