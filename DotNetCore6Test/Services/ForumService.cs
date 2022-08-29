using DotNetCore6Test.Context;
using DotNetCore6Test.Entities.Auth;
using DotNetCore6Test.Entities.Forum;
using DotNetCore6Test.Models.Forum;
using System.Security.Claims;

namespace DotNetCore6Test.Services
{
    public interface IForumService
    {
        public Post? GetPost(Guid PostId);
        public List<Comment> GetCommentsByPostId(Guid PostId);
        public List<Comment> GetCommentsByParentCommentId(Guid CommentId);
        public List<Post> GetPosts();
        public Post CreatePost(CreatePostModel formValues);
    }

    public class ForumService : IForumService
    {
        public IWebHostEnvironment _env;
        DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ForumService(IWebHostEnvironment env, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _env = env;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public Post? GetPost(Guid PostId)
        {
            return _context.Posts.Find(PostId);
        }

        public List<Comment> GetCommentsByPostId(Guid PostId)
        {
            List<Comment> comments = _context.Comments
                .Where(c => c.PostId == PostId).ToList();

            foreach (Comment comment in comments)
            {
                List<Comment> childComments = GetCommentsByPostId(comment.Id);
                comments = comments.Concat(childComments).ToList();
            }

            return comments;
        }

        public List<Comment> GetCommentsByParentCommentId(Guid CommentId)
        {
            List<Comment> comments = _context.Comments
                .Where(c => c.ParentId == CommentId).ToList();

            foreach (Comment comment in comments)
            {
                List<Comment> childComments = GetCommentsByPostId(comment.Id);
                comments = comments.Concat(childComments).ToList();
            }

            return comments;
        }

        public List<Post> GetPosts()
        {
            return _context.Posts.OrderBy(p => p.CreatedTimestamp).ToList();
        }

        public Post CreatePost(CreatePostModel formValues)
        {
            Guid userId = new Guid(_httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value);

            Post post = new Post
            {
                AuthorId = userId,
                CreatedTimestamp = DateTime.UtcNow,
                Title = formValues.Title,
                Body = formValues.Body,
                Link = formValues.Link
            };

            _context.Posts.Add(post);
            _context.SaveChanges();

            return post;
        }

    }
}
