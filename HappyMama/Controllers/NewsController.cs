using HappyMama.Attributes;
using HappyMama.BusinessLogic.Contracts;
using HappyMama.BusinessLogic.ViewModels.News;
using HappyMama.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HappyMama.Controllers
{
	[Authorize]
    public class NewsController : Controller
    {
        private readonly INewsService newsService;
        public NewsController(INewsService _newsService)
        {
            newsService = _newsService;
        }

        [HttpGet]
        [AllowAnonymous]

        public async Task <IActionResult> Index(int currentPage = 1)
        {
            var model = await newsService.AllNewsAsync(currentPage, AllNewsViewModel.TotalNewsOnPage);

            return View(model);
        }

        [HttpGet]
        [TeacherFilter]
        public IActionResult AddNews()
        {
            var model = new NewsFormViewModel();
            
            return View(model); 
        }

        [HttpPost]
        [TeacherFilter]
        public async Task<IActionResult> AddNews(NewsFormViewModel model)
        {
            if(model == null)
            {
                return BadRequest();
            }

			

			if (!ModelState.IsValid)
            {
                return View(model);
            }

			await newsService.AddNewsAsync(User.Id(), model);

			return RedirectToAction(nameof(Index));
        }
    }
}
