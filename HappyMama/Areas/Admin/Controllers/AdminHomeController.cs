using Microsoft.AspNetCore.Mvc;

namespace HappyMama.Areas.Admin.Controllers
{
    public class AdminHomeController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
