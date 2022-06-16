using tmdbapi.Models;

namespace tmdbapi.ViewModels
{

    public class CommentListViewModel : IResponse
    {
        public List<CommentDetailsViewModel>? Comments { get; set; }
    }

    public class CommentViewModel : IResponse
    {
        public CommentDetailsViewModel? Comment { get; set; }
    }

        public class CommentDetailsViewModel
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string? Value { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
