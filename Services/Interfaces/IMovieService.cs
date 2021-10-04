using MyMovies.Dtos;
using System.Collections.Generic;

namespace MyMovies.Services.Interfaces
{
    public interface IMovieService
    {
        IEnumerable<MovieDto> GetAll();
        MovieDto Get(int id);
        int Create(CreateMovieDto dto);
        bool Delete(int id);
        bool Update(int id, CreateMovieDto dto);
    }
}
