using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace IoTBay.Models;

public class Product
{
    public int Id { get; set; }

    [MaxLength(31)]
    public string Name { get; set; }

    [MaxLength(255)]
    public string Description { get; set; }

    [MaxLength(63)]
    public string ImgUrl { get; set; }

    public int CategoryId { get; set; }

    public Category Category { get; set; }

    public int StockLevel { get; set; }

    public int OnOrder { get; set; }

    [Precision(7, 2)]
    public decimal Price { get; set; }

    public ICollection<Review> Reviews { get; set; }

    public ICollection<OrderProduct> Orders { get; set; }

    public Product(string name, string description, string imgUrl, int categoryId, int stockLevel, int onOrder, decimal price, Category category)
    {
        Name = name;
        Description = description;
        ImgUrl = imgUrl;
        CategoryId = categoryId;
        Category = category;
        StockLevel = stockLevel;
        OnOrder = onOrder;
        Price = price;
        Reviews = new List<Review>();
        Orders = new List<OrderProduct>();
    }
}