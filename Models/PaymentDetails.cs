using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace IoTBay.Models
{
    public class PaymentDetails
    {
        public Guid Id { get; set; }

        [MaxLength(31)]
        public string CardName { get; set; }

        [Precision(16)]
        public decimal CardNumber { get; set; }

        [Precision(3)]
        public decimal CardCvc { get; set; }

        [Precision(2)]
        public decimal ExpiryMonth { get; set; }

        [Precision(4)]
        public decimal ExpiryYear { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

        public PaymentDetails(string cardName, User user)
        {
            CardName = cardName;
            User = user;
        }
    }
}
