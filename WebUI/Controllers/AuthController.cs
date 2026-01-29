using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;

        public AuthController(ITokenService tokenService, IUserService userService)
        {
            _tokenService = tokenService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            // Veritabanından kullanıcıyı sorgula
            var user = await _userService.Authenticate(model.Username, model.Password);

            if (user != null)
            {
                var token = await _tokenService.CreateTokenAsync(user.UserName);
                Response.Cookies.Append("jwt", token, new CookieOptions { HttpOnly = true });
                return RedirectToAction("Index", "Product");
            }

            ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı!");
            return View(model);
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            return RedirectToAction("Login");
        }
    }
}
