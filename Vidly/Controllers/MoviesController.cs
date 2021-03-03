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
