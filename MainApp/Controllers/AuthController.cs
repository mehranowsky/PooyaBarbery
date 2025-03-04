using AutoMapper;
using MainApp.Models.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Models;
using ServiceLayer.Services;
using System.Security.Claims;

namespace MainApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAdminService _admin;
        private readonly IMapper _mapper;
        public AuthController(IAdminService admin, IMapper mapper)
        {
            _admin = admin;
            _mapper = mapper;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind(include:"Username, Password")] LoginViewModel admin)
        {
            if (ModelState.IsValid)
            {                
                var user = await _admin.GetAdmin(admin.Username, admin.Password);
                if (user != null)
                {
                    List<Claim> claims = new List<Claim>() {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.Username)
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principle = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(principle);
                    return Redirect("/Admin/Appointments/");
                }                
            }
            return View();
        }
        public IActionResult Logout()
        {
            return View();
        }
    }
}
