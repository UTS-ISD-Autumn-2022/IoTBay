/*
using IoTBay.Models;
using Microsoft.EntityFrameworkCore;

namespace IoTBay.Data;

public static class AdminData
{
    public static void Init(IServiceProvider serviceProvider)
    {
        using (var ctx = new IoTBayDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<IoTBayDbContext>>()))
        {
            ctx.Database.EnsureCreated();

            if (ctx.Admins.Any())
            {
                return;
            }

            ctx.Admins.Add(new Admin(
                "admin",
                "password",
                "Admin",
                "admin@fakeemail.com")
            );

            ctx.SaveChanges();
        }
    }
}
*/
