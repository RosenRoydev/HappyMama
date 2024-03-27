using HappyMama.BusinessLogic.Contracts;
using HappyMama.BusinessLogic.ViewModels.Parent;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HappyMama.Extensions;
using static HappyMama.BusinessLogic.Constants.ErrorMessagesConstants;


namespace HappyMama.Controllers
{
	[Authorize]
	public class ParentController : Controller
	{
		private readonly IParentService parentService;

		public ParentController(IParentService _parentService)
		{
			parentService = _parentService;
		}

		[HttpGet]
		public IActionResult AddParentAsync()
		{
			var model = new AddParentFormModel();

			return View(model);
		}

		[HttpPost]

		public async Task<IActionResult> AddParentAsync(AddParentFormModel model)
		{
			if (await parentService.ExistByIdAsync(User.Id()))
			{
				return BadRequest();
			}

			if (await parentService.FirstNameExistAsync(model.FirstName)
				&& await parentService.LastNameExistsAsync(model.LastName))
			{
				ModelState.AddModelError("Error", ParentExist);
			}

			

			if (!ModelState.IsValid)
			{
				return View(model);
			}

			 await parentService.AddParentAsync
				(User.Id(),model);

			return RedirectToAction(nameof(Index), "Home");

		}

		[HttpGet]
		public async Task<IActionResult> PaidEvents()
		{
			var parent = await parentService.ExistByIdAsync(User.Id());

			if (parent == null)
			{
				return RedirectToAction(nameof(Index), "Home");
			};

			var model = await parentService.PaidEventsAsync(User.Id());

			return View(model);

		}
	}
}
