using System.Diagnostics;
using IoTBay.Data;
using IoTBay.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IoTBay.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IoTBayDbContext _ctx;

    public HomeController(ILogger<HomeController> logger, IoTBayDbContext ctx)
    {
        _logger = logger;
        _ctx = ctx;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _ctx.Products.ToListAsync());
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
