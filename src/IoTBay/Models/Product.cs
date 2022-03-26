using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace IoTBay.Models;

public class Product
{
    public int Id { get; set; }

    [MaxLength(63)]
    public string Name { get; set; }

    public string Description { get; set; }

    [MaxLength(255)]
    public string ImgUrl { get; set; }

    public Category Category { get; set; } = null!;

    public int StockLevel { get; set; }

    public int OnOrder { get; set; }

    [Precision(7, 2)]
    public decimal Price { get; set; }

    public ICollection<Review> Reviews { get; } = new List<Review>();

    public ICollection<Order> Orders { get; } = new List<Order>();

    public Product(string name, string description, string imgUrl, int stockLevel, int onOrder, decimal price)
    {
        Name = name;
        Description = description;
        ImgUrl = imgUrl;
        StockLevel = stockLevel;
        OnOrder = onOrder;
        Price = price;
    }
}
