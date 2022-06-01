using Microsoft.EntityFrameworkCore;
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
        public async Task<List<Comment>?> GetCommentsByMovieIdAsync(int movieId)
        {
            try
            {
                return await _context.Comment.Where(x => x.MovieId == movieId).OrderByDescending(x => x.Id).ToListAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<Comment?> GetCommentByIdAsync(int id)
        {
            try
            { 
                return await _context.Comment.FindAsync(id);
            }
            catch
            {
                return null;
            }
        }
        public async Task<int> PostCommentAsync(Comment comment)
        {
            try
            {
                await _context.Comment.AddAsync(comment);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public async Task<int> DeleteCommentAsync(int Id)
        {
            try
            {
                var comment = await _context.Comment.FindAsync(Id);
                if (comment == null)
                {
                    return 0;
                }
                _context.Comment.Remove(comment);

                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public async Task<int> UpdateCommentAsync(int id, Comment comment)
        {
            try
            {
                if ( await CommentExists(id))
                {
                    _context.Entry(comment).State = EntityState.Modified;
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }
        private async Task<bool> CommentExists(int id)
        {
            try
            {
                return await _context.Comment.AnyAsync(e => e.Id == id);
            }
            catch
            {
                return false;
            }
        }

    }

}
