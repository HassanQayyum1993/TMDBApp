using tmdbapi.Models;

namespace tmdbapi.ViewModels
{
    public class GenreListViewModel: IResponse
    {
        public GenresList? GenreList { get; set; }
    }
}
