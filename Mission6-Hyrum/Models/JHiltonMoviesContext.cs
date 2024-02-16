using Microsoft.EntityFrameworkCore;

namespace Mission6_Hyrum.Models
{
	public class JHiltonMoviesContext : DbContext
	{
		public JHiltonMoviesContext(DbContextOptions<JHiltonMoviesContext> options) : base (options)
		{

		}

		public DbSet<Movie> Movies { get; set; }
	}
}
