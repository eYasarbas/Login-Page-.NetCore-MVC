using Microsoft.EntityFrameworkCore;
using MvcWebApp.Entities;

public class DatabseContext : DbContext
{
    public DatabseContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User>? Users { get; set; }
}