using IoTBay.Data;
using IoTBay.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IoTBay.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;
    private readonly IoTBayDbContext _ctx;
    private readonly SignInManager<IdentityUser> _signInManager;
	private readonly UserManager<IdentityUser> _userManager;

    public AccountController(ILogger<AccountController> logger, IoTBayDbContext ctx, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
    {
        _logger = logger;
        _ctx = ctx;
        _signInManager = signInManager;
		_userManager = userManager;
    }

    [Authorize]
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login([Bind("Username, Password, RememberMe")] LoginViewModel login, string? returnUrl = null)
    {
        returnUrl ??= Url.Content("~/");

        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(login.Username, login.Password, login.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                _logger.LogInformation("User logged in");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(login);
            }
        }
        return View(login);
    }

    [HttpPost] 
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout(string returnUrl = null)
    {
        await _signInManager.SignOutAsync();
        _logger.LogInformation("User logged out.");
        if (returnUrl != null)
        {
            return Redirect(returnUrl);
        }
        
        return Redirect("/");
    }

    public IActionResult Register()
    {
        return View();
    }

	[HttpPost]
    [ValidateAntiForgeryToken]	
	public async Task<IActionResult> Register([Bind("Username, Password, Email, FullName, Address")] RegisterViewModel register, string? returnUrl = null)
	{
		returnUrl ??= Url.Content("~/Index");
		if (ModelState.IsValid)
		{
			var user = new IdentityUser { UserName = register.Username, Email = register.Email };
			var regResult = await _userManager.CreateAsync(user, register.Password);
			if (regResult.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(user, "User");
                if (!roleResult.Succeeded)
                {
                    _logger.LogError("Unable to add user to role User");
                    ModelState.AddModelError(string.Empty, "Registeration Failed.");
                    return View(register);
                }
                
                var customer = new Customer
                {
                    Id = Guid.NewGuid(),
                    LoginCredentialsId = user.Id,
                    FullName = register.FullName,
                    Address = register.Address,
                };
                _ctx.Customers.Add(customer);
                await _ctx.SaveChangesAsync();
                   
				_logger.LogInformation("User created a new account with password.");	
				
                await _signInManager.SignInAsync(user, isPersistent: false);
                _logger.LogInformation("User logged in");
				return RedirectToAction("Index", "Home");
			}
			else
			{
				ModelState.AddModelError(string.Empty, "Registration failed.");
				return View(register);
			}
		}
		return View(register);
	}
}
