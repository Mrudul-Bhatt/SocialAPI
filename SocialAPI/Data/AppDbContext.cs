using Microsoft.EntityFrameworkCore;
using SocialAPI.Models;

namespace SocialAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<AppUser>? AppUsers { get; set; }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<AppUser>().HasData(
        //         new AppUser { Id = 1, UserName = "John" },
        //         new AppUser { Id = 2, UserName = "Mary" },
        //         new AppUser { Id = 3, UserName = "Bryan" }
        //     );
        // }

    }
}