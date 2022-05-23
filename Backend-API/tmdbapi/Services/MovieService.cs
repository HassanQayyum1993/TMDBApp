﻿using tmdbapi.Repos.IRepos;
using tmdbapi.Services.IServices;
using tmdbapi.ViewModels;

namespace tmdbapi.Services
{
    public class MovieService:IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public async Task<IResponse> GetMovieDetailsAsync(int movieId)
        {
            var movieDetails = await _movieRepository.GetMovieDetailsAsync(movieId);
            movieDetails.poster_path = "http://image.tmdb.org/t/p/w500" + movieDetails.poster_path;
            var movieImagePaths = await _movieRepository.GetMovieImagePathsAsync(movieId);
            var movieImageUrls = movieImagePaths.posters.Select(e => "http://image.tmdb.org/t/p/w500" + e.file_path).ToList();
            var movieCast = await _movieRepository.GetMovieCastAsync(movieId);

            return new MovieDetailsViewModel { Status = "Success", Message = "", MovieDetails = movieDetails, MovieImageUrls = movieImageUrls, MovieCast = movieCast };

        }
        public async Task<IResponse> GetTopMovieListAsync(int pageNumber)
        {
            var topMoviesList = await _movieRepository.GetTopMoviesListAsync(pageNumber);
            topMoviesList.results.ForEach(c => { c.poster_path = "http://image.tmdb.org/t/p/w500" + c.poster_path; });
            return new MovieListViewModel { Status="Success", Message="", MovieList = topMoviesList };
        }
        public async Task<IResponse> GetPaginatedMoviesListWithSearchAsync(string searchKeyWord, int genreId, int pageNumber)
        {
            var moviesList = await _movieRepository.GetPaginatedMoviesListWithSearchAsync(searchKeyWord, genreId, pageNumber);
            moviesList.results = moviesList.results.Where(c => c.title.ToUpper().Contains(searchKeyWord.ToUpper())).ToList();
            if (genreId > 0)
            {
                moviesList.results = moviesList.results.Where(c => c.genre_ids.Contains(genreId)).ToList();
            }
            moviesList.results.ForEach(c => { c.poster_path = "http://image.tmdb.org/t/p/w500" + c.poster_path; });
            return new MovieListViewModel { Status = "Success", Message = "", MovieList = moviesList };
        }
        public async Task<IResponse> GetPaginatedMoviesListByGenreAsync(int genreId, int pageNumber)
        {
            var moviesList = await _movieRepository.GetPaginatedMoviesListByGenreAsync(genreId, pageNumber);
            moviesList.results.ForEach(c => { c.poster_path = "http://image.tmdb.org/t/p/w500" + c.poster_path; });
            return new MovieListViewModel { Status = "Success", Message = "", MovieList = moviesList };
        }
        public async Task<IResponse> GetMoviesGenreListAsync()
        {
            var genreList = await _movieRepository.GetMoviesGenreListAsync();
            return new GenreListViewModel { Status = "Success", Message = "", GenreList = genreList };
        }
    }
}