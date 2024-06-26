﻿using HappyMama.BusinessLogic.Contracts;
using HappyMama.BusinessLogic.Enums;
using HappyMama.BusinessLogic.ViewModels.Forum;
using HappyMama.Extensions;
using HappyMama.Infrastructure.Data.DataModels;
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
		public async Task<IActionResult> AllThemes(string searchTerm, ThemeEnum sorting, int currentPage = 1)
		{
			var model = await forumService.AllThemesAsync(searchTerm, sorting
				, currentPage, ThemeFormViewModel.ThemesPerPage);

			return View(model);
		}

		[HttpGet]
		public IActionResult AddTheme()
		{
			var model = new AddThemeFormModel();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> AddTheme(AddThemeFormModel model)
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



			if (model.CreatorId != User.Id() && User.IsAdmin() == false)
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
			
			if (model.CreatorId  != User.Id() && User.IsAdmin() == false)
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

			if(model.CreatorId != User.Id() && User.IsAdmin() == false)
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

        [HttpGet("/Forum/AddPost/{ThemeId}")]
        public IActionResult AddPost(int themeId)
		{
            var model = new AddPostFormModel();
            model.ThemeId = themeId; 
            return View(model);
        }

		[HttpPost("/Forum/AddPost/{ThemeId}")]
		public async Task<IActionResult> AddPost (int themeId,  AddPostFormModel model)
		{
			if (model == null)
			{
				return BadRequest();
			}

			if (ModelState.IsValid)
			{
				return View(model);
			}

			await forumService.AddPostAsync( themeId, model);

			return RedirectToAction(nameof(AllPosts) ,new { Id = themeId });
		}

		[HttpGet] 
		public async Task <IActionResult> EditPost(int Id)
		{
			var model = await forumService.GetPostById(Id);

			if (model == null)
			{
				return BadRequest();
			}

			if(model.CreatorId != User.Id() && User.IsAdmin() == false)
			{
				return Unauthorized();
			}

			return View(model);
		}

		[HttpPost]
		public async Task <IActionResult> EditPost(int Id, AddPostFormModel model)
		{
            if (model == null)
            {
                return BadRequest();
            }

            if (model.CreatorId != User.Id() && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

			if (!ModelState.IsValid)
			{
				return View(model);
			}

			await forumService.EditPostAsync(Id, model);

			int themeId = model.ThemeId;

			return RedirectToAction(nameof(AllPosts), new { Id = themeId });
        }

		[HttpGet]

		public async Task<IActionResult> DeletePost(int Id)
		{
			var model = await forumService.GetPostById(Id);

			if(model == null)
			{
				return BadRequest();
			}

			if(model.CreatorId != User.Id() && User.IsAdmin() == false)
			{
				return Unauthorized();
			}

			return View(model);
		}

		[HttpPost]

		public async Task<IActionResult> DeletePost(int Id, AddPostFormModel model)
		{
			if (model == null)
			{
				return BadRequest();

			}

			if (model.CreatorId != User.Id() && User.IsAdmin() == false)
			{
				return Unauthorized();
			}

			await forumService.DeletePostByIdAsync(Id);

			return RedirectToAction(nameof(AllPosts), new {Id = model.ThemeId});
		}

	}
}
