using tmdbapi.ViewModels;

namespace tmdbapi.Services.IServices
{
    public interface IMovieService
    {
        Task<IResponse> GetMovieDetailsAsync(int movieId);
        Task<IResponse> GetTopMovieListAsync(int pageNumber);
        Task<IResponse> GetPaginatedMoviesListWithSearchAsync(string searchKeyWord, int genreId, int pageNumber);
        Task<IResponse> GetPaginatedMoviesListByGenreAsync(int genreId, int pageNumber);
        Task<IResponse> GetMoviesGenreListAsync();
    }
}
