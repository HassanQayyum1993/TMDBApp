using tmdbapi.Models;

namespace tmdbapi.Repos.IRepos
{
    public interface IMovieHelper
    {
        Task<string> Get(string requestURL);
    }
}
