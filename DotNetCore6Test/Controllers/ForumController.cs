using DotNetCore6Test.Entities.Auth;
using DotNetCore6Test.Entities.Forum;
using DotNetCore6Test.Migrations;
using DotNetCore6Test.Models.Auth;
using DotNetCore6Test.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore6Test.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ForumController : ControllerBase
    {
        private IForumService _forumService;
        public ForumController(IForumService forumService)
        {
            _forumService = forumService;
        }

        [HttpGet("Post/{PostId}/{CommentId?}")]
        public IActionResult GetPost(Guid PostId, Guid? CommentId)
        {
            //Get the Post
            Post? post = _forumService.GetPost(PostId);

            if (post == null)
            {
                return Ok(new
                {
                    message = "The post does not exist"
                });
            }

            List<Comment> comments = new List<Comment>();

            //If Comment Id is null, get all the comments, else start at specified comment and drill down
            if (CommentId == null)
            {
                _forumService.GetCommentsByPostId(PostId);
            }
            else
            {
                _forumService.GetCommentsByParentCommentId((Guid)CommentId);
            }

            return Ok(new {
               Post = post,
               Comments = comments
            });
        }

        [HttpPost("Posts")]
        public IActionResult GetPosts()
        {
            //Get the Post
            List<Post> posts = _forumService.GetPosts();

            return Ok(new
            {
                Posts = posts,
            });
        }

    }
}
