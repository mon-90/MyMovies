using System;
using System.ComponentModel.DataAnnotations;

namespace MyMovies.Dtos
{
    public class CreateMovieDto
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Range(1900, 2100)]
        public int? ProductionYear { get; set; }
    }
}
