using tmdbapi.Models;

namespace tmdbapi.Repos.IRepos
{
    public interface ICommentRepository
    {
        Task<CommentList?> GetCommentsByMovieIdAsync(int movieId);
        Task<Comment?> GetCommentByIdAsync(int id);
        Task<bool> PostCommentAsync(Comment comment);
        Task<bool> DeleteCommentAsync(int commentId);
        Task<bool> UpdateCommentAsync(int id, Comment comment);
    }
}
