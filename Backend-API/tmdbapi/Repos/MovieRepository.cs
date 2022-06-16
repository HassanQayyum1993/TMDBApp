#nullable disable
using tmdbapi.Models;
using System.Text.Json;
using tmdbapi.Repos.IRepos;

namespace tmdbapi.Repos

{
    public class MovieRepository : IMovieRepository
    {
        private readonly IMovieHelper _movieHelper;
        private readonly IConfiguration Configuration;

        public MovieRepository(IMovieHelper movieHelper, IConfiguration configuration)
        {
            _movieHelper = movieHelper;
            Configuration = configuration;
        }
        public async Task<MovieDetails> GetMovieDetailsAsync(int movieId)
        {
            try
            {
                string requestURL = Configuration["TMDBConfig:BaseUrl"] + "movie/" + movieId + "?" + Configuration["TMDBConfig:ApiKey"];
                string apiResponse = await _movieHelper.Get(requestURL);
                return JsonSerializer.Deserialize<MovieDetails>(apiResponse!);
            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task<ImageGallery> GetMovieImagePathsAsync(int movieId)
        {
            try
            {
                string requestURL = Configuration["TMDBConfig:BaseUrl"] + "movie/" + movieId + "/images" + "?" + Configuration["TMDBConfig:ApiKey"];
                string apiResponse = await _movieHelper.Get(requestURL);
                return JsonSerializer.Deserialize<ImageGallery>(apiResponse);
            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task<MovieCast> GetMovieCastAsync(int movieId)
        {
            try
            {
                string requestURL = Configuration["TMDBConfig:BaseUrl"] + "movie/" + movieId + "/credits" + "?" + Configuration["TMDBConfig:ApiKey"];
                string apiResponse = await _movieHelper.Get(requestURL);
                return JsonSerializer.Deserialize<MovieCast>(apiResponse);
            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task<MovieList> GetTopMoviesListAsync(int pageNumber)
        {
            try
            {
                string requestURL = Configuration["TMDBConfig:BaseUrl"] + "movie/top_rated" + "?" + Configuration["TMDBConfig:ApiKey"] + "&language=en-US&page=" + pageNumber;
                string apiResponse = await _movieHelper.Get(requestURL);
                return JsonSerializer.Deserialize<MovieList>(apiResponse);
            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task<MovieList> GetPaginatedMoviesListWithSearchAsync(string searchKeyWord, int genreId, int pageNumber)
        {
            try
            {
                string requestURL = Configuration["TMDBConfig:BaseUrl"] + "search/movie" + "?" + Configuration["TMDBConfig:ApiKey"] + "&language=en-US&query=" + searchKeyWord + "&with_genres=" + genreId + "&page=" + pageNumber + "&include_adult=false";
                string apiResponse = await _movieHelper.Get(requestURL);
                return JsonSerializer.Deserialize<MovieList>(apiResponse);
            }
            catch
            {
                throw new Exception();
            }
        }
        public async Task<MovieList> GetPaginatedMoviesListByGenreAsync(int genreId, int pageNumber)
        {
            try
            {
                string requestURL = Configuration["TMDBConfig:BaseUrl"] + "discover/movie?" + Configuration["TMDBConfig:ApiKey"] + "&language=en-US&with_genres=" + genreId + "&page=" + pageNumber + "&include_adult=false";
                string apiResponse = await _movieHelper.Get(requestURL);
                return JsonSerializer.Deserialize<MovieList>(apiResponse);
            }
            catch
            {
                throw new Exception();
            }
        }
        public async Task<GenreList> GetMoviesGenreListAsync()
        {
            try
            {
                string requestURL = Configuration["TMDBConfig:BaseUrl"] + "genre/movie/list?" + Configuration["TMDBConfig:ApiKey"] + "&language=en-US";
                string apiResponse = await _movieHelper.Get(requestURL);
                return JsonSerializer.Deserialize<GenreList>(apiResponse);
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
