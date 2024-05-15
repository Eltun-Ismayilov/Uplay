using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uplay.Domain.Entities.Models
{
    public class Category
    {
        public string Name { get; set; }
        public int FileId { get; set; }
        public AppFile File { get; set; }
    }
}
