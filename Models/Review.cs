using System.ComponentModel.DataAnnotations;

namespace IoTBay.Models;

public class Review
{
    public int Id { get; set; }

    [MaxLength(255)]
    public string ReviewContent { get; set; }

    public int CustomerId { get; set; }

    public Customer Customer { get; set; }

    public int ProductId { get; set; }

    public Product Product { get; set; }

    public Review(string reviewContent, int customerId, Customer customer, int productId, Product product)
    {
        ReviewContent = reviewContent;
        CustomerId = customerId;
        Customer = customer;
        ProductId = productId;
        Product = product;
    }
}