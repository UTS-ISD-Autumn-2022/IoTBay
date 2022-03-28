using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IoTBay.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin, Staff")]
public class Home : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
