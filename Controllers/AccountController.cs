using Microsoft.AspNetCore.Mvc;
using MvcWebApp.Entities;
using MvcWebApp.Models;

namespace MvcWebApp.Controllers
{


    public class AccountController : Controller
    {
        private readonly DatabseContext _databseContext;
        public AccountController(DatabseContext databseContext)
        {
            _databseContext = databseContext;
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