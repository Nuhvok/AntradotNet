using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using MovieShopMCV.Models;
using System.Diagnostics;

namespace MovieShopMCV.Controllers
{
    public class HomeController : Controller
    {
        private MovieService _movieService;

        public HomeController(ILogger<HomeController> logger)
        {
            _movieService = new MovieService();
        }

        public IActionResult Index()
        {
            var movieCards = _movieService.GetHighestGrossingMovies();
            return View(movieCards);
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