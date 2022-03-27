using System.ComponentModel.DataAnnotations;

namespace IoTBay.Models;
public class Customer
{
    public Guid Id { get; set; }
    
    public string LoginCredentialsId { get; set; } = string.Empty;
    
    [MaxLength(255)]
    public string Address { get; set; } = string.Empty;

    public ICollection<PaymentDetails> PaymentDetails { get; } = new List<PaymentDetails>();

    public ICollection<Review> Reviews { get; } = new List<Review>();
}
