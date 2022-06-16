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
        public async Task<CommentList?> GetCommentsByMovieIdAsync(int movieId)
        {
            try
            {
                var comments = await _context.Comment.Where(x => x.MovieId == movieId).OrderByDescending(x => x.Id).ToListAsync();
                var commentList =  new CommentList();
                commentList.Comments = comments;
                return commentList;
            }
            catch
            {
                throw new Exception();
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
                throw new Exception();
            }
        }
        public async Task<bool> PostCommentAsync(Comment comment)
        {
            try
            {
                await _context.Comment.AddAsync(comment);
                return true;
            }
            catch
            {
                throw new Exception();
            }
        }
        public async Task<bool> DeleteCommentAsync(int Id)
        {
            try
            {
                var comment = await _context.Comment.FindAsync(Id);
                if (comment == null)
                {
                    return false;
                }
                _context.Comment.Remove(comment);
                return true;
            }
            catch
            {
                throw new Exception();
            }
        }
        public async Task<bool> UpdateCommentAsync(int id, Comment comment)
        {
            try
            {
                if (await CommentExists(id))
                {
                    _context.Entry(comment).State = EntityState.Modified;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw new Exception();
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
                throw new Exception();
            }
        }
    }
}
