using System.ComponentModel;

namespace Uplay.Domain.Enums
{
    public enum FileTypeEnum : byte
    {
        [Description("application/pdf")]
        Pdf = 1,

        [Description("image/png")]
        Png = 2,

        [Description("image/jpeg")]
        Jpeg = 3,
        [Description("application/zip")]
        Zip = 4,

    }
}
