using AutoMapper;
using tmdbapi.Models;
using tmdbapi.ViewModels;

namespace tmdbapi.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<MovieList, MovieListDetailsViewModel>();
            //CreateMap<MovieListDetailsViewModel, MovieList>();
            CreateMap<Result, ResultViewModel>();
            CreateMap<MovieDetails, MovieDetailsViewModel>();
            //CreateMap<MovieDetailsViewModel, MovieDetails>();
            //CreateMap<GenreListViewModel, GenreList>().ForMember(dest => dest.genres, opt => opt.MapFrom(src => src.GenreList)); ;
            CreateMap<GenreList, GenreListViewModel>().ForMember(dest => dest.GenreList, opt => opt.MapFrom(src => src.genres)); ;
            //CreateMap<GenreViewModel, Genre>();
            CreateMap<Genre, GenreViewModel>();
            //CreateMap<MovieCast, MovieCastViewModel>();
            CreateMap<MovieCast, MovieCastViewModel>();
            CreateMap<CastDetails, CastDetailsViewModel>();
            //CreateMap<CastDetailsViewModel, CastDetails>();
            CreateMap<Comment, CommentDetailsViewModel>();
            CreateMap<CommentList, CommentListViewModel>();
        }
    }
}
