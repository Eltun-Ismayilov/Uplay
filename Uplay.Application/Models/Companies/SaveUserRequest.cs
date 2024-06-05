using AutoMapper;
using System.ComponentModel.DataAnnotations;
using Uplay.Application.Mappings;
using Uplay.Domain.Entities.Models.Users;

namespace Uplay.Application.Models.Companies
{
    public class SaveUserRequest : IMapFrom<User>
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        [Required(ErrorMessage = "ConfirmPassword must be not empty"), Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; } = string.Empty;
        public void Mapping(Profile profile)
        {
            profile.CreateMap<SaveUserRequest, User>();
        }
    }
}
