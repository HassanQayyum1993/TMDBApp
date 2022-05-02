using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.IO;
using System.Text;
using tmdbapi.Models;
using System.Text.Json;
using tmdbapi.Repos.IRepos;


namespace tmdbapi.Repos
{
    public class MovieHelper : IMovieHelper
    {
        private readonly string apiKey = "api_key=08b02adc427e8de4e0a283390f980970";
        public string Get(string requestURL)
        {

            HttpWebRequest apiRequest = WebRequest.Create(requestURL) as HttpWebRequest;

            string apiResponse = "";
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                            | SecurityProtocolType.Tls11
                            | SecurityProtocolType.Tls12;
            using (HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                apiResponse = reader.ReadToEnd();
            }

            return apiResponse;
        }
        public MovieDetails GetMovieDetails(int movieId)
        {
            string requestURL = "https://api.themoviedb.org/3/movie/" + movieId + "?" + this.apiKey;
            string apiResponse = this.Get(requestURL);
            var resultObj = JsonSerializer.Deserialize<MovieDetails>(apiResponse);
            return resultObj;
        }
        private List<string> CreatePosterImageUrls(ImageGallery images)
        {
            List<string> resultList = new List<string>();

            foreach (var item in images.posters)
            {
                resultList.Add("http://image.tmdb.org/t/p/w500" + item.file_path);
            }
            return resultList;
        }
        public ImageGallery GetMovieImages(int movieId)
        {
            List<string> resultList = new List<string>();
            string requestURL = "https://api.themoviedb.org/3/movie/" + movieId + "/images" + "?" + this.apiKey;
            string apiResponse = this.Get(requestURL);
            var resultObj = JsonSerializer.Deserialize<ImageGallery>(apiResponse);
            return resultObj;
        }
        public MovieCast GetMovieCast(int movieId)
        {
            List<string> resultList = new List<string>();
            string requestURL = "https://api.themoviedb.org/3/movie/" + movieId + "/credits" + "?" + this.apiKey;
            string apiResponse = this.Get(requestURL);
            var resultObj = JsonSerializer.Deserialize<MovieCast>(apiResponse);
            return resultObj;
        }
        public MoviesList GetTopMoviesList(int pageNumber)
        {
            List<string> resultList = new List<string>();
            string requestURL = "https://api.themoviedb.org/3/movie/top_rated" + "?" + this.apiKey + "&language=en-US&page=" + pageNumber;
            string apiResponse = this.Get(requestURL);
            var resultObj = JsonSerializer.Deserialize<MoviesList>(apiResponse);
            return resultObj;
        }
        public MoviesList GetPaginatedMoviesListWithSearch(string searchKeyWord, int genreId, int pageNumber)
        {
            List<string> resultList = new List<string>();
            string requestURL = "https://api.themoviedb.org/3/search/movie" + "?" + this.apiKey + "&language=en-US&query=" + searchKeyWord + "&with_genres=" + genreId + "&page=" + pageNumber + "&include_adult=false";
            string apiResponse = this.Get(requestURL);
            var resultObj = JsonSerializer.Deserialize<MoviesList>(apiResponse);
            return resultObj;
        }
        public MoviesList GetPaginatedMoviesListByGenre(int genreId, int pageNumber)
        {
            List<string> resultList = new List<string>();
            string requestURL = "https://api.themoviedb.org/3/discover/movie" + "?" + this.apiKey + "&language=en-US&with_genres=" + genreId + "&page=" + pageNumber + "&include_adult=false";
            string apiResponse = this.Get(requestURL);
            var resultObj = JsonSerializer.Deserialize<MoviesList>(apiResponse);
            return resultObj;
        }
        public GenresList GetMoviesGenreList()
        {
            List<string> resultList = new List<string>();
            string requestURL = "https://api.themoviedb.org/3/genre/movie/list?" + this.apiKey + "&language=en-US";
            string apiResponse = this.Get(requestURL);
            var resultObj = JsonSerializer.Deserialize<GenresList>(apiResponse);
            return resultObj;
        }
    }
}
