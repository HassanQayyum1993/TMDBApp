using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.IO;
using System.Text;
using tmdbapi.Models;
using System.Text.Json;
using tmdbapi.Repos.IRepos;
using System.Linq;


namespace tmdbapi.Repos

{
    public class MovieRepository: IMovieRepository
    {
        private readonly IMovieHelper _movieHelper;

        public MovieRepository(IMovieHelper movieHelper)
        {
            _movieHelper = movieHelper;
        }
        public async Task<MovieDetails> GetMovieDetailsAsync(long movieId)
        {
            return await Task.FromResult(_movieHelper.GetMovieDetails(movieId));
        }

        public async Task<ImageGallery> GetMovieImagePathsAsync(long movieId)
        {

            return await Task.FromResult(_movieHelper.GetMovieImages(movieId));
        }

        public async Task<MovieCast> GetMovieCastAsync(long movieId)
        {
            return await Task.FromResult(_movieHelper.GetMovieCast(movieId));
        }

        public async Task<MoviesList> GetTopMoviesListAsync(long pageNumber)
        {
            return await Task.FromResult(_movieHelper.GetTopMoviesList(pageNumber));
        }

        public async Task<MoviesList> GetPaginatedMoviesListWithSearchAsync(string searchKeyWord,long pageNumber)
        {
            return await Task.FromResult(_movieHelper.GetPaginatedMoviesListWithSearch(searchKeyWord, pageNumber));
        }
        public async Task<GenresList> GetMoviesGenreListAsync()
        {
            return await Task.FromResult(_movieHelper.GetMoviesGenreList());
        }
    }
}
