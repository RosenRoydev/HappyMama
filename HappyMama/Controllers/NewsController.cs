using HappyMama.BusinessLogic.Contracts;
using HappyMama.BusinessLogic.ViewModels.Event;
using HappyMama.BusinessLogic.ViewModels.News;
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
    }
}
