using System.ComponentModel.DataAnnotations;

namespace IoTBay.Models;

public class Category
{
    public int Id { get; set; }

    [MaxLength(63)]
    public string Name { get; set; }

    public string Description { get; set; }

    [MaxLength(255)]
    public string ImgUrl { get; set; }

    public ICollection<Product> Products { get; } = new List<Product>();

    public Category(string name, string description, string imgUrl)
    {
        Name = name;
        Description = description;
        ImgUrl = imgUrl;
    }
}
