using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using GoraYazilim.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using GoraYazilim.Models;

namespace GoraYazilim.Controllers
{
    public class SecurityController : Controller
    {
       
        PriceTrackingContext context = new PriceTrackingContext();

        public SecurityController(PriceTrackingContext context)
        {
            this.context = context;
           
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            var data = context.Users.Where(x => x.UserMail == user.UserMail && x.UserPassword == user.UserPassword).FirstOrDefault();

            if(data != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.UserMail),
                    
                };

                var useridentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "Security");

        }

        public async Task<IActionResult> Logout()
        {

            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Security");
        }

    }
}
