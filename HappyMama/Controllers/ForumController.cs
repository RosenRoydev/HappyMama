using HappyMama.BusinessLogic.Contracts;
using HappyMama.BusinessLogic.Enums;
using HappyMama.BusinessLogic.ViewModels.Forum;
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
        public async Task <IActionResult> AllThemes(string searchTerm  , ThemeEnum sorting, int currentPage = 1)
		{
			var model = await forumService.AllThemesAsync(searchTerm,sorting
				,currentPage,ThemeFormViewModel.ThemesPerPage);

				return View(model);
		}
	}
}
