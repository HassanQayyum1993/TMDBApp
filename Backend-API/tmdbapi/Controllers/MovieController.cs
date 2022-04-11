using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.IO;
using System.Text;
using tmdbapi.Models;
using System.Text.Json;
using tmdbapi.Repos.IRepos;

namespace tmdbapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpGet("GetMovieDetails")]
        public async Task<IActionResult> GetMovieDetails(long movieId)
        {
                var movieDetails = await _movieRepository.GetMovieDetailsAsync(movieId);
                movieDetails.poster_path = "http://image.tmdb.org/t/p/w500" + movieDetails.poster_path;
                var movieImagePaths = await _movieRepository.GetMovieImagePathsAsync(movieId);
                var movieImageUrls = movieImagePaths.posters.Select(e => "http://image.tmdb.org/t/p/w500" + e.file_path);
                var movieCast = await _movieRepository.GetMovieCastAsync(movieId);

                return new JsonResult(new { MovieDetails = movieDetails, MovieImageUrls = movieImageUrls, MovieCast = movieCast});
        }

        [HttpGet("GetPaginatedTopMoviesList")]
        public async Task<IActionResult> GetTopMovieList(int pageNumber)
        {
            var topMoviesList = await _movieRepository.GetTopMoviesListAsync(pageNumber);
            
            return new JsonResult(new { TopMoviesList = topMoviesList});
        }

        [HttpGet("GetPaginatedMoviesListWithSearch")]
        public async Task<IActionResult> GetPaginatedMoviesListWithSearch(string searchKeyWord, int pageNumber)
        {
            var moviesList = await _movieRepository.GetPaginatedMoviesListWithSearchAsync(searchKeyWord, pageNumber);
            moviesList.results = moviesList.results.Where(c => c.title.ToUpper().Contains(searchKeyWord.ToUpper())).ToList();
            return new JsonResult(new { MoviesList = moviesList });
        }

        [HttpGet("GetPaginatedMoviesListByGenre")]
        public async Task<IActionResult> GetPaginatedMoviesListByGenre(string genre, int pageNumber)
        {
            var genresList = await _movieRepository.GetMoviesGenreListAsync();
            var genreId = genresList.genres.Where(c => c.name.Contains(genre)).ToList()[0].id;
            var moviesList = await _movieRepository.GetPaginatedMoviesListWithSearchAsync(genre, pageNumber);
            moviesList.results = moviesList.results.Where(c => c.genre_ids.Contains(genreId)).ToList();// || c.Country == "SE")
            return new JsonResult(new { MoviesList = moviesList });
        }

        [HttpGet("GetMoviesGenreList")]
        public async Task<IActionResult> GetMoviesGenreList()
        {
            var genresList = await _movieRepository.GetMoviesGenreListAsync();
            return new JsonResult(new { MoviesList = genresList });
        }
    }
}
