using System;
using System.ComponentModel.DataAnnotations;

namespace MyMovies.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? ProductionYear { get; set; }
    }
}
