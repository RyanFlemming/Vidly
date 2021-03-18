using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            var movies = vidlyContext.Movies.Include((m)=>m.Genre).ToList();
            return View(movies);
        }

        public IActionResult Details(int id)
        {
            if (ModelState.IsValid)
            {
                var movie = vidlyContext.Movies.Include((m)=>m.Genre).SingleOrDefault((m) => m.Id == id);
                return View(movie);
            }
            else
            {
                return View("Error", new ErrorViewModel());
            }
        }

        public IActionResult New()
        {
            IEnumerable<SelectListItem> selListGenres = from g in vidlyContext.Genres
                                                        select new SelectListItem
                                                        {
                                                            Text = g.Name,
                                                            Value = g.Id.ToString()
                                                        };
            var viewModel = new MovieFormViewModel() { Genres = selListGenres };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public IActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                vidlyContext.Add(movie);
            }
            else
            {
                var movieInDb = vidlyContext.Movies.Single((m) => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate.Date;
                movieInDb.DateAdded = DateTime.Today;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumInStock = movie.NumInStock;
            }
            vidlyContext.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }



        [Route("Movies/ByReleaseDate/{year}/{month:regex(\\d{{2}}):range(1, 12)}")]
        public IActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}
