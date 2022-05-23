#nullable disable
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tmdbapi.Models;
using tmdbapi.Services.IServices;
using tmdbapi.ViewModels;

namespace tmdbapi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        [Route("GetCommentsByMovieId")]
        public async Task<ActionResult> GetCommentsByMovieId(int movieId)
        {
            var result = await _commentService.GetCommentsByMovieIdAsync(movieId);
            if (result.Status == "Success")
            {
                return Ok(result as CommentListViewModel);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }
        }

        // GET: api/Comments/5
        [HttpGet]
        [Route("GetCommentById")]
        public async Task<ActionResult<Comment>> GetCommentById(int id)
        {
            var result = await _commentService.GetCommentByIdAsync(id);
            if (result.Status == "Success")
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }

        }

        // PUT: api/Comments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("PutComment")]
        public async Task<IActionResult> PutComment(int id, Comment comment)
        {
            var result = await _commentService.PutCommentAsync(id, comment);
            if (result.Status == "Success")
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }
        }

        // POST: api/Comments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        [Route("PostComment")]
        public async Task<ActionResult<Comment>> PostComment(Comment comment)
        {
            comment.CreatedOn = DateTime.Now;
            comment.UpdatedOn = DateTime.Now;
            comment.CreatedBy = User.Identity.Name;
            comment.UpdatedBy = User.Identity.Name;
            var result = await _commentService.PostCommentAsync(comment);
            if (result.Status == "Success")
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }
        }

        // DELETE: api/Comments/5
        [HttpDelete]
        [Authorize]
        [Route("DeleteComment")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var result = await _commentService.DeleteCommentAsync(id);
            if (result.Status == "Success")
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }
        }
    }
}
