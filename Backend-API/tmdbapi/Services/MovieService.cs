#nullable disable

using AutoMapper;
using tmdbapi.Constants;
using tmdbapi.Models;
using tmdbapi.Repos.IRepos;
using tmdbapi.Services.IServices;
using tmdbapi.ViewModels;

namespace tmdbapi.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }
        public async Task<IResponse> GetMovieDetailsAsync(int movieId)
        {
            try
            {
                var movieDetails = await _movieRepository.GetMovieDetailsAsync(movieId);
                movieDetails.poster_path = "http://image.tmdb.org/t/p/w500" + movieDetails.poster_path;
                var movieImagePaths = await _movieRepository.GetMovieImagePathsAsync(movieId);
                var movieImageUrls = movieImagePaths.posters.Select(e => "http://image.tmdb.org/t/p/w500" + e.file_path).ToList();
                var movieCast = await _movieRepository.GetMovieCastAsync(movieId);

                return new MovieViewModel { Status = Statuses.Success, Message = "", MovieDetails = _mapper.Map<MovieDetailsViewModel>(movieDetails), MovieImageUrls = movieImageUrls, MovieCast = _mapper.Map<MovieCastViewModel>(movieCast) };
            }
            catch(Exception ex)
            {
                return new Response { Status = Statuses.Error, Message = "Unable to get movie details!" };
            }
        }
        public async Task<IResponse> GetTopMovieListAsync(int pageNumber)
        {
            try
            {
                var topMoviesList = await _movieRepository.GetTopMoviesListAsync(pageNumber);
                topMoviesList.results.ForEach(c => { c.poster_path = "http://image.tmdb.org/t/p/w500" + c.poster_path; });
                return new MovieVIewModels { Status = Statuses.Success, Message = "", MovieList = _mapper.Map<MovieListDetailsViewModel>(topMoviesList)};
            }
            catch(Exception ex)
            {
                return new Response { Status = Statuses.Error, Message = "Unable to get top movies!" };
            }
        }
        public async Task<IResponse> GetPaginatedMoviesListWithSearchAsync(string searchKeyWord, int genreId, int pageNumber)
        {
            try
            {
                var moviesList = await _movieRepository.GetPaginatedMoviesListWithSearchAsync(searchKeyWord, genreId, pageNumber);
                moviesList.results = moviesList.results.Where(c => c.title.ToUpper().Contains(searchKeyWord.ToUpper())).ToList();
                if (genreId > 0)
                {
                    moviesList.results = moviesList.results.Where(c => c.genre_ids.Contains(genreId)).ToList();
                }
                moviesList.results.ForEach(c => { c.poster_path = "http://image.tmdb.org/t/p/w500" + c.poster_path; });
                return new MovieVIewModels { Status = Statuses.Success, Message = "", MovieList = _mapper.Map<MovieListDetailsViewModel>(moviesList) };
            }
            catch
            {
                return new Response { Status = Statuses.Error, Message = "Unable to get searched movies!" };
            }
        }
        public async Task<IResponse> GetPaginatedMoviesListByGenreAsync(int genreId, int pageNumber)
        {
            try
            {
                var moviesList = await _movieRepository.GetPaginatedMoviesListByGenreAsync(genreId, pageNumber);
                moviesList.results.ForEach(c => { c.poster_path = "http://image.tmdb.org/t/p/w500" + c.poster_path; });
                return new MovieVIewModels { Status = Statuses.Success, Message = "", MovieList = _mapper.Map<MovieListDetailsViewModel>(moviesList) };
            }
            catch
            {
                return new Response { Status = Statuses.Error, Message = "Unable to get movies by genre!" };
            }
        }
        public async Task<IResponse> GetMoviesGenreListAsync()
        {
            try
            {
                var genreList = await _movieRepository.GetMoviesGenreListAsync();
                var genreListViewModel = _mapper.Map<GenreListViewModel>(genreList);
                genreListViewModel.Status = Statuses.Success;
                genreListViewModel.Message = "";
                return genreListViewModel;
            }
            catch
            {
                return new Response { Status = Statuses.Error, Message = "Unable to get genre list!" };
            }
        }
    }
}
