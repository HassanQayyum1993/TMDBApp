using tmdbapi.Models;

namespace tmdbapi.Repos.IRepos
{
    public interface IMovieRepository
    {
        Task<MovieDetails> GetMovieDetailsAsync(int movieId);
        Task<ImageGallery> GetMovieImagePathsAsync(int movieId);
        Task<MovieCast> GetMovieCastAsync(int movieId);
        Task<MovieList> GetTopMoviesListAsync(int pageNumber);
        Task<MovieList> GetPaginatedMoviesListWithSearchAsync(string searchKeyWord, int genreId, int pageNumber);
        Task<MovieList> GetPaginatedMoviesListByGenreAsync(int genreId, int pageNumber);
        Task<GenreList> GetMoviesGenreListAsync();
    }
}
