using Microsoft.AspNetCore.Mvc;
using MvcWebApp.Entities;
using MvcWebApp.Models;
using NETCore.Encrypt.Extensions;

namespace MvcWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly DatabseContext _databseContext;
        private readonly IConfiguration _configuration;
        public AccountController(DatabseContext databseContext, IConfiguration configuration)
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
                //login process...
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
                if (_databseContext.Users.Any(x => x.Username.ToLower() == model.UserName.ToLower()))
                {
                    ModelState.AddModelError(nameof(model.UserName), "Username is already exist!");
                    View(model);
                }
                string md5Salt = _configuration.GetValue<string>("AppSettings:MD5Salt");
                string saltedPassword = model.Password + md5Salt;
                //Since most of the passwords exist on the sites,
                // we strengthen the incoming password.
                string hashedPassword = saltedPassword.MD5();
                User user = new()
                {
                    Username = model.UserName,
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