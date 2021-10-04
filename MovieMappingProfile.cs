using AutoMapper;
using MyMovies.Dtos;
using MyMovies.Entities;

namespace MyMovies
{
    public class MovieMappingProfile : Profile
    {
        public MovieMappingProfile()
        {
            CreateMap<Movie, MovieDto>()
                .ReverseMap();

            CreateMap<Movie, CreateMovieDto>()
                .ReverseMap();
        }
    }
}
