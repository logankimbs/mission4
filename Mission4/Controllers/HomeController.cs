using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission4.Models;

namespace Mission4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private MoviesContext _moviesContext { get; set; }

        public HomeController(ILogger<HomeController> logger, MoviesContext moviesContext)
        {
            _logger = logger;
            _moviesContext = moviesContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Podcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Movies()
        {
            ViewBag.Categories = _moviesContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Movies(MoviesModel res)
        {
            if (ModelState.IsValid)
            {
                _moviesContext.Add(res);
                _moviesContext.SaveChanges();

                return View("Confirmation", res);
            }
            else
            {
                ViewBag.Categories = _moviesContext.Categories.ToList();

                return View(res);
            }
        }

        [HttpGet]
        public IActionResult ViewMovies()
        {
            var movies = _moviesContext.Responses
                .Include(x => x.Category)
                .ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = _moviesContext.Categories.ToList();
            var movie = _moviesContext.Responses.Single(x => x.MovieId == id);

            return View("Movies", movie);
        }

        [HttpPost]
        public IActionResult Edit(MoviesModel res)
        {
            _moviesContext.Update(res);
            _moviesContext.SaveChanges();

            return RedirectToAction("ViewMovies");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = _moviesContext.Responses.Single(x => x.MovieId == id);

            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(MoviesModel res)
        {
            _moviesContext.Responses.Remove(res);
            _moviesContext.SaveChanges();

            return RedirectToAction("ViewMovies");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
