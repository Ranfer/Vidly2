using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;
using Vidly2.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        public ViewResult Index()
        {
            var movieList = GetMovies();

            return View(movieList);
        }

        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            //return View(movie);
            //return Content("Hola");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });

            //not use this
            //ViewData["Movie"] = movie;
            //ViewBag.Movie = movie;

            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" },
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            //use this
            return View(viewModel);
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")] //attribute routing
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year+"/"+month);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Shrek" },
                new Movie { Id = 2, Name = "Wall-e" }
            };
        }
    }
}