using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Uplay.Application.Models.Admins
{
    public class GetUserDetail
    {
        [JsonPropertyName("data")]
        public UserDetailDto Data { get; set; } = new UserDetailDto();
    }
}
