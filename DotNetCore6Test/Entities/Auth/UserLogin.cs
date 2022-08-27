using System.ComponentModel.DataAnnotations;

namespace DotNetCore6Test.Entities.Auth
{
    public class UserLogin
    {
        [Key]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public DateTime LoginTimestamp { get; set; }
    }
}
