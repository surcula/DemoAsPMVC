using DemoAsPMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoAsPMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Toto() 
        {  
            Person person = new Person { Id = 1 , Description = "Une petite description", Name = "Toto", Phone = " 9999"};
            return View(person); 
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
