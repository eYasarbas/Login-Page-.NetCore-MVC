using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MvcWebApp.Controllers
{//[Authorize(Roles = "admin,manager")]
    [Authorize(Roles = "admin")]//admin control
    public class AdminController : Controller
    {
        //[Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
