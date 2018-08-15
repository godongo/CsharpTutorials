using Microsoft.EntityFrameworkCore;

namespace WebMvcMovie.Models
{
    public class WebMvcMovieContext : DbContext
    {
        public WebMvcMovieContext (DbContextOptions<WebMvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; }

        public DbSet<CheckboxModel> CheckboxModel { get; set; }
    }
}
