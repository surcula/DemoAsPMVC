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
            Movie m = _movieService.movieList.Where(m => m.Id == id).SingleOrDefault();
            return View(m); 
        }
       
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            movie.Id = _movieService.movieList.Max(m => m.Id) + 1;
            _movieService.movieList.Add(movie);
            return RedirectToAction("Liste");
        }
    }
}
