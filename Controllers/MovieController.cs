using DemoAsPMVC.Models;
using Microsoft.AspNetCore.Mvc;
using AspDal.Repositories;
using DemoAsPMVC.Tools;
using AspDal.Services;
using Dal = AspDal.Entityes_DAO_Models_DTO;

namespace DemoAsPMVC.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepo _movieService;
        private readonly IPersonneRepo _personneServiceRepo;
        private readonly IMoviePersonneRepo _moviePersonneServiceRepo;
        public MovieController(IMovieRepo movieService, IPersonneRepo personneServiceRepo, IMoviePersonneRepo moviePersonneServiceRepo)
        {
            _movieService = movieService;
            _personneServiceRepo = personneServiceRepo;
            _moviePersonneServiceRepo = moviePersonneServiceRepo;
        }

        public IActionResult Liste()
        {
                      
            return View(_movieService.GetAll());
        }

        public IActionResult Details(int id) 
        {
            Movie m = _movieService.GetById(id).ToAsp();            
            return View(m); 
        }
       
        public IActionResult Create()
        {
            List<Dal.Personnes> ListeDePersonnes = _personneServiceRepo.GetAll();
            ViewBag.ListeDePersonnes = ListeDePersonnes;
            return View();
        }

        [HttpPost]
        public IActionResult Create(MovieCreateForm movieCreateForm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _movieService.Create(movieCreateForm.ToDal());
                    return RedirectToAction("Liste");
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Home", "Error", routeValues : new {ex.Message });
                }
            }
            else
            {
                return View(movieCreateForm);
            }
           
        }

        public IActionResult Edit(int id)
        {
            MovieEditForm m = _movieService.GetById(id).ToEditForm();
            return View(m);
        }

        [HttpPost]
        public IActionResult Edit(MovieEditForm movie)
        {
            _movieService.Update(movie.ToDal());
            return RedirectToAction("Liste");
        }

        public IActionResult Delete(int id)
        {
            _movieService.Delete(id);
            return RedirectToAction("Liste");
        }



    }
}
