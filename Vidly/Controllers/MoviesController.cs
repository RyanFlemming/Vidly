using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        public IActionResult Index()
        {
            var movies = new List<Movie>
            {
                new Movie {Name = "Shrek"},
                new Movie {Name = "Wall-e"}
            };
            return View(movies);
        }

        public IActionResult Details()
        {
            // Do work
            return View();
        }         

        [Route("Movies/ByReleaseDate/{year}/{month:regex(\\d{{2}}):range(1, 12)}")]
        public IActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}
