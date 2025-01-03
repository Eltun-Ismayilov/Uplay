using System.ComponentModel;

namespace Uplay.Domain.Enums.User
{
    public enum RoleEnum : byte
    {
        [Description("SuperAdmin")]
        SuperAdmin = 1,

        [Description("Admin")]
        Admin = 2,

        [Description("Operator")]
        Operator = 3,

        [Description("Company")]
        Company = 4,

        [Description("Branch")]
        Branch = 5,
    }
}
