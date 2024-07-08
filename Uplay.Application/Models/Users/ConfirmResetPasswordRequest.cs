using System.ComponentModel.DataAnnotations;

namespace Uplay.Application.Models.Users;

public class ConfirmResetPasswordRequest
{
    public string Email { get; set; } = string.Empty;
    public string NewPassword { get; set; } = string.Empty;

    [Required(ErrorMessage = "ConfirmPassword must be not empty"), Compare(nameof(NewPassword), ErrorMessage = "Passwords do not match")]
    public string ConfirmPassword { get; set; } = string.Empty;
}