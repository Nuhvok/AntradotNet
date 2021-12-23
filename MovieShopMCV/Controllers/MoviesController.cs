using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MovieShopMVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<IActionResult> Details(int id)
        {
            //var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            // call the MovieService wuth DI to get the movie details information
            //var movieDetails = await _movieService.GetMovieDetailsById(id, userId);
            var movieDetails = await _movieService.GetMovieDetailsById(id);

            // add here 


            return View(movieDetails);
        }
    }
}
