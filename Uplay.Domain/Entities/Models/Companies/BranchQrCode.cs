using Uplay.Domain.Entities.Models.Miscs;

namespace Uplay.Domain.Entities.Models.Companies
{
    public class BranchQrCode: CommonEntity
    {
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public int AppFileId { get; set; }
        public AppFile AppFile { get; set; }
    }
}
