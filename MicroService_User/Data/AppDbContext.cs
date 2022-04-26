using MicroService_User.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroService_User.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
                
        }

        public DbSet<User> Users { get; set; } = null!;
    }
}
