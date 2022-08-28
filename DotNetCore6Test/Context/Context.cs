﻿using DotNetCore6Test.Entities.Auth;
using DotNetCore6Test.Entities.Forum;
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

            Guid UserId = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = UserId,
                    FirstName = "First",
                    LastName = "Last",
                    Email = "test@test.com",
                    IsAdmin = true,
                    PasswordHash = hash,
                    PasswordSalt = salt
                }
            );

            Guid PostId = Guid.NewGuid();
            modelBuilder.Entity<Post>().HasData(
                new Post
                {
                    Id = PostId,
                    AuthorId = UserId,
                    CreatedTimestamp = DateTime.UtcNow,
                    Title = "This is a test title",
                    Body = "This is a test body",
                    Link = "https://www.twitch.tv/"
                }
            );
        }

        // Auth
        public DbSet<User> Users { get; set; }

        public DbSet<UserLogin> UserLogins { get; set; }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}
