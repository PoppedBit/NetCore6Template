using System.ComponentModel.DataAnnotations;

namespace DotNetCore6Test.Models.Forum
{
    public class CreatePostModel
    {
        [Required]
        public string Title { get; set; }

        public string Link { get; set; } = "";

        public string Body { get; set; } = "";
    }
}
