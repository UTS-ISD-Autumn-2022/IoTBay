using Microsoft.EntityFrameworkCore;
using IoTBay.Models;

namespace IoTBay.Data;

public class IoTBayDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<PaymentDetails> PaymentDetails { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Order> Orders { get; set; }

    public IoTBayDbContext(DbContextOptions<IoTBayDbContext> options) : base(options)
    {
    }
}