using tmdbapi.Models;

namespace tmdbapi.Repos.IRepos
{
    public interface IMovieRepository
    {
        Task<MovieDetails> GetMovieDetailsAsync(int movieId);
        Task<ImageGallery> GetMovieImagePathsAsync(int movieId);
        Task<MovieCast> GetMovieCastAsync(int movieId);
        Task<MoviesList> GetTopMoviesListAsync(int pageNumber);
        Task<MoviesList> GetPaginatedMoviesListWithSearchAsync(string searchKeyWord, int genreId, int pageNumber);
        Task<MoviesList> GetPaginatedMoviesListByGenreAsync(int genreId, int pageNumber);
        Task<GenresList> GetMoviesGenreListAsync();
    }
}
