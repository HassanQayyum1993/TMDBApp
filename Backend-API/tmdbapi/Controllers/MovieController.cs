using Microsoft.AspNetCore.Mvc;
using tmdbapi.Services.IServices;
using tmdbapi.ViewModels;

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
            try
            {
                var result = await _movieService.GetMovieDetailsAsync(movieId);
                return Ok(result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Unable to get movie details!" });
            }
        }

        [HttpGet("GetPaginatedTopMoviesList")]
        public async Task<IActionResult> GetTopMovieList(int pageNumber)
        {
            try
            {
                var result = await _movieService.GetTopMovieListAsync(pageNumber);
                return Ok(result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Unable to get top movies!" });
            }
        }

        [HttpGet("GetPaginatedMoviesListWithSearch")]
        public async Task<IActionResult> GetPaginatedMoviesListWithSearch(string searchKeyWord, int genreId, int pageNumber)
        {
            try
            {
                var result = await _movieService.GetPaginatedMoviesListWithSearchAsync(searchKeyWord, genreId, pageNumber);
                return Ok(result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Unable to get searched movies!" });
            }
        }

        [HttpGet("GetPaginatedMoviesListByGenre")]
        public async Task<IActionResult> GetPaginatedMoviesListByGenre(int genreId, int pageNumber)
        {
            try
            {
                var result = await _movieService.GetPaginatedMoviesListByGenreAsync(genreId, pageNumber);
                return Ok(result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Unable to get movies by genre!" });
            }
        }

        [HttpGet("GetMoviesGenreList")]
        public async Task<IActionResult> GetMoviesGenreList()
        {
            try
            {
                var result = await _movieService.GetMoviesGenreListAsync();
                return Ok(result);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Unable to get genre list!" });
            }
        }
    }
}
