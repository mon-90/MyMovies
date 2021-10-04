using AutoMapper;
using MyMovies.Dtos;
using MyMovies.Entities;
using MyMovies.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MyMovies.Services
{
    public class MovieService : IMovieService
    {
        private readonly MyMoviesDbContext _dbContext;
        private readonly IMapper _mapper;

        public MovieService(MyMoviesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<MovieDto> GetAll()
        {
            var movies = _dbContext
                .Movies
                .ToList();

            if (movies is null)
                return null;

            var moviesDto = _mapper.Map<List<MovieDto>>(movies);

            return moviesDto;
        }

        public MovieDto Get(int id)
        {
            var movie = _dbContext
                .Movies
                .FirstOrDefault(m => m.Id == id);

            if (movie is null)
                return null;

            var movieDto = _mapper.Map<MovieDto>(movie);

            return movieDto;
        }

        public int Create(CreateMovieDto dto)
        {
            var movie = _mapper.Map<Movie>(dto);

            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();

            return movie.Id;
        }

        public bool Delete(int id)
        {
            var movie = _dbContext
                .Movies
                .FirstOrDefault(m => m.Id == id);

            if (movie is null)
                return false;

            _dbContext.Movies.Remove(movie);
            _dbContext.SaveChanges();

            return true;
        }

        public bool Update(int id, CreateMovieDto dto)
        {
            var movie = _dbContext
                .Movies
                .FirstOrDefault(m => m.Id == id);

            if (movie is null)
                return false;

            movie.Title = dto.Title;
            movie.ProductionYear = dto.ProductionYear;

            _dbContext.SaveChanges();

            return true;
        }
    }
}
