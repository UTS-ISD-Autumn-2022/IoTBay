using System.ComponentModel.DataAnnotations;

namespace IoTBay.Models;

public class LoginViewModel
{
    [MaxLength(63)]
    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    [Display(Name = "Remember Me?")]
    public bool RememberMe { get; set; } = false;
}
