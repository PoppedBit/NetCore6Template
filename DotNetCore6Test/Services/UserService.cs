using DotNetCore6Test.Context;
using DotNetCore6Test.Entities.Auth;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Security.Cryptography;

namespace DotNetCore6Test.Services
{
    public interface IUserService
    {
        public User? Authenticate(string email, string password);
    }

    public class UserService: IUserService
    {
        public IWebHostEnvironment _env;
        DataContext _context;
        
        public UserService(IWebHostEnvironment env, DataContext context)
        {
            _env = env;
            _context = context;
        }

        public User? Authenticate(string email, string password)
        {
            // Check if either of these are empty
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return null;
            }
            
            // Get User
            User user = _context.Users.SingleOrDefault(u => u.Email == email);

            // If no user has email, return
            if (user == null)
            {
                return null;
            }
            
            // Verify the password
            if(!VerifyPassword(user, password))
            {
                return null;
            }

            return user;
        }

        private static bool VerifyPassword(User user, string password)
        {
            byte[] hash = user.PasswordHash;
            byte[] salt = user.PasswordSalt;

            if (string.IsNullOrEmpty(password))
            {
                return false;
            }

            HMACSHA512 hmac = new HMACSHA512(salt);

            byte[] computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != hash[i] )
                {
                    return false;
                }
            }

            return true;
        }

        public static void CreatePasswordHash(string password, out byte[] hash, out byte[] salt)
        {
            HMACSHA512 hmac = new HMACSHA512();
            hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            salt = hmac.Key;
        }
    }
}
