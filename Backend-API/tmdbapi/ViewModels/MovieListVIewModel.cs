using tmdbapi.Models;

namespace tmdbapi.ViewModels
{
    public class MovieListViewModel: IResponse
    {
        public MoviesList? MovieList { get; set; }
    }
}
