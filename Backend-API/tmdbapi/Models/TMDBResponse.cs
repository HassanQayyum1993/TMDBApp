namespace tmdbapi.Models
{
    public class TMDBResponse
    {
        public int Status_Code { get; set; }
        public string? Status_Message { get; set; }
        public bool Success { get; set; }
    }
}
