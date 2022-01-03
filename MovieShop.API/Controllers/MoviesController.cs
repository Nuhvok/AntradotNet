using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetMovies()
        {
            var movies = await _movieService.GetMovies();
            if (movies == null)
            {
                return NotFound();
            }
            return Ok(movies);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            var movie = await _movieService.GetMovieDetailsById(id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        [HttpGet]
        [Route("TopRated")]
        public async Task<IActionResult> GetTopRatedMovies()
        {
            throw new NotImplementedException();
            // I do not know where this data is supposed to come from.
        }

        [HttpGet]
        [Route("TopRevenue")]
        public async Task<IActionResult> GetTopRevenueMovies()
        {
            var movies = await _movieService.GetHighestGrossingMovies();
            if (!movies.Any())
            {
                return NotFound();
            }
            return Ok(movies);
        }

        [HttpGet]
        [Route("Genre/{genreId:int}")]
        public async Task<IActionResult> GetMoviesByGenre(int genreId)
        {
            var movies = await _movieService.GetMoviesByGenre(genreId);
            if (!movies.Any())
            {
                return NotFound();
            }
            return Ok(movies);
        }

        [HttpGet]
        [Route("{id:int}/Reviews")]
        public async Task<IActionResult> GetMovieReviews(int id)
        {
            throw new NotImplementedException();
        }
    }
}
