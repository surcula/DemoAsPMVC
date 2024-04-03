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
            return View();
        }

        public IActionResult Liste()
        {
                      
            return View(_movieService.GetAll());
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
            if (ModelState.IsValid)
            {
                try
                {
                    _movieService.Create(movie);
                    return RedirectToAction("Liste");
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Home", "Error", routeValues : new {ex.Message });
                }
            }
            else
            {
                return View(movie);
            }
           
        }

        public IActionResult Edit(int id)
        {
            Movie m = _movieService.GetById(id);
            return View(m);
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            _movieService.Update(movie);
            return RedirectToAction("Liste");
        }

        public IActionResult Delete(int id)
        {
            _movieService.Delete(id);
            return RedirectToAction("Liste");
        }



    }
}
