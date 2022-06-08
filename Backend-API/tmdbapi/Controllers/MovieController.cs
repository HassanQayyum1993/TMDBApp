using Microsoft.AspNetCore.Mvc;
using tmdbapi.Constants;
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

        [HttpGet("MovieDetails")]
        public async Task<IActionResult> GetMovieDetails(int movieId)
        {
            try
            {
                var result = await _movieService.GetMovieDetailsAsync(movieId);
                if (result.Status == Statuses.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, result);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = Statuses.Error, Message = "Unable to get movie details!" });
            }
        }

        [HttpGet("PaginatedTopMoviesList")]
        public async Task<IActionResult> GetTopMovieList(int pageNumber)
        {
            try
            {
                var result = await _movieService.GetTopMovieListAsync(pageNumber);
                if (result.Status == Statuses.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, result);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = Statuses.Error, Message = "Unable to get top movies!" });
            }
        }

        [HttpGet("PaginatedMoviesListWithSearch")]
        public async Task<IActionResult> GetPaginatedMoviesListWithSearch(string searchKeyWord, int genreId, int pageNumber)
        {
            try
            {
                var result = await _movieService.GetPaginatedMoviesListWithSearchAsync(searchKeyWord, genreId, pageNumber);
                if (result.Status == Statuses.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, result);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = Statuses.Error, Message = "Unable to get searched movies!" });
            }
        }

        [HttpGet("PaginatedMoviesListByGenre")]
        public async Task<IActionResult> GetPaginatedMoviesListByGenre(int genreId, int pageNumber)
        {
            try
            {
                var result = await _movieService.GetPaginatedMoviesListByGenreAsync(genreId, pageNumber);
                if (result.Status == Statuses.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, result);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = Statuses.Error, Message = "Unable to get movies by genre!" });
            }
        }

        [HttpGet("MoviesGenreList")]
        public async Task<IActionResult> GetMoviesGenreList()
        {
            try
            {
                var result = await _movieService.GetMoviesGenreListAsync();
                if (result.Status == Statuses.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, result);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = Statuses.Error, Message = "Unable to get genre list!" });
            }
        }
    }
}
