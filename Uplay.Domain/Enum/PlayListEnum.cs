using System.ComponentModel;

namespace Uplay.Domain.Enum
{
    public enum PlayListEnum
    {
        [Description("Requested")]
        Requested = 1,

        [Description("Played")]
        Played = 2,

        [Description("Blocked")]
        Blocked = 3,

        [Description("Pending")]
        Pending = 4,

        [Description("Playing")]
        Playing = 5,

        [Description("Delayed")]
        Delayed = 6,
    }
}
