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
    public class MovieRepository : IMovieRepository
    {
        private readonly IMovieHelper _movieHelper;

        public MovieRepository(IMovieHelper movieHelper)
        {
            _movieHelper = movieHelper;
        }
        public async Task<MovieDetails> GetMovieDetailsAsync(int movieId)
        {
            return await Task.FromResult(_movieHelper.GetMovieDetails(movieId));
        }

        public async Task<ImageGallery> GetMovieImagePathsAsync(int movieId)
        {
            return await Task.FromResult(_movieHelper.GetMovieImages(movieId));
        }

        public async Task<MovieCast> GetMovieCastAsync(int movieId)
        {
            return await Task.FromResult(_movieHelper.GetMovieCast(movieId));
        }

        public async Task<MoviesList> GetTopMoviesListAsync(int pageNumber)
        {
            return await Task.FromResult(_movieHelper.GetTopMoviesList(pageNumber));
        }

        public async Task<MoviesList> GetPaginatedMoviesListWithSearchAsync(string searchKeyWord, int genreId, int pageNumber)
        {
            return await Task.FromResult(_movieHelper.GetPaginatedMoviesListWithSearch(searchKeyWord, genreId, pageNumber));
        }
        public async Task<MoviesList> GetPaginatedMoviesListByGenreAsync(int genreId, int pageNumber)
        {
            return await Task.FromResult(_movieHelper.GetPaginatedMoviesListByGenre(genreId, pageNumber));
        }
        public async Task<GenresList> GetMoviesGenreListAsync()
        {
            return await Task.FromResult(_movieHelper.GetMoviesGenreList());
        }
    }
}
