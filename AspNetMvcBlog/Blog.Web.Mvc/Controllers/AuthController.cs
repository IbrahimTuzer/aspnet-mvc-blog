using Blog.Data.Entity;
using Blog.Data;
using Blog.Data.Entity;
using Blog.Web.Mvc.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Blog.Business.Services;

namespace Blog.Web.Mvc.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserService _us;

        public AuthController(UserService us) {
            _us = us;
        }

        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid) {
                _us.Insert(new User { Name = model.Name, Email = model.Email, Password = model.Password, Phone = "", City = "" });
                return RedirectToAction(nameof(Login));
            }
            else { 
                return View(model);
            }
        }


        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user =_us.GetByEmailPassword(model.Email,model.Password);
                if(user != null)
                {
                    var props = new AuthenticationProperties() { ExpiresUtc = DateTime.UtcNow.AddMinutes(60) };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,_us.ConvertToPrincipal(user),props);
                    return Redirect("/");
                }
                else {
                    ViewBag.Error = "E-Mail veya şifre yanlış";
                        }
            }

                return View(model);
        }
        
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return Redirect("/");
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }
    }
}
