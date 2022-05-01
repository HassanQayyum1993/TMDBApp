using tmdbapi.Models;

namespace tmdbapi.Repos.IRepos
{
    public interface IMovieHelper
    {
        MovieDetails GetMovieDetails(int movieId);
        ImageGallery GetMovieImages(int movieId);
        MovieCast GetMovieCast(int movieId);
        MoviesList GetTopMoviesList(int pageNumber);
        MoviesList GetPaginatedMoviesListWithSearch(string searchKeyWord, int genreId, int pageNumber);
        MoviesList GetPaginatedMoviesListByGenre(int genreId, int pageNumber);
        GenresList GetMoviesGenreList();
    }
}
