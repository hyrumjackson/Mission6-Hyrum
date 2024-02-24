using System.ComponentModel.DataAnnotations;

namespace Mission6_Hyrum.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
