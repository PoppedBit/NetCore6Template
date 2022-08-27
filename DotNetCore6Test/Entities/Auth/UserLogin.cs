namespace DotNetCore6Test.Entities.Auth
{
    public class UserLogin
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public DateTime LoginTimestamp { get; set; }
    }
}
