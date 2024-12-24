using Microsoft.AspNetCore.Mvc;
using EFCoreCodeFirst.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace EFCoreCodeFirst.Controllers
{
    public class LoginController : Controller
    {
        //[Route("/")] // This cause problem in authentication routing
        //[Route("/Login/{id}")]
        //[Route("/Login/Login/{id}")]
        //[Route("/Login/Login/{id}")]
        [HttpGet]
        public IActionResult Login(string ReturnUrl)
        {
            User user = new User
            {
                UserId = Guid.NewGuid(),
                Username = "jatin",
                Password = "1",
                Role="Admin"
            };
            return View(user);
        }

        [Route("")]
        [HttpPost]
        [ActionName("LoginSubmit")]
        public async Task<IActionResult> Login(User user)
        {
            if((user.Username=="jignesh" || user.Username=="jatin") && user.Password=="1")
            {
                var claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.UserId)),
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.Role, user.Role),
                        new Claim("FavoriteDrink", "Tea")
                };
                //Initialize a new instance of the ClaimsIdentity with the claims and authentication scheme    
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                //Initialize a new instance of the ClaimsPrincipal with ClaimsIdentity    
                var principal = new ClaimsPrincipal(identity);
                //SignInAsync is a Extension method for Sign in a principal for the specified scheme.    
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
                {
                    IsPersistent = false
                });
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", user);
        }
        
        public async Task<IActionResult> LogOut()
        {
            //SignOutAsync is Extension method for SignOut    
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //Redirect to home page    
            return RedirectToAction("Login");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
