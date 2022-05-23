using tmdbapi.Models;

namespace tmdbapi.ViewModels
{
    public class CommentListViewModel:IResponse
    {
        public List<Comment>? Comments;
    }
}
