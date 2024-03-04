using Microsoft.AspNetCore.Mvc;

namespace HappyMama.Controllers
{
    public class Event : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
