﻿using tmdbapi.Models;
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
            string requestURL = Configuration["TMDBConfig:BaseUrl"] + "movie/" + movieId + "?" + Configuration["TMDBConfig:ApiKey"];
            string apiResponse = await _movieHelper.Get(requestURL);
            return JsonSerializer.Deserialize<MovieDetails>(apiResponse);
        }

        public async Task<ImageGallery> GetMovieImagePathsAsync(int movieId)
        {
            string requestURL = "https://api.themoviedb.org/3/movie/" + movieId + "/images" + "?" + Configuration["TMDBConfig:ApiKey"];
            string apiResponse = await _movieHelper.Get(requestURL);
            return JsonSerializer.Deserialize<ImageGallery>(apiResponse);
        }

        public async Task<MovieCast> GetMovieCastAsync(int movieId)
        {
            string requestURL = "https://api.themoviedb.org/3/movie/" + movieId + "/credits" + "?" + Configuration["TMDBConfig:ApiKey"];
            string apiResponse = await _movieHelper.Get(requestURL);
            return JsonSerializer.Deserialize<MovieCast>(apiResponse);
        }

        public async Task<MoviesList> GetTopMoviesListAsync(int pageNumber)
        {
            string requestURL = "https://api.themoviedb.org/3/movie/top_rated" + "?" + Configuration["TMDBConfig:ApiKey"] + "&language=en-US&page=" + pageNumber;
            string apiResponse = await _movieHelper.Get(requestURL);
            return JsonSerializer.Deserialize<MoviesList>(apiResponse);
        }

        public async Task<MoviesList> GetPaginatedMoviesListWithSearchAsync(string searchKeyWord, int genreId, int pageNumber)
        {
            string requestURL = "https://api.themoviedb.org/3/search/movie" + "?" + Configuration["TMDBConfig:ApiKey"] + "&language=en-US&query=" + searchKeyWord + "&with_genres=" + genreId + "&page=" + pageNumber + "&include_adult=false";
            string apiResponse = await _movieHelper.Get(requestURL);
            return JsonSerializer.Deserialize<MoviesList>(apiResponse);
        }
        public async Task<MoviesList> GetPaginatedMoviesListByGenreAsync(int genreId, int pageNumber)
        {
            string requestURL = "https://api.themoviedb.org/3/discover/movie" + "?" + Configuration["TMDBConfig:ApiKey"] + "&language=en-US&with_genres=" + genreId + "&page=" + pageNumber + "&include_adult=false";
            string apiResponse = await _movieHelper.Get(requestURL);
            return JsonSerializer.Deserialize<MoviesList>(apiResponse);
        }
        public async Task<GenresList> GetMoviesGenreListAsync()
        {
            string requestURL = "https://api.themoviedb.org/3/genre/movie/list?" + Configuration["TMDBConfig:ApiKey"] + "&language=en-US";
            string apiResponse = await _movieHelper.Get(requestURL);
            return JsonSerializer.Deserialize<GenresList>(apiResponse);
        }
    }
}
