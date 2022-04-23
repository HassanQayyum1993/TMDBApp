namespace tmdbapi.Models
{
    public class Comment
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
