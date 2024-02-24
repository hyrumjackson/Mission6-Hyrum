using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission6_Hyrum.Models;

namespace Mission6_Hyrum.Controllers
{
	public class HomeController : Controller
	{
        private JoelHiltonMovieCollectionContext _context;

        public HomeController(JoelHiltonMovieCollectionContext temp) 
        {
            _context = temp;
        }

		public IActionResult Index()
		{
			return View();
		}

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddMovie", new Movie());
        }

        [HttpPost]
        public IActionResult AddMovie(Movie response)
        {

            if (response.Director == null)
            {
                response.Director = "";
            }

            if (response.Rating == null)
            {
                response.Rating = "";
            }

            if (response.LentTo == null)
            {
                response.LentTo = "";
            }

            if (response.Notes == null)
            {
                response.Notes = "";
            }

            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();

                return View("Confirmation", response);
            }
            else
            {
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();

                return View(response);
            }
        }

        public IActionResult Movies()
        {
            var movies = _context.Movies
                .Include(m => m.Category)
                .OrderByDescending(x => x.Year)
                .ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddMovie", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movie updatedInfo)
        {
            if (updatedInfo.Director == null)
            {
                updatedInfo.Director = "";
            }

            if (updatedInfo.Rating == null)
            {
                updatedInfo.Rating = "";
            }

            if (updatedInfo.LentTo == null)
            {
                updatedInfo.LentTo = "";
            }

            if (updatedInfo.Notes == null)
            {
                updatedInfo.Notes = "";
            }

            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("Movies");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("Movies");
        }
    }
}
