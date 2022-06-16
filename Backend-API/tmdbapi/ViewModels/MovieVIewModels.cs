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
        //public string? original_title { get; set; }
        //public string? original_language { get; set; }
        public string? title { get; set; }
        //public string? backdrop_path { get; set; }
        //public double popularity { get; set; }
        //public int vote_count { get; set; }
        //public bool video { get; set; }
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
        //public bool adult { get; set; }
        //public string? backdrop_path { get; set; }
        //public object? belongs_to_collection { get; set; }
        //public int budget { get; set; }
        public List<GenreViewModel>? genres { get; set; }
        //public string? homepage { get; set; }
        public int id { get; set; }
        //public string? imdb_id { get; set; }
        //public string? original_language { get; set; }
        //public string? original_title { get; set; }
        public string? overview { get; set; }
        public double popularity { get; set; }
        public string? poster_path { get; set; }
        //public List<ProductionCompany>? production_companies { get; set; }
        //public List<ProductionCountry>? production_countries { get; set; }
        public string? release_date { get; set; }
        //public int revenue { get; set; }
        //public int runtime { get; set; }
        //public List<SpokenLanguage>? spoken_languages { get; set; }
        //public string? status { get; set; }
        //public string? tagline { get; set; }
        public string? title { get; set; }
        //public bool video { get; set; }
        public double vote_average { get; set; }
        //public int vote_count { get; set; }
    }

    public class MovieCastViewModel
    {
        public int id { get; set; }
        public List<CastDetailsViewModel>? cast { get; set; }
    }

    public class CastDetailsViewModel
    {
        //public bool adult { get; set; }
        //public int gender { get; set; }
        public int id { get; set; }
        //public string? known_for_department { get; set; }
        public string? name { get; set; }
        //public string? original_name { get; set; }
        //public double popularity { get; set; }
        //public string? profile_path { get; set; }
        //public int cast_id { get; set; }
        //public string? character { get; set; }
        //public string? credit_id { get; set; }
        //public int order { get; set; }
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
