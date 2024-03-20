using HappyMama.Attributes;
using HappyMama.BusinessLogic.Contracts;
using HappyMama.BusinessLogic.Enums;
using HappyMama.BusinessLogic.ViewModels.Event;
using HappyMama.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index(int page = 1)
        {
            var model = await eventService.AllEventsAsync(page, EventIndexViewModel.EventsPerPage);

            return View(model);
        }

        [HttpGet]
        [AdminFilter]
        public   IActionResult AddEvent()
        {
            var model = new AddEventFormModel();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AllEventsSorted(string searchTerm , EventEnum sorting, int page = 1, int eventsPerPage = 1)
        {
            var model = await eventService
                .AllEventsSortedAsync(searchTerm, sorting, page, eventsPerPage);

         return View(model);
        }

        [HttpPost]
        [AdminFilter]

        public async Task<IActionResult> AddEvent(AddEventFormModel model)
        {
			
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
