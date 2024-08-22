using JokesApp.Models;
using JokesApp.Sevice;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Xml.Linq;

namespace JokesApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WeatherAPIService _weatherAPIService;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _weatherAPIService = new WeatherAPIService();
        }

        public IActionResult Index()
        {
            ViewBag.modelsList = _weatherAPIService.getWeatherModels();
            return View();
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
