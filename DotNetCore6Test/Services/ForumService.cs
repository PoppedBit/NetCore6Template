using DotNetCore6Test.Context;
using DotNetCore6Test.Entities.Auth;
using DotNetCore6Test.Entities.Forum;

namespace DotNetCore6Test.Services
{
    public interface IForumService
    {
        public Post? GetPost(Guid PostId);
        public List<Comment> GetCommentsByPostId(Guid PostId);
        public List<Comment> GetCommentsByParentCommentId(Guid CommentId);
    }

    public class ForumService : IForumService
    {
        public IWebHostEnvironment _env;
        DataContext _context;

        public ForumService(IWebHostEnvironment env, DataContext context)
        {
            _env = env;
            _context = context;
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
    }
}
