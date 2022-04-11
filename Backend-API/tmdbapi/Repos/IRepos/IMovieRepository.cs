using tmdbapi.Models;

namespace tmdbapi.Repos.IRepos
{
    public interface IMovieRepository
    {
        Task<MovieDetails> GetMovieDetailsAsync(long movieId);
        Task<ImageGallery> GetMovieImagePathsAsync(long movieId);
        Task<MovieCast> GetMovieCastAsync(long movieId);
        Task<MoviesList> GetTopMoviesListAsync(long pageNumber);
        Task<MoviesList> GetPaginatedMoviesListWithSearchAsync(string searchKeyWord, long pageNumber);
        Task<GenresList> GetMoviesGenreListAsync();
    }
}
