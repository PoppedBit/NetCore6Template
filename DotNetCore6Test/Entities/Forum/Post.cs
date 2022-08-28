using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DotNetCore6Test.Entities.Forum
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid AuthorId { get; set; }

        public DateTime CreatedTimestamp { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public string Link { get; set; }
    }
}
