using tmdbapi.Repos.IRepos;

namespace tmdbapi.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICommentRepository Comment { get; }
        Task<bool> CompleteAsync();
    }
}
