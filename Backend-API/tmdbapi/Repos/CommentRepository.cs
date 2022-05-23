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
        public async Task<List<Comment>> GetCommentsByMovieIdAsync(int movieId)
        {
            return await _context.Comment.Where(x => x.MovieId == movieId).OrderByDescending(x => x.Id).ToListAsync();
        }
        public async Task<Comment> GetCommentByIdAsync(int id)
        {
            return await _context.Comment.FindAsync(id);
        }
        public async Task<int> PostCommentAsync(Comment comment)
        {
            _context.Comment.Add(comment);
           // await _context.SaveChangesAsync();
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
            //await _context.SaveChangesAsync();

            return 1;
        }
        public async Task<int> PutCommentAsync(int id, Comment comment)
        {
            if (CommentExists(id))
            {
                _context.Entry(comment).State = EntityState.Modified;
                return 1;
            }
            else
            {
                return 0;
            }

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!CommentExists(id))
            //    {
            //        return 0;
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

        }
        private bool CommentExists(int id)
        {
            return _context.Comment.Any(e => e.Id == id);
        }

    }

}
