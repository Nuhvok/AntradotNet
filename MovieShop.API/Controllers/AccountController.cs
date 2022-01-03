using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;

        public AccountController(IAccountService accountService, IUserService userService)
        {
            _accountService = accountService;
            _userService = userService;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> CheckUser(int id)
        {
            var user = await _accountService.CheckUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet]
        [Route("")]

        public async Task<IActionResult> Profile()
        {
            // We have not gone over authentication, so I do not know how to get the user's login data 
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("")]

        public async Task<IActionResult> EditProfile([FromBody] UserDetailsModel model)
        {
            var user = await _userService.EditUserProfile(model);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        [Route("login")]

        public async Task<IActionResult> Login([FromBody] LoginRequestModel model)
        {
            var user = await _accountService.ValidateUser(model);
            if(user == null)
            {
                return Unauthorized("Wrong Email/Password");
            }
            return Ok(user);
        }
    }
}
