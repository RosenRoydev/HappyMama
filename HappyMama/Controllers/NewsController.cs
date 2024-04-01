using HappyMama.Attributes;
using HappyMama.BusinessLogic.Contracts;
using HappyMama.BusinessLogic.Exceptions;
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
        private readonly ILogger logger;
        public NewsController(INewsService _newsService, ILogger<NewsController> _logger)
        {
            newsService = _newsService;
            logger = _logger;
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

        [HttpGet]
        [TeacherFilter]

        public async Task <IActionResult> EditNews(int Id)
        { 
            var model = await newsService.GetNewsById(Id);

            if(model == null)
            {
                return BadRequest();
            }

            return View(model);
        }

        [HttpPost]
        [TeacherFilter]
        public async Task<IActionResult> EditNews(NewsFormViewModel model)
        {
            if (model == null)
            {
                return BadRequest();

            }

            if(!ModelState.IsValid)
            {
                return View(model);
            }

           await newsService.EditNewsAsync(model.Id, model); 

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [TeacherFilter]

        public async Task <IActionResult> DeleteNews(int id)
        {
            var model = await newsService.GetNewsById(id);

            if (model == null)
            {
                return BadRequest();
            }

            return View(model);
        }

        [HttpPost]
        [TeacherFilter]
        public async Task<IActionResult> DeleteNews(NewsFormViewModel model)
        {
            try
            {
              await  newsService.DeleteNewsAsync(model.Id);
            }

            catch (NewsNotExist nne)
            {
                logger.LogError("NewsController , DeleteNewsAction");
                return RedirectToAction(nameof(Index));
               
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
