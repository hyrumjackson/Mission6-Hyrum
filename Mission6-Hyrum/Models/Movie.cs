using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6_Hyrum.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Please select a category.")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [Required(ErrorMessage = "Please enter the movie title.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter the movie year.")]
        [Range(1888, 2100, ErrorMessage = "Year must be between 1888 and 2100.")]
        public int Year { get; set; }

        public string? Director { get; set; }

        public string? Rating { get; set; }

        [Required(ErrorMessage = "Please specify if the movie has been edited.")]
        public bool Edited { get; set; }

        public string? LentTo { get; set; }

        [Required(ErrorMessage = "Please specify if the movie is copied to Plex.")]
        public bool CopiedToPlex { get; set; }

        [MaxLength(25, ErrorMessage = "Notes can't be more than 25 characters.")]
        public string? Notes { get; set; }
    }
}
