using Blog.Web.Mvc.Data;
using Blog.Web.Mvc.Data.Entity;
using Blog.Web.Mvc.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Blog.Web.Mvc.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDbContext _db;

        public AuthController(AppDbContext db) {
            _db = db;
        }

        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid) {
                var user = new User {Name=model.Name, City = model.City, Email = model.Email, Password = model.Password, Phone = model.Phone };
                _db.Users.Add(user);
                _db.SaveChanges();
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
                var user = _db.Users.FirstOrDefault(e => e.Email == model.Email && e.Password == model.Password);
                if(user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim("Id",Convert.ToString(user.Id)),
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim("City",user.City),
                        new Claim("Password",user.Password),
                        new Claim(ClaimTypes.MobilePhone, user.Phone)
                    };
                    var identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);

                    var props = new AuthenticationProperties() { ExpiresUtc = DateTime.UtcNow.AddMinutes(60) };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal,props);
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
