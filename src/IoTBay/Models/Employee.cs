using System.ComponentModel.DataAnnotations;

namespace IoTBay.Models;

public class Employee
{
    public Guid Id { get; set; }
    
    public string LoginCredentialsId { get; set; } = string.Empty;

    [MaxLength(255)]
    public string Department { get; set; } = string.Empty;

    [MaxLength(31)]
    public string Position { get; set; } = string.Empty;
}
