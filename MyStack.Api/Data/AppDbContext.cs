using Microsoft.EntityFrameworkCore;
using MyStack.Api.Models;

namespace MyStack.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
        public DbSet<HardwareItem> HardwareItems => Set<HardwareItem>();
    }
}
