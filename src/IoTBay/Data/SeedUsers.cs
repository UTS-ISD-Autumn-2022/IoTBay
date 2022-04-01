using IoTBay.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IoTBay.Data;

public static class SeedUsers
{
    private static void SeedRoles(RoleManager<IdentityRole> roleManager)
    {
        if (!roleManager.RoleExistsAsync("User").Result)
        {
            var role = new IdentityRole
            {
                Name = "User"
            };
            _ = roleManager.CreateAsync(role).Result;
        }
        if (!roleManager.RoleExistsAsync("Admin").Result)
        {
            var role = new IdentityRole
            {
                Name = "Admin"
            };
            _ = roleManager.CreateAsync(role).Result;
        }
        if (!roleManager.RoleExistsAsync("Employee").Result)
        {
            IdentityRole role = new IdentityRole
            {
                Name = "Employee"
            };
            _ = roleManager.CreateAsync(role).Result;
        }
    }

    private static void SeedAdmin(UserManager<IdentityUser> userManager)
    {
        if (userManager.FindByNameAsync("admin").Result == null)
        {
            var user = new IdentityUser
            {
                UserName = "admin",
                Email = "admin@email.com",
            };

            var result = userManager.CreateAsync(user, "Password123").Result;

            if (result.Succeeded)
            {
                userManager.AddToRoleAsync(user, "Admin").Wait();
            }
        }
    }

    public static void Init(IServiceProvider serviceProvider)
    {
        try
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            SeedRoles(roleManager);
            SeedAdmin(userManager);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
}
