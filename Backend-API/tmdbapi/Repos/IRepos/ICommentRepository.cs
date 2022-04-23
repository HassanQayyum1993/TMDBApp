using tmdbapi.Models;

namespace tmdbapi.Repos.IRepos
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetCommentsByMovieIdAsync(int movieId);
        Task<Comment> GetCommentByIdAsync(int id);
        Task<int> PostCommentAsync(Comment comment);
        Task<int> DeleteCommentAsync(int commentId);
        Task<int> PutCommentAsync(int id, Comment comment);
    }
}
