using System.ComponentModel.DataAnnotations;

namespace IoTBay.Models;

public class Category
{
    public int Id { get; set; }

    [MaxLength(63)]
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    [MaxLength(255)]
    public string ImgUrl { get; set; } = string.Empty;

    public ICollection<Product> Products { get; } = new List<Product>();
}
