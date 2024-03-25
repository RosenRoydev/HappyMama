using HappyMama.Attributes;
using HappyMama.BusinessLogic.Contracts;
using HappyMama.BusinessLogic.Enums;
using HappyMama.BusinessLogic.ViewModels.Event;
using HappyMama.Extensions;
using HappyMama.Infrastructure.Data.DataModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HappyMama.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly IEventService eventService;
        private readonly IParentService parentService;
        public EventController(IEventService _eventService,IParentService _parentService)
        {
            eventService = _eventService;
            parentService = _parentService;
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
        public IActionResult AddEvent()
        {
            var model = new AddEventFormModel();

            return View(model);
        }

        [HttpGet]
        [TeacherEventFilter]
        public async Task<IActionResult> AllEventsSorted(string searchTerm, EventEnum sorting, int page = 1)
        {
            var model = await eventService
                .AllEventsSortedAsync(searchTerm, sorting, page, EventIndexViewModel.EventsPerPage);

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


            await eventService.AddEventAsync(model, User.Id());

            return RedirectToAction(nameof(Index), "Home");
        }



        [HttpGet]
        [AdminFilter]
        public async Task<IActionResult> EditEvent(int Id)
        {
            if (await eventService.ExistEventByIdAsync(Id) == false)
            {
                return BadRequest();
            }

            var model = await eventService.GetEventModelById(Id);

            return View(model);
        }

        [HttpPost]
        [AdminFilter]
        public async Task<IActionResult> EditEvent(int Id, AddEventFormModel model)
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

        [HttpGet]
        [ParentFilter]

        public async Task <IActionResult> PayEvent(int Id)
        {

            var eventForPay = await eventService.GetEventModelById(Id);

            if (eventForPay == null)
            {
                 
                return BadRequest();
            }

            var model = new EventPayModel()
            {
                Id = eventForPay.Id,
                EventName = eventForPay.Name,
                PaySum = eventForPay.SumForPay,
               
            };

            return View(model);
        }

        [HttpPost]
        [ParentFilter]

        public async Task <IActionResult> PayEvent(int Id,EventPayModel model,int userId)
        {
          

            
            if(model == null)
            {
                return BadRequest();
            }

            if(eventService.ExistEventByIdAsync(model.Id).Result == false)
            {
                return BadRequest();
            }

            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var parent = await parentService.ExistByIdAsync(User.Id());

            if (parent == null)
            {
                RedirectToAction(nameof(Index));
            }

            await eventService.PayForEventAsync( User.Id(),model);

            return RedirectToAction(nameof(AllEventsSorted));
        }
    }
}
