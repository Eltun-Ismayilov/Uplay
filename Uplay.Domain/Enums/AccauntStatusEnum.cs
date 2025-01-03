using System.ComponentModel;

namespace Uplay.Domain.Enums
{
    public enum AccauntStatusEnum
    {
        [Description("Active")]
        Active = 1,

        [Description("Deleted")]
        Deleted = 2,

        [Description("Disabled")]
        Disabled = 3,
    }
}
