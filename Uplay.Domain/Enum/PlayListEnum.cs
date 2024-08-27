using System.ComponentModel;

namespace Uplay.Domain.Enum
{
    public enum PlayListEnum
    {
        [Description("Requested")]
        Requested = 1,

        [Description("Approved")]
        Approved = 2,

        [Description("Blocked")]
        Blocked = 3,

        [Description("Delayed")]
        Delayed = 4,
    }
}
