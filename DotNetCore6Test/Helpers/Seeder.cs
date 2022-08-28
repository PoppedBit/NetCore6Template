using DotNetCore6Test.Context;
using DotNetCore6Test.Entities.Auth;
using DotNetCore6Test.Services;

namespace DotNetCore6Test.Helpers
{
    public class Seeder
    {
        public static void AddUsers(DataContext context)
        {
            if(context.Users.Count() > 0)
            {
                return;
            }

            // Add a default user an admin can use to login for the first time after site setup
            byte[] hash;
            byte[] salt;

            UserService.CreatePasswordHash("test", out hash, out salt);

            User user = new User {
                FirstName = "First",
                LastName = "Last",
                Email = "test@test.com",
                IsAdmin = true,
                PasswordHash = hash,
                PasswordSalt = salt
            };

            context.Users.Add(user);

            context.SaveChanges();
        }

    }
}
