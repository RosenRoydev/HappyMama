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

			if (!decimal.TryParse(model.Amount, out decimal amountValue))
			{
				ModelState.AddModelError("Amount", InvalidAmountFormat);
				return View(model);
			}

			if (amountValue < 30 || amountValue > 180)
			{
				ModelState.AddModelError("Amount", NeededAmountRestrict);
				return View(model);
			}

			if (!ModelState.IsValid)
			{
				return View(model);
			}

			 await parentService.AddParentAsync
				(User.Id(),model);

			return RedirectToAction(nameof(Index), "Home");

		}
	}
}
