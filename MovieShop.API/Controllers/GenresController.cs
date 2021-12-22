using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetGenres()
        {
            var genres = await _genreService.GetAllGenres();

            if(!genres.Any())
            {
                return NotFound();
            }

            return Ok(genres);
        }
    }
}
