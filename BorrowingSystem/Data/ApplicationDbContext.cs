using Microsoft.EntityFrameworkCore;
using BorrowingSystem.Models.UserAccount; // ← Updated namespace

namespace BorrowingSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet for your UserAccount model
        public DbSet<User> Users { get; set; }

        // Seed default admin
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    Username = "admin",
                    Password = "1234", // later hash it
                    Email = "admin@example.com",
                    Role = true,
                    Active = true
                }
            );
        }


    }
}
