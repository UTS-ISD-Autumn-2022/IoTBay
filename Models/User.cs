using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IoTBay.Models
{
    using BCrypt.Net;

    public abstract class User
    {

        public Guid Id { get; set; }

        [MaxLength(31)]
        public string Username { get; set; }

        [Column("Password", TypeName = "char(60)")]
        private string _password;
        public string Password
        {
            private get => _password;
            set => _password = BCrypt.HashPassword(value);
        }

        [MaxLength(31)]
        public string FullName { get; set; }

        [MaxLength(63)]
        public string Email { get; set; }

        public DateTime CreatedAt { get; private set; }

        public User(string username, string password, string fullName, string email)
        {
            Username = username;
            _password = BCrypt.HashPassword(password);
            FullName = fullName;
            Email = email;
            CreatedAt = DateTime.Now;
        }

        public bool VerifyPassword(string password)
        {
            return BCrypt.Verify(password, Password);
        }
    }
}

