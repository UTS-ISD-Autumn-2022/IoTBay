#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IoTBay.Data;
using IoTBay.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace IoTBay.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin, Staff")]
public class ProductsController : Controller
{
    private readonly ILogger<ProductsController> _logger;
    private readonly IoTBayDbContext _ctx;

    public ProductsController(ILogger<ProductsController> logger, IoTBayDbContext ctx)
    {
        _logger = logger;
        _ctx = ctx;
    }

    // GET: Admin/Products
    public async Task<IActionResult> Index()
    {
        return View(await _ctx.Products.Include(p => p.Category).ToListAsync());
    }

    // GET: Admin/Products/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = await _ctx.Products
            .FirstOrDefaultAsync(m => m.Id == id);
        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    // GET: Admin/Products/Create
    public async Task<IActionResult> Create()
    {
        return View(new CreateProductViewModel
        {
            SelectCategories = new SelectList(await _ctx.Categories.ToListAsync(), nameof(Category.Id), nameof(Category.Name))
        });
    }

    // POST: Admin/Products/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Name,Description,CategoryId,ImgUrl,StockLevel,OnOrder,Price")] CreateProductViewModel createProduct)
    {
        // check if the data is valid
        if (ModelState.IsValid)
        {
            var category = await _ctx.Categories
                .Include(c => c.Products)
                .Where(c => c.Id == int.Parse(createProduct.CategoryId))
                .FirstOrDefaultAsync();

            // create a new product to database
            var product = new Product
            {
                Name = createProduct.Name,
                Description = createProduct.Description,
                ImgUrl = createProduct.ImgUrl,
                StockLevel = createProduct.StockLevel,
                OnOrder = createProduct.OnOrder,
                Price = createProduct.Price,
            };

            // add to database
            category.Products.Add(product);
            await _ctx.SaveChangesAsync();

            _logger.LogInformation("Created new Product: {Name}", product.Name);
            return RedirectToAction(nameof(Index));
        }
        return View(createProduct);
    }

    // GET: Admin/Products/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = await _ctx.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }

    // POST: Admin/Products/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,ImgUrl,StockLevel,OnOrder,Price")] Product product)
    {
        if (id != product.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _ctx.Update(product);
                await _ctx.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(product.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }

    // GET: Admin/Products/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = await _ctx.Products
            .FirstOrDefaultAsync(m => m.Id == id);
        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    // POST: Admin/Products/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var product = await _ctx.Products.FindAsync(id);
        _ctx.Products.Remove(product);
        await _ctx.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ProductExists(int id)
    {
        return _ctx.Products.Any(e => e.Id == id);
    }
}
