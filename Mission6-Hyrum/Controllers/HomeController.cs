using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission6_Hyrum.Models;

namespace Mission6_Hyrum.Controllers
{
	public class HomeController : Controller
	{
        private JHiltonMoviesContext _context;

        public HomeController(JHiltonMoviesContext temp) 
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
        public IActionResult Movies()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Movies(Movie response)
        {
			if (response.LentTo == null)
			{
				response.LentTo = "";
			}

			if (response.Notes == null)
			{
				response.Notes = "";
			}

			if (response.Edited == null)
			{
				response.Edited = false;
			}

			_context.Movies.Add(response);
            _context.SaveChanges();

            return View("Confirmation", response);
        }
    }
}
