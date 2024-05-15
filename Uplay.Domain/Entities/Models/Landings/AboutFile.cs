using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uplay.Domain.Entities.Models.Miscs;

namespace Uplay.Domain.Entities.Models.Landing
{
    public class AboutFile : CommonEntity
    {
        public int FileId { get; set; }
        public AppFile File { get; set; }
        public int AboutId { get; set; }
        public About About { get; set; }
    }
}
