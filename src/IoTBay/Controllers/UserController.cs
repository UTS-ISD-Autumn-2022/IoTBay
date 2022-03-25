using Microsoft.AspNetCore.Mvc;
using IoTBay.Models;
using IoTBay.Data;
using Microsoft.EntityFrameworkCore;

namespace IoTBay.Controllers;

public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private readonly IoTBayDbContext _ctx;

    public UserController(ILogger<UserController> logger, IoTBayDbContext ctx)
    {
        _logger = logger;
        _ctx = ctx;
    }

    // GET
    public IActionResult Index()
    {
        return View();
    }

    // GET
    public IActionResult Login()
    {
        return View();
    }

    // GET
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    async public Task<IActionResult> SubmitRegistration(
        [Bind("Username,Password,FullName,Email,Address")] Customer customer)

    {
        try
        {
            if (ModelState.IsValid)
            {
                _ctx.Add(customer);
                await _ctx.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }
        catch (DbUpdateException)
        {
            ModelState.AddModelError("", "Unable to create user");
        }

        return View(customer);
    }
}