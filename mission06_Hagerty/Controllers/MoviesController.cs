using Microsoft.AspNetCore.Mvc;
using mission06_Hagerty.Models;
using System.Linq;

namespace mission06_Hagerty.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _context;

        public MoviesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var movies = _context.Movies.ToList();
            return View(movies);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.MovieId == id);
            if (movie == null) return NotFound();

            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                var existingMovie = _context.Movies.Find(movie.MovieId);
                if (existingMovie != null)
                {
                    // Update all fields manually
                    existingMovie.Title = movie.Title;
                    existingMovie.Category = movie.Category;
                    existingMovie.Year = movie.Year;
                    existingMovie.Director = movie.Director;
                    existingMovie.Rating = movie.Rating;
                    existingMovie.Edited = movie.Edited;
                    existingMovie.LentTo = movie.LentTo;
                    existingMovie.Notes = movie.Notes;

                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(movie); // If model is invalid, return the form with errors
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.MovieId == id);
            if (movie == null) return NotFound();

            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.MovieId == id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.MovieId == id);
            if (movie == null) return NotFound();

            return View(movie);
        }
    }
}