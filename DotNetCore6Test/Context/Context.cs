using DotNetCore6Test.Entities.Auth;
using Microsoft.EntityFrameworkCore;

namespace DotNetCore6Test.Context
{
    public class Context : DbContext
    {
        protected readonly IConfiguration Configuration;

        public Context(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to mysql with connection string from app settings
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        // Auth
        public DbSet<User> Users { get; set; }

        public DbSet<UserLogin> UserLogins { get; set; }
    }
}
