using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationMVC.Models.ViewModels;

namespace WebApplicationMVC.Controllers
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

        public IActionResult Privacy()
        {
            ViewData["Texto"] = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                "Donec sed imperdiet libero. Cras mauris turpis, feugiat eu aliquam eget, accumsan ac libero." +
                " Aliquam at turpis semper, cursus velit eget, interdum enim. Curabitur posuere leo tincidunt, euismod nisi nec, pellentesque ligula." +
                " Nunc euismod, tellus pellentesque dignissim porttitor, tortor lacus laoreet urna, semper tristique velit metus quis elit. " +
                "Aliquam egestas rhoncus dolor at sollicitudin. Cras ut nulla euismod, tempus enim at, semper orci. " +
                "Curabitur eu dolor at ipsum luctus volutpat ut at justo. Donec justo libero, rutrum ut auctor sit amet, pretium non nisl.";
            return View(); 
            // gera um ViewResult que sofre um facilmente polimorfismo para a IActionResult
        }

        public IActionResult Departments()
        {
           return View();
            // gera um ViewResult que sofre um facilmente polimorfismo para a IActionResult
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
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