using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazorPagesMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly MovieContext _context;

        public IndexModel(MovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }
        public SelectList Genres;
        public string MovieGenre { get; set; }

        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public async Task OnGetAsync(string movieGenre, string searchString)
        {
            // Use LINQ to get list of genres.
            // Gee - Notice external data source query 
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;
            // Gee - Movies list.
            var movies = from m in _context.Movie
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                // Gee - Filter movies by name.
                movies = movies.Where(s => s.Title.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(movieGenre))
            {
                // Gee - Filter movies by genre.
                movies = movies.Where(x => x.Genre == movieGenre);
            }

            // Gee - Genres displayed by the DDL
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Movie = await movies.ToListAsync();
        }

        /*
         * GeeNote:
         * When OnGet returns void or OnGetAsync returns Task, NO RETURN METHOD IS USED. 
         * When the return type is IActionResult or Task<IActionResult>, A RETURN STATEMENT 
         * MUST BE PROVIDED. For example, the Pages/Movies/Create.cshtml.cs OnPostAsync method:
         */

    }
}
