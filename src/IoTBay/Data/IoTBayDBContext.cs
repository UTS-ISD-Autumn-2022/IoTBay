using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IoTBay.Models;

namespace IoTBay.Data;

public class IoTBayDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<PaymentDetails> PaymentDetails => Set<PaymentDetails>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Review> Reviews => Set<Review>();
    public DbSet<Order> Orders => Set<Order>();

    public IoTBayDbContext(DbContextOptions<IoTBayDbContext> options) : base(options)
    {
    }
}
