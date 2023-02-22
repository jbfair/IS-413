using HiltonMovies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HiltonMovies.Controllers
{
    public class HomeController : Controller
    {
        private MovieDatabaseContext _MovieContext { get; set; }
        public HomeController(MovieDatabaseContext x)
        {
            _MovieContext = x;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcast()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        [HttpGet]
        public IActionResult EnterMovie()
        {
            ViewBag.Categories = _MovieContext.categories.ToList();
            return View(new MovieModel());
        }

        [HttpPost]
        public IActionResult EnterMovie(MovieModel mm)
        {
            if (ModelState.IsValid)
            {
                _MovieContext.Add(mm);
                _MovieContext.SaveChanges();
                return View("Confirm");
            }
            else
            {
                ViewBag.Categories = _MovieContext.categories.ToList();
                return View();
            }
        }

        public IActionResult Movies()
        {
            var entries = _MovieContext.responses.Include(x => x.Category).OrderBy(x => x.Category).ToList();
            return View(entries);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = _MovieContext.categories.ToList();

            var movie = _MovieContext.responses.Single(x => x.MovieID == id);

            return View("EnterMovie", movie);
        }

        [HttpPost]
        public IActionResult Edit(MovieModel m)
        {
            _MovieContext.Update(m);
            _MovieContext.SaveChanges();
            return RedirectToAction("Movies");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {

            var entry = _MovieContext.responses.Single(x => x.MovieID == id);
            return View(entry);
            
        }

        [HttpPost]
        public IActionResult Delete(MovieModel mm)
        {
            _MovieContext.responses.Remove(mm);
            _MovieContext.SaveChanges();
            return RedirectToAction("Movies");
        }

    }
}
