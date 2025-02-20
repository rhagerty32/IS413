using Microsoft.AspNetCore.Mvc;
using mission06_Hagerty.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace mission06_Hagerty.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _context;

        // Constructor that initializes the database context
        public MoviesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Displays the list of movies
        [HttpGet]
        public IActionResult Index()
        {
            // Retrieves all movies from the database, including their related Category
            var movies = _context.Movies.Include(m => m.Category).ToList();

            return View(movies);
        }

        // GET: Displays the form to create a new movie
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        // GET: A custom page unrelated to movies
        public IActionResult GetToKnowJoel()
        {
            return View();
        }

        // POST: Handles form submission to create a new movie
        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid) // Ensures the model is valid before saving
            {
                _context.Movies.Add(movie); // Adds the movie to the database
                _context.SaveChanges(); // Commits changes to the database
                return RedirectToAction("Index"); // Redirects to the movie list
            }
            return View(movie); // Returns form with validation errors if invalid
        }

        // GET: Displays the edit form for a specific movie
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.MovieId == id);
            if (movie == null) return NotFound(); // Returns 404 if movie not found

            return View(movie);
        }

        // POST: Handles form submission for editing an existing movie
        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid) // Ensures the model is valid before updating
            {
                var existingMovie = _context.Movies.Find(movie.MovieId);
                if (existingMovie != null)
                {
                    // Updates all fields manually
                    existingMovie.Title = movie.Title;
                    existingMovie.CategoryId = movie.CategoryId;
                    existingMovie.Year = movie.Year;
                    existingMovie.Director = movie.Director;
                    existingMovie.Rating = movie.Rating;
                    existingMovie.Edited = movie.Edited;
                    existingMovie.LentTo = movie.LentTo;
                    existingMovie.Notes = movie.Notes;

                    _context.SaveChanges(); // Saves changes to the database
                    return RedirectToAction("Index"); // Redirects to the movie list
                }
            }
            return View(movie); // Returns form with validation errors if invalid
        }

        // GET: Displays the delete confirmation page for a specific movie
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.MovieId == id);
            if (movie == null) return NotFound(); // Returns 404 if movie not found

            return View(movie); // Returns the Delete.cshtml view
        }

        // POST: Confirms and processes the deletion of a movie
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.MovieId == id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }
            return RedirectToAction("Index"); // Redirect back to the Movies page
        }

        // GET: Displays details of a specific movie
        [HttpGet]
        public IActionResult Details(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.MovieId == id);
            if (movie == null) return NotFound(); // Returns 404 if movie not found

            return View(movie);
        }
    }
}