using tmdbapi.Models;

namespace tmdbapi.Repos.IRepos
{
    public interface IMovieHelper
    {
        MovieDetails GetMovieDetails(long movieId);
        ImageGallery GetMovieImages(long movieId);
        MovieCast GetMovieCast(long movieId);
        MoviesList GetTopMoviesList(long pageNumber);
        MoviesList GetPaginatedMoviesListWithSearch(string searchKeyWord,long pageNumber);
        MoviesList GetMoviesListWithSearch(string searchKeyWord);
        GenresList GetMoviesGenreList();
    }
}
