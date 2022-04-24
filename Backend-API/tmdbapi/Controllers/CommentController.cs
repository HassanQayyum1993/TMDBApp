﻿#nullable disable
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

        [HttpGet]
        [Route("GetCommentsByMovieId")]
        public async Task<ActionResult> GetCommentsByMovieId(int movieId)
        {
            return Ok(await _commentRepository.GetCommentsByMovieIdAsync(movieId));
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
            comment.CreatedOn = DateTime.UtcNow;
            comment.CreatedBy = User.Identity.Name;
            comment.UpdatedBy = User.Identity.Name;
            var result = await _commentRepository.PostCommentAsync(comment);
            return CreatedAtAction("PostComment", new { id = comment.Id }, comment);
        }

        // DELETE: api/Comments/5
        [Authorize]
        [HttpDelete]
        [Route("DeleteComment")]
        public async Task<IActionResult> DeleteComment(int id)
        {

            var comment = await _commentRepository.DeleteCommentAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
