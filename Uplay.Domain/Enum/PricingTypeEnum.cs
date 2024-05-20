using System.ComponentModel;

namespace Uplay.Domain.Enum
{
    public enum PricingTypeEnum : byte
    {

        [Description("Standart")]
        Standart = 1,

        [Description("Vip")]
        Vip = 2,
    }
}
