#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tmdbapi.Auth;
using tmdbapi.Data;
using tmdbapi.Models;
using tmdbapi.Repos.IRepos;
using tmdbapi.ViewModels;

namespace tmdbapi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        public CommentController(ICommentRepository commentReposiotry)
        {
            _commentRepository = commentReposiotry;
        }

        [HttpGet]
        [Route("GetCommentsByMovieId")]
        public async Task<ActionResult> GetCommentsByMovieId(int movieId)
        {
            //try
            //{
                return Ok(await _commentRepository.GetCommentsByMovieIdAsync(movieId));
            //}
            //catch 
            //{
                //return Ok()
                //As logging is not in scope of the project, so we can implement logging in future.
            //}
        }

        // GET: api/Comments/5
        [HttpGet]
        [Route("GetCommentById")]
        public async Task<ActionResult<Comment>> GetCommentById(int id)
        {
            var comment = await _commentRepository.GetCommentByIdAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            return comment;
        }

        // PUT: api/Comments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Route("PutComment")]
        public async Task<IActionResult> PutComment(int id, Comment comment)
        {
            if (id != comment.Id)
            {
                return BadRequest();
            }

            var result = await _commentRepository.PutCommentAsync(id, comment);
            if (result == 0)
            {
                return NotFound();
            }
            return NoContent();
        }

        // POST: api/Comments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        [Route("PostComment")]
        public async Task<ActionResult<Comment>> PostComment(Comment comment)
        {
            ObjectResult objResult = null;
            comment.CreatedOn = DateTime.Now;
            comment.UpdatedOn = DateTime.Now;
            comment.CreatedBy = User.Identity.Name;
            comment.UpdatedBy = User.Identity.Name;
            var result = await _commentRepository.PostCommentAsync(comment);
            //return CreatedAtAction("PostComment", new { id = comment.Id }, comment);
            result = 0;
                if (result==1)
                {
                    objResult = Ok(new Response { Status = "Success", Message = "Comment added successfully!" });
                }
                else
                {
                    objResult = StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Unable to add this comment!" });
                }
            return objResult;
        }

        // DELETE: api/Comments/5
        [Authorize]
        [HttpDelete]
        [Route("DeleteComment")]
        public async Task<IActionResult> DeleteComment(int id)
        {

            var comment = await _commentRepository.DeleteCommentAsync(id);
            if (comment == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
