using tmdbapi.Models;

namespace tmdbapi.ViewModels
{
    public class MovieDetailsViewModel: IResponse
    {
        public MovieDetails? MovieDetails { get; set; }
        public List<string>? MovieImageUrls { get; set; }
        public MovieCast? MovieCast { get; set; }
    }
}
