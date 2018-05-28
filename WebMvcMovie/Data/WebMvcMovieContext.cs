using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebMvcMovie.Models;

namespace WebMvcMovie.Models
{
    public class WebMvcMovieContext : DbContext
    {
        public WebMvcMovieContext (DbContextOptions<WebMvcMovieContext> options)
            : base(options)
        {
        }

        public DbSet<WebMvcMovie.Models.Movie> Movie { get; set; }

        public DbSet<WebMvcMovie.Models.CheckboxModel> CheckboxModel { get; set; }
    }
}
