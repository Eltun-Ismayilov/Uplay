using System.ComponentModel.DataAnnotations;

namespace Uplay.Application.Models.Users;

public class ResetPasswordRequest
{
    public string CurrentPassword { get; set; }
    public string NewPassword { get; set; }
    
    [Required(ErrorMessage = "ConfirmPassword must be not empty"), Compare(nameof(NewPassword), ErrorMessage = "Passwords do not match")]
    public string ConfirmPassword { get; set; }
}