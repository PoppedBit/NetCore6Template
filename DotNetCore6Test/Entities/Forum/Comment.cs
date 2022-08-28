using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DotNetCore6Test.Entities.Forum
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid AuthorId { get; set; }

        public Guid PostId { get; set; }

        public Guid? ParentId { get; set; }

        public DateTime CreatedTimestamp { get; set; }

        public string Body { get; set; }
    }
}
