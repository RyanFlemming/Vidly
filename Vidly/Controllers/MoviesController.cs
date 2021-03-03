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
        // Getting our DbContext object
        private VidlyContext vidlyContext;

        protected override void Dispose(bool disposing)
        {
            vidlyContext.Dispose();
        }

        public MoviesController(VidlyContext vc)
        {
            vidlyContext = vc;
        }
        public IActionResult Index()
        {
            var movies = vidlyContext.Movies.ToList();
            return View(movies);
        }

        public IActionResult Details(int id)
        {
            if (ModelState.IsValid)
            {
                var movie = vidlyContext.Movies.SingleOrDefault((m) => m.Id == id);
                return View(movie);
            }
            else
            {
                return View("Error", new ErrorViewModel());
            }
        }         

        [Route("Movies/ByReleaseDate/{year}/{month:regex(\\d{{2}}):range(1, 12)}")]
        public IActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}
