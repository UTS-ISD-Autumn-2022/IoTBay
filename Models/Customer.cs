using System.ComponentModel.DataAnnotations;

namespace IoTBay.Models;
public class Customer : User
{
    public Guid Id { get; set; }

    [MaxLength(63)]
    public string Address { get; set; }

    public ICollection<PaymentDetails> PaymentDetails { get; } = new List<PaymentDetails>();

    public ICollection<Review> Reviews { get; } = new List<Review>();

    public Customer(string username, string password, string fullName, string email, string address) : base(username, password, fullName, email)
    {
        Address = address;
    }
}
