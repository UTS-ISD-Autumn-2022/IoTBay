using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace IoTBay.Models;
/*
 * This is model for displaying and binding data from the Admin/Products/Create view
 */
public class CreateProductViewModel
{
    public SelectList SelectCategories { get; set; } = null!;

    [MaxLength(63)]
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string CategoryId { get; set; } = string.Empty;

    [MaxLength(255)]
    public string ImgUrl { get; set; } = string.Empty;

    public int StockLevel { get; set; }

    public int OnOrder { get; set; }

    [Precision(7, 2)]
    public decimal Price { get; set; }
}
