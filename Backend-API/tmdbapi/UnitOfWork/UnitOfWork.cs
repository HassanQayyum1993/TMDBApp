using tmdbapi.Data;
using tmdbapi.Repos;
using tmdbapi.Repos.IRepos;

namespace tmdbapi.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly tmdbapiContext _context;
        public ICommentRepository Comment { get; private set; }

        public UnitOfWork(tmdbapiContext context)
        {
            _context = context;
            Comment = new CommentRepository(context);
        }

        public async Task CompleteAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                _context.Dispose();
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
