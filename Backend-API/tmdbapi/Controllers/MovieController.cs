using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.IO;
using System.Text;
using tmdbapi.Models;
using System.Text.Json;
using tmdbapi.Repos.IRepos;
using tmdbapi.Services.IServices;

namespace tmdbapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("GetMovieDetails")]
        public async Task<IActionResult> GetMovieDetails(int movieId)
        {
            var result = await _movieService.GetMovieDetailsAsync(movieId);
            return Ok(result);
        }

        [HttpGet("GetPaginatedTopMoviesList")]
        public async Task<IActionResult> GetTopMovieList(int pageNumber)
        {

            var result = await _movieService.GetTopMovieListAsync(pageNumber);
            return Ok(result);
        }

        [HttpGet("GetPaginatedMoviesListWithSearch")]
        public async Task<IActionResult> GetPaginatedMoviesListWithSearch(string searchKeyWord, int genreId,  int pageNumber)
        {
          var result = await _movieService.GetPaginatedMoviesListWithSearchAsync(searchKeyWord, genreId, pageNumber);
            return Ok(result);
        }

        [HttpGet("GetPaginatedMoviesListByGenre")]
        public async Task<IActionResult> GetPaginatedMoviesListByGenre(int genreId, int pageNumber)
        {
            var result = await _movieService.GetPaginatedMoviesListByGenreAsync(genreId, pageNumber);
            return Ok(result);
        }

        [HttpGet("GetMoviesGenreList")]
        public async Task<IActionResult> GetMoviesGenreList()
        {
            var result = await _movieService.GetMoviesGenreListAsync();
            return Ok(result);
        }
    }
}
