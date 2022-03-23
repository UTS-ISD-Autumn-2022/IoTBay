using System.ComponentModel.DataAnnotations;

namespace IoTBay.Models;

public class Review
{
    public int Id { get; set; }

    [MaxLength(255)]
    public string ReviewContent { get; set; }

    public Customer Customer { get; set; }

    public Product Product { get; set; }

    public Review(string reviewContent)
    {
        ReviewContent = reviewContent;
    }
}