using System.ComponentModel.DataAnnotations;

namespace Mission6_Hyrum.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Please enter the movie title.")]
        public string Title { get; set; }

        [Range(1888, 2100, ErrorMessage = "Year must be between 1888 and 2100.")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Please enter the director's name.")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Please select a rating.")]
        public string Rating { get; set; }

        public bool? Edited { get; set; }

        public string? LentTo { get; set; }

        [MaxLength(25, ErrorMessage = "Notes can't be more than 25 characters.")]
        public string? Notes { get; set; }
    }
}
