using tmdbapi.Models;
using tmdbapi.ViewModels;

namespace tmdbapi.Services.IServices
{
    public interface ICommentService
    {
        Task<IResponse> GetCommentsByMovieIdAsync(int movieId);
        Task<IResponse> GetCommentByIdAsync(int id);
        Task<IResponse> UpdateCommentAsync(int id, Comment comment);
        Task<IResponse> PostCommentAsync(Comment comment);
        Task<IResponse> DeleteCommentAsync(int id);
    }
}
