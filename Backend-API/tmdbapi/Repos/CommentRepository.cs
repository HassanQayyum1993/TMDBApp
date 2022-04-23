﻿using Microsoft.EntityFrameworkCore;
using tmdbapi.Data;
using tmdbapi.Models;
using tmdbapi.Repos.IRepos;

namespace tmdbapi.Repos
{
    public class CommentRepository : ICommentRepository
    {
        private readonly tmdbapiContext _context;
        public CommentRepository(tmdbapiContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Comment>> GetCommentsByMovieIdAsync(int movieId)
        {
            //var result = await _context.Comment.ToListAsync(); ;
            //return await _context.Comment.Where(comment => comment.MovieId == movieId).ToListAsync();
                    
            return await _context.Comment.FromSqlRaw($"SELECT Id, MovieId, Value, CreatedBy, CreatedOn, UpdatedBy, UpdatedOn FROM Comment WHERE MovieId={movieId} ORDER BY Id DESC")
                       .ToListAsync();
        }
        public async Task<Comment> GetCommentByIdAsync(int id)
        {
            return await _context.Comment.FindAsync(id);
        }
        public async Task<int> PostCommentAsync(Comment comment)
        {
            _context.Comment.Add(comment);
            await _context.SaveChangesAsync();
            return 1;
        }
        public async Task<int> DeleteCommentAsync(int Id)
        {
            var comment = await _context.Comment.FindAsync(Id);
            if (comment == null)
            {
                return 0;
            }

            _context.Comment.Remove(comment);
            await _context.SaveChangesAsync();

            return 1;
        }
        public async Task<int> PutCommentAsync(int id, Comment comment)
        {
            _context.Entry(comment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(id))
                {
                    return 0;
                }
                else
                {
                    throw;
                }
            }

            return 1;
        }
        private bool CommentExists(int id)
        {
            return _context.Comment.Any(e => e.Id == id);
        }

    }

}