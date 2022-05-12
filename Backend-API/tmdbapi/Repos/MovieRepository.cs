using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.IO;
using System.Text;
using tmdbapi.Models;
using System.Text.Json;
using tmdbapi.Repos.IRepos;
using System.Linq;
using System.Configuration;

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
            string requestURL = Configuration["TMDBConfig:BaseUrl"] + "movie/" + movieId + "?" + Configuration["TMDBConfig:ApiKey"];
            string apiResponse = _movieHelper.Get(requestURL);
            return JsonSerializer.Deserialize<MovieDetails>(apiResponse);
            //return await Task.FromResult(_movieHelper.GetMovieDetails(movieId));
        }

        public async Task<ImageGallery> GetMovieImagePathsAsync(int movieId)
        {
            List<string> resultList = new List<string>();
            string requestURL = "https://api.themoviedb.org/3/movie/" + movieId + "/images" + "?" + Configuration["TMDBConfig:ApiKey"];
            string apiResponse = _movieHelper.Get(requestURL);
            return JsonSerializer.Deserialize<ImageGallery>(apiResponse);
            //return await Task.FromResult(_movieHelper.GetMovieImages(movieId));
        }

        public async Task<MovieCast> GetMovieCastAsync(int movieId)
        {
            List<string> resultList = new List<string>();
            string requestURL = "https://api.themoviedb.org/3/movie/" + movieId + "/credits" + "?" + Configuration["TMDBConfig:ApiKey"];
            string apiResponse = _movieHelper.Get(requestURL);
            return JsonSerializer.Deserialize<MovieCast>(apiResponse);
            //return await Task.FromResult(_movieHelper.GetMovieCast(movieId));
        }

        public async Task<MoviesList> GetTopMoviesListAsync(int pageNumber)
        {
            List<string> resultList = new List<string>();
            string requestURL = "https://api.themoviedb.org/3/movie/top_rated" + "?" + Configuration["TMDBConfig:ApiKey"] + "&language=en-US&page=" + pageNumber;
            string apiResponse = _movieHelper.Get(requestURL);
            return JsonSerializer.Deserialize<MoviesList>(apiResponse);
            //return await Task.FromResult(_movieHelper.GetTopMoviesList(pageNumber));
        }

        public async Task<MoviesList> GetPaginatedMoviesListWithSearchAsync(string searchKeyWord, int genreId, int pageNumber)
        {
            List<string> resultList = new List<string>();
            string requestURL = "https://api.themoviedb.org/3/search/movie" + "?" + Configuration["TMDBConfig:ApiKey"] + "&language=en-US&query=" + searchKeyWord + "&with_genres=" + genreId + "&page=" + pageNumber + "&include_adult=false";
            string apiResponse = _movieHelper.Get(requestURL);
            return JsonSerializer.Deserialize<MoviesList>(apiResponse);
            //return await Task.FromResult(_movieHelper.GetPaginatedMoviesListWithSearch(searchKeyWord, genreId, pageNumber));
        }
        public async Task<MoviesList> GetPaginatedMoviesListByGenreAsync(int genreId, int pageNumber)
        {
            List<string> resultList = new List<string>();
            string requestURL = "https://api.themoviedb.org/3/discover/movie" + "?" + Configuration["TMDBConfig:ApiKey"] + "&language=en-US&with_genres=" + genreId + "&page=" + pageNumber + "&include_adult=false";
            string apiResponse = _movieHelper.Get(requestURL);
            return JsonSerializer.Deserialize<MoviesList>(apiResponse);
            //return await Task.FromResult(_movieHelper.GetPaginatedMoviesListByGenre(genreId, pageNumber));
        }
        public async Task<GenresList> GetMoviesGenreListAsync()
        {
            List<string> resultList = new List<string>();
            string requestURL = "https://api.themoviedb.org/3/genre/movie/list?" + Configuration["TMDBConfig:ApiKey"] + "&language=en-US";
            string apiResponse = _movieHelper.Get(requestURL);
            return JsonSerializer.Deserialize<GenresList>(apiResponse);
            //return await Task.FromResult(_movieHelper.GetMoviesGenreList());
        }
    }
}
