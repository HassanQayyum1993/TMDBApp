using tmdbapi.Models;

namespace tmdbapi.ViewModels
{
    public class MovieVIewModels: IResponse
    {
        public MovieListDetailsViewModel? MovieList { get; set; }
    }

    public class MovieListDetailsViewModel
    {
        public int page { get; set; }
        public List<ResultViewModel>? results { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
    }
    public class ResultViewModel
    {
        public string? poster_path { get; set; }
        public bool adult { get; set; }
        public string? overview { get; set; }
        public string? release_date { get; set; }
        public List<int>? genre_ids { get; set; }
        public int id { get; set; }
        public string? title { get; set; }
        public double vote_average { get; set; }
    }
    public class MovieViewModel : IResponse
    {
        public MovieDetailsViewModel? MovieDetails { get; set; }
        public List<string>? MovieImageUrls { get; set; }
        public MovieCastViewModel? MovieCast { get; set; }
    }

    public class MovieDetailsViewModel
    {
        public List<GenreViewModel>? genres { get; set; }
        public int id { get; set; }
        public string? overview { get; set; }
        public double popularity { get; set; }
        public string? poster_path { get; set; }
        public string? release_date { get; set; }
        public string? title { get; set; }
        public double vote_average { get; set; }
    }

    public class MovieCastViewModel
    {
        public int id { get; set; }
        public List<CastDetailsViewModel>? cast { get; set; }
    }

    public class CastDetailsViewModel
    {
        public int id { get; set; }
        public string? name { get; set; }
    }
    public class GenreViewModel
    {
        public int id { get; set; }
        public string? name { get; set; }
    }

    public class GenreListViewModel : IResponse
    {
        public List<GenreViewModel>? GenreList { get; set; }
    }
}
