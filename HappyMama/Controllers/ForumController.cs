using HappyMama.BusinessLogic.Contracts;
using HappyMama.BusinessLogic.Enums;
using HappyMama.BusinessLogic.ViewModels.Forum;
using HappyMama.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HappyMama.Controllers
{
	[Authorize]
	public class ForumController : Controller
	{
		private readonly IForumService forumService;
        public ForumController(IForumService _forumService)
        {
            forumService = _forumService;
        }

		[HttpGet]
        public async Task <IActionResult> AllThemes(string searchTerm  , ThemeEnum sorting, int currentPage = 1)
		{
			var model = await forumService.AllThemesAsync(searchTerm,sorting
				,currentPage,ThemeFormViewModel.ThemesPerPage);

				return View(model);
		}

		[HttpGet]
		public  IActionResult AddTheme()
		{
			var model =  new AddThemeFormModel();

			return View (model);
		}

		[HttpPost]
		public async Task <IActionResult> AddTheme(AddThemeFormModel model)
		{
			if (model == null)
			{
				return BadRequest();
			}

			if (!ModelState.IsValid)
			{
				return View(model);
			}

			await forumService.AddThemeAsync(User.Id(), model);

			return RedirectToAction(nameof(AllThemes));
		}

		[HttpGet]
		public async Task<IActionResult> EditTheme(int id)
		{
			var model = await forumService.GetThemeById(id);

			if (model == null)
			{
				return BadRequest();

			}
			
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> EditTheme(AddThemeFormModel model, int id)
		{
			if (model == null)
			{
				return BadRequest();
			}

			

			if (model.CreatorId != User.Id())
			{
				return Unauthorized();
			}

			if (!ModelState.IsValid)
			{
				return View(model);
			}

			await forumService.EditThemeAsync(id, model);

			return RedirectToAction(nameof(AllThemes));
		}

		[HttpGet]
		public async Task <IActionResult> DeleteTheme(int id)
		{
			var model = await forumService.GetThemeById(id);
			
			if (model.CreatorId  != User.Id())
			{
				return Unauthorized();
			}

			if (model != null)
			{
				return View(model);
			}

			return RedirectToAction(nameof(AllThemes));
		}

		[HttpPost]
		public async Task<IActionResult> DeleteTheme(AddThemeFormModel model)
		{
			if( model == null)
			{
				return BadRequest();
			}

			if(model.CreatorId != User.Id())
			{
				return Unauthorized();
			}

			await forumService.DeleteThemeAsync(model.Id);

			return RedirectToAction(nameof(AllThemes));


		}

		[HttpGet("/Forum/Answers/{Id}")]
		public async Task<IActionResult>AllPosts(int Id,int currentPage = 1)
		{
			var model = await forumService.AllPostsAsync( Id, currentPage, PostFormViewModel.PostPerPage);

			return View(model);


		}
	}
}
