using Microsoft.EntityFrameworkCore;

namespace Mission6_Hyrum.Models
{
	public class JoelHiltonMovieCollectionContext : DbContext
	{
		public JoelHiltonMovieCollectionContext(DbContextOptions<JoelHiltonMovieCollectionContext> options) : base (options)
		{

		}

		public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
