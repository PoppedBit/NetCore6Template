using DotNetCore6Test.Entities.Auth;
using Microsoft.EntityFrameworkCore;

namespace DotNetCore6Test.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        // Auth
        public DbSet<User> Users { get; set; }

        public DbSet<UserLogin> UserLogins { get; set; }
    }
}
