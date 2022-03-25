using Microsoft.AspNetCore.Mvc;

namespace IoTBay.Controllers;

public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
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
}