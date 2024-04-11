using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static HappyMama.BusinessLogic.Constants.RoleConstants;

namespace HappyMama.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            if (User.IsInRole(AdminRole))
            {
                return  RedirectToAction("Index" , "AdminHome" , new {area = "Admin"});
            }

            return View();
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [AllowAnonymous]
        public IActionResult Error(int statusCode)
        {
            if(statusCode == 400)
            {
                return View("Error400");
            }


            if(statusCode == 401)
            {
                return View("Error401");
            }

            if(statusCode == 404)
            {
                return View("Error404");
            }

            return View();
        }
    }
}
