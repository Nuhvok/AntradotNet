using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("{userId:int}/Purchases")]
        //public async Task<IActionResult> Purchases()
        public async Task<IActionResult> Purchases(int userId)
        {
            //var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var purchases = await _userService.GetUserPurchasedMovies(userId);
            if(purchases == null)
            {
                return NotFound();
            }
            return Ok(purchases);
        }

        [HttpGet]
        [Route("{userId:int}/Favorites")]
        //public async Task<IActionResult> Favorites()
        public async Task<IActionResult> Favorites(int userId)
        {
            //var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var favorites = await _userService.GetUserFavoritedMovies(userId);
            if (favorites == null)
            {
                return NotFound();
            }
            return Ok(favorites);
        }

        [HttpGet]
        [Route("{userId:int}/Profile")]
        //public async Task<IActionResult> Profile()
        public async Task<IActionResult> Profile(int userId)
        {
            //var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var userDetails = await _userService.GetUserDetails(userId);
            if (userDetails == null)
            {
                return NotFound();
            }
            return Ok(userDetails);
        }

        [HttpPost]
        [Route("Purchase")]
        public async Task<IActionResult> Purchase([FromBody] MoviePurchaseDetailsModel purchase)
        {
            var purchaseOut = await _userService.PurchaseMovie(purchase);
            if (purchaseOut == null)
            {
                return StatusCode(500, "Internal Server Error");
            }
            // I wasnt sure how to use the created method here
            return Ok(purchaseOut);
        }
    }
}
