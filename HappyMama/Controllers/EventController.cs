using HappyMama.BusinessLogic.Contracts;
using HappyMama.BusinessLogic.ViewModels.Event;
using HappyMama.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using static HappyMama.Infrastructure.Constants.DataValidationConstants;

namespace HappyMama.Controllers
{
    [Authorize]
	public class EventController : Controller
    {
        private readonly IEventService eventService;

        public EventController(IEventService _eventService)
        {
            eventService = _eventService;
        }
        public async Task<IActionResult> Index()
        {
            var model = await eventService.AllEventsAsync();

            return View(model);
        }

        [HttpGet]
        public   IActionResult AddEvent()
        {
            var model = new AddEventFormModel();

            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> AddEvent(AddEventFormModel model)
        {
			// to do: validation for user who has rights to add event only teachers and admin can do it.
			if (model == null)
			{
				return BadRequest();
			}

			

			if (!ModelState.IsValid)
            {
                return View(model);
            }

           
            await eventService.AddEventAsync(model,User.Id());

            return RedirectToAction(nameof(Index),"Home");
        }

        [HttpGet]
        public async Task <IActionResult> EditEvent(int Id)
        {
            if (await eventService.ExistEventByIdAsync(Id) == false)
            {
                return BadRequest();
            }

            var model = await eventService.GetEventModelById(Id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditEvent(int Id,AddEventFormModel model)
        {
			if (await eventService.ExistEventByIdAsync(model.Id) == false)
			{
				return BadRequest();
			}

           

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
           await eventService.EditEventAsync(model.Id, model);

            return RedirectToAction(nameof(Index));
		}
    }
}
