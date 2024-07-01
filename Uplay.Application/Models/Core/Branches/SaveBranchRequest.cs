using AutoMapper;
using System.ComponentModel.DataAnnotations;
using Uplay.Application.Mappings;
using Uplay.Domain.Entities.Models.Companies;

namespace Uplay.Application.Models.Core.Branches;

public class SaveBranchRequest: IMapFrom<Branch>
{
    public string Name { get; set; }
    public string City { get; set; }
    public string Location { get; set; }
    public string Username { get; set; }
    public string Password { get; set; } = string.Empty;
    [Required(ErrorMessage = "ConfirmPassword must be not empty"), Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
    public string ConfirmPassword { get; set; } = string.Empty;
    
    public List<int> CategoryIds { get; set; } = null!;
    public void Mapping(Profile profile)
    {
        profile.CreateMap<SaveBranchRequest, Branch>();
    }
}