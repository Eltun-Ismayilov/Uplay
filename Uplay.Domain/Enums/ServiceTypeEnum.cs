using System.ComponentModel;

namespace Uplay.Domain.Enums
{
    public enum ServiceTypeEnum : byte
    {

        [Description("Partners")]
        Partners = 1,

        [Description("Clients")]
        Clients = 2,
    }
}
