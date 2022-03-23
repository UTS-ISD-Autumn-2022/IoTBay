using Microsoft.EntityFrameworkCore;
using IoTBay.Models;

namespace IoTBay.Data;

public class IoTBayDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Admin> Admins => Set<Admin>();
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