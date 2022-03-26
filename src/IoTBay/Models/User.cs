using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IoTBay.Models;

using BCrypt.Net;

public record LoginDetails
{
    [MaxLength(31)]
    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}

[Index(nameof(Username), IsUnique = true)]
public abstract class User
{

    public Guid UserId { get; set; }

    [MaxLength(31)]
    public string Username { get; set; }

    private string _password;
    [Column("Password", TypeName = "char(60)")]
    public string Password
    {
        get => _password;
        set => _password = BCrypt.HashPassword(value);
    }

    [MaxLength(31)]
    public string FullName { get; set; }

    [MaxLength(63)]
    public string Email { get; set; }

    public DateTime CreatedAt { get; private set; }

    public User(string username, string password, string fullName, string email)
    {
        UserId = Guid.NewGuid();
        Username = username;
        _password = BCrypt.HashPassword(password);
        FullName = fullName;
        Email = email;
        CreatedAt = DateTime.Now;
    }

    public bool VerifyPassword(string password)
    {
        return BCrypt.Verify(password, _password);
    }
}
