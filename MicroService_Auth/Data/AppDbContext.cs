using MicroService_Auth.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroService_Auth.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<AuthUser> AuthUsers { get; set; } = null!;
    }
}
