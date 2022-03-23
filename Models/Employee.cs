using System.ComponentModel.DataAnnotations;

namespace IoTBay.Models;
public class Employee : User
{
    [MaxLength(63)]
    public string Department { get; set; }

    [MaxLength(31)]
    public string Role { get; set; }

    public Employee(string username, string password, string fullName, string email, string department, string role) : base(username, password, fullName, email)
    {
        Department = department;
        Role = role;
    }
}
