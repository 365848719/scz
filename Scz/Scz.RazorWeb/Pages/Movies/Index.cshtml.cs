using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Scz.RazorWeb.Models;

namespace Scz.RazorWeb.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly Scz.RazorWeb.Models.RazorPagesMovieContext _context;

        public IndexModel(Scz.RazorWeb.Models.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }
    }
}
