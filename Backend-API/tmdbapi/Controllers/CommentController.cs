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
            try
            {
                var result = await _commentService.GetCommentsByMovieIdAsync(movieId);
                if (result.Status == "Success")
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
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Unable to get the movie comments!" });
            }
        }

        // GET: api/Comments/5
        [HttpGet]
        [Route("GetCommentById")]
        public async Task<ActionResult<Comment>> GetCommentById(int id)
        {
            try
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
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Unable to get this comment!" });
            }
        }

        // PUT: api/Comments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateComment(int id, Comment comment)
        {
            try
            {
                var result = await _commentService.UpdateCommentAsync(id, comment);
                if (result.Status == "Success")
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
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Unable to update this comment!" });
            }
        }

        // POST: api/Comments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        [Route("PostComment")]
        public async Task<ActionResult<Comment>> PostComment(Comment comment)
        {
            try
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
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Unable to add this comment!" });
            }
        }

        // DELETE: api/Comments/5
        [HttpDelete]
        [Authorize]
        [Route("DeleteComment")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            try
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
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Unable to delete this comment!" });
            }
        }
    }
}
