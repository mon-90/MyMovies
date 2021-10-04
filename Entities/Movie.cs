using System;
using System.ComponentModel.DataAnnotations;

namespace MyMovies.Entities
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Range(1900, 2100)]
        public int? ProductionYear { get; set; }
    }
}
