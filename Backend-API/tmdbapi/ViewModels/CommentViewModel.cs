using tmdbapi.Models;

namespace tmdbapi.ViewModels
{
    public class CommentViewModel: IResponse
    {
        public Comment? Comment { get; set; }
    }
}
