using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // account/register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterRequestModel userRegisterRequestModel)
        {
            // save the data in database and reutn to login page
            var user = await _accountService.RegisterUser(userRegisterRequestModel);

            if (user == 0)
            {
                // email already exists
                return View();
            }
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginRequestModel loginRequestModel)
        {
            var user = _accountService.ValidateUser(loginRequestModel);
            if(user == null)
            {
                // show error message

            }

            return View();
        }
    }
}
