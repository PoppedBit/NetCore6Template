using System.ComponentModel.DataAnnotations;

namespace DotNetCore6Test.Models.Auth
{
    public class AuthenticateModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password {  get; set; }
    }
}
