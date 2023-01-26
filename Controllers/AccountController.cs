using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MvcWebApp.Entities;
using MvcWebApp.Models;
using NETCore.Encrypt.Extensions;

namespace MvcWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly DatabaseContext _databseContext;
        private readonly IConfiguration _configuration;
        public AccountController(DatabaseContext databseContext, IConfiguration configuration)
        {
            _databseContext = databseContext;
            _configuration = configuration;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                string md5Salt = _configuration.GetValue<string>("AppSettings:MD5Salt");
                string saltedPassword = model.Password + md5Salt;
                string hashedPassword = saltedPassword.MD5();

                User user = _databseContext.Users.SingleOrDefault(x => x.Username.ToLower() == model.Username.ToLower()
                && x.Password == hashedPassword);

                if (user != null)
                {
                    if (user.Locked)
                    {
                        ModelState.AddModelError(nameof(user.Username), "User is locked!");
                        return View(model);

                    }
                    List<Claim> claims = new List<Claim>();//for Cookie
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));//Global name for id
                    claims.Add(new Claim(ClaimTypes.Name, user.FullName ?? string.Empty));//Global name for Fullname
                    claims.Add(new Claim("Username", user.Username ?? string.Empty));

                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);//under code want to this
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal); //Login mvc
                    return RedirectToAction("Index", "Home");//Go home
                }
                else
                {
                    ModelState.AddModelError("", "Username or password is incorrect!");
                }
            }
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                if (_databseContext.Users.Any(x => x.Username.ToLower() == model.Username.ToLower()))
                {
                    ModelState.AddModelError(nameof(model.Username), "Username is already exist!");
                    View(model);
                }
                string md5Salt = _configuration.GetValue<string>("AppSettings:MD5Salt");
                string saltedPassword = model.Password + md5Salt;
                //Since most of the passwords exist on the sites,
                // we strengthen the incoming password.
                string hashedPassword = saltedPassword.MD5();
                User user = new()
                {
                    Username = model.Username,
                    Password = model.Password

                };
                _databseContext.Users.Add(user);//new object add user of table
                int affectedRowCount = _databseContext.SaveChanges();//insert
                if (affectedRowCount == 0)
                {
                    ModelState.AddModelError("", "User can not be added!");
                }
                else
                {
                    return RedirectToAction(nameof(Login));
                }
            }
            return View(model);
        }
    }
}