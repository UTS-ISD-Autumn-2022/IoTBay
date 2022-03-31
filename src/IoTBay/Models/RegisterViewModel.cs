using System.ComponentModel.DataAnnotations;

namespace IoTBay.Models;

public class RegisterViewModel
{
    [MaxLength(63)]
	
    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
	
	public string FullName { get; set; } = string.Empty;
	
	public string Email { get; set; } = string.Empty;
	
	public string Address { get; set; } = string.Empty;

}
