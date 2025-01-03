using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Uplay.Application.Mappings;
using Uplay.Application.Models.Faqs;
using Uplay.Domain.Entities.Models.Landing;
using Uplay.Domain.Entities.Models.Users;

namespace Uplay.Application.Models.Admins
{
    public class GetAllUsersResponse
    {
        [JsonPropertyName("users")] public PaginatedMappedList<UserDto, User> UserDtos { get; set; }
    }
    
    public class UserDto : BaseDto, IMapFrom<User>
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("surname")]
        public string Surname { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}
