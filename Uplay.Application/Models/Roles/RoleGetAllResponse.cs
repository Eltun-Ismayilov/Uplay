using System.Text.Json.Serialization;

namespace Uplay.Application.Models.Roles
{
    public class RoleGetAllResponse
    {
        [JsonPropertyName("roles")]
        public List<RoleDto> RoleDtos { get; set; } = new List<RoleDto>();
    }
}
