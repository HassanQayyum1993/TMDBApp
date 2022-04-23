#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tmdbapi.Data;
using tmdbapi.Models;
using tmdbapi.Repos.IRepos;

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

        // GET: api/Comments
        //[HttpGet]
        //[Route("GetAllComments")]
        //public async Task<ActionResult<IEnumerable<Comment>>> GetComment()
        //{
        //    return await _context.Comment.ToListAsync();
        //}

        [HttpGet]
        [Route("GetCommentsByMovieId")]
        public async Task<ActionResult> GetCommentsByMovieId(int movieId)
        {
            //return await _context.Comment.ToListAsync();
            return Ok(await _commentRepository.GetCommentsByMovieIdAsync(movieId));
        }

        // GET: api/Comments/5
        [HttpGet]
        [Route("GetCommentById")]
        public async Task<ActionResult<Comment>> GetCommentById(int id)
        {
            //var comment = await _context.Comment.FindAsync(id);

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
            //_context.Entry(comment).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!CommentExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}
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
        //[ActionName(nameof(PostComment))]
        public async Task<ActionResult<Comment>> PostComment(Comment comment)
        {
            //_context.Comment.Add(comment);
            //await _context.SaveChangesAsync();
            comment.CreatedOn = DateTime.UtcNow;
            comment.CreatedBy = User.Identity.Name;
            var result = await _commentRepository.PostCommentAsync(comment);
            return CreatedAtAction("PostComment", new { id = comment.Id }, comment);
        }

        // DELETE: api/Comments/5
        [Authorize]
        [HttpDelete]
        [Route("DeleteComment")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            //var comment = await _context.Comment.FindAsync(id);

            var comment = await _commentRepository.DeleteCommentAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            //_context.Comment.Remove(comment);
            //await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
