namespace tmdbapi.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Backdrop
    {
        public double aspect_ratio { get; set; }
        public string? file_path { get; set; }
        public int height { get; set; }
        public string? iso_639_1 { get; set; }
        public int vote_average { get; set; }
        public int vote_count { get; set; }
        public int width { get; set; }
    }

    public class Poster
    {
        public double aspect_ratio { get; set; }
        public string? file_path { get; set; }
        public int height { get; set; }
        public string? iso_639_1 { get; set; }
        public double vote_average { get; set; }
        public int vote_count { get; set; }
        public int width { get; set; }
    }

    public class ImageGallery
    {
        public int id { get; set; }
        //public List<Backdrop>? backdrops { get; set; }
        public List<Poster>? posters { get; set; }
    }

    public class CastDetails
    {
        public bool adult { get; set; }
        public int gender { get; set; }
        public int id { get; set; }
        public string? known_for_department { get; set; }
        public string? name { get; set; }
        public string? original_name { get; set; }
        public double popularity { get; set; }
        public string? profile_path { get; set; }
        public int cast_id { get; set; }
        public string? character { get; set; }
        public string? credit_id { get; set; }
        public int order { get; set; }
    }

    public class MovieCast
    {
        public int id { get; set; }
        public List<CastDetails>? cast { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Genre
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class ProductionCompany
    {
        public int id { get; set; }
        public string logo_path { get; set; }
        public string name { get; set; }
        public string origin_country { get; set; }
    }

    public class ProductionCountry
    {
        public string iso_3166_1 { get; set; }
        public string name { get; set; }
    }

    public class SpokenLanguage
    {
        public string iso_639_1 { get; set; }
        public string name { get; set; }
    }

    public class MovieDetails
    {
        //public bool adult { get; set; }
        //public string backdrop_path { get; set; }
        //public object belongs_to_collection { get; set; }
        //public int budget { get; set; }
        public List<Genre> genres { get; set; }
        //public string homepage { get; set; }
        //public int id { get; set; }
        public string imdb_id { get; set; }
        //public string original_language { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        //public double popularity { get; set; }
        public string poster_path { get; set; }
        //public List<ProductionCompany> production_companies { get; set; }
        //public List<ProductionCountry> production_countries { get; set; }
        public string release_date { get; set; }
        public int revenue { get; set; }
        public int runtime { get; set; }
        public List<SpokenLanguage> spoken_languages { get; set; }
        //public string status { get; set; }
        //public string tagline { get; set; }
        public string title { get; set; }
        //public bool video { get; set; }
        //public double vote_average { get; set; }
        //public int vote_count { get; set; }
    }

    public class Result
    {
        public string poster_path { get; set; }
        //public bool adult { get; set; }
        public string overview { get; set; }
        public string release_date { get; set; }
        public List<int> genre_ids { get; set; }
        public int id { get; set; }
        public string original_title { get; set; }
        //public string original_language { get; set; }
        public string title { get; set; }
        public string backdrop_path { get; set; }
        //public double popularity { get; set; }
        //public int vote_count { get; set; }
        //public bool video { get; set; }
        //public double vote_average { get; set; }
    }

    public class MoviesList
    {
        public int page { get; set; }
        public List<Result> results { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
    }

    public class GenresList
    {
        public List<Genre> genres { get; set; }
    }
}
