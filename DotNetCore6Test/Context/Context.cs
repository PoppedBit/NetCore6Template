using DotNetCore6Test.Entities.Auth;
using DotNetCore6Test.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace DotNetCore6Test.Context
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to mysql with connection string from app settings
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add a default user an admin can use to login for the first time after site setup
            byte[] hash;
            byte[] salt;

            UserService.CreatePasswordHash("test", out hash, out salt);

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = Guid.NewGuid(),
                FirstName = "First",
                LastName = "Last",
                Email = "test@test.com",
                IsAdmin = true,
                PasswordHash = hash,
                PasswordSalt = salt
            });
        }

        // Auth
        public DbSet<User> Users { get; set; }

        public DbSet<UserLogin> UserLogins { get; set; }
    }
}
