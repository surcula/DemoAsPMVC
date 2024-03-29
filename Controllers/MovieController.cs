using DemoAsPMVC.Models;
using DemoAsPMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoAsPMVC.Controllers
{
    public class MovieController : Controller
    {
        private MovieService _movieService;
        public MovieController(MovieService movieService)
        {
            _movieService = movieService;
            
        }

        public IActionResult Index()
        {           
            return View(_movieService.movieList[0]);
        }
        public IActionResult Liste()
        {
                      
            return View(_movieService.movieList);
        }

        public IActionResult Details(int id) 
        {
            Movie m = _movieService.GetById(id);            
            return View(m); 
        }
       
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
           _movieService.Create(movie);
            return RedirectToAction("Liste");
        }
        public IActionResult Edit(int id)
        {
            Movie m = _movieService.GetById(id);
            return View(m);
        }
        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            Movie m = _movieService.Update(movie);
            return RedirectToAction("Details", "Movie", new { id = m.Id });
        }
        

        public IActionResult Delete(int id)
        {
            _movieService.Delete(id);
            return RedirectToAction("Liste");
        }
    }
}
