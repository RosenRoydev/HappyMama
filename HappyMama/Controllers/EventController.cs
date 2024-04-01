using HappyMama.Attributes;
using HappyMama.BusinessLogic.Contracts;
using HappyMama.BusinessLogic.Enums;
using HappyMama.BusinessLogic.ViewModels.Event;
using HappyMama.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HappyMama.BusinessLogic.Exceptions;


namespace HappyMama.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly IEventService eventService;
        private readonly IParentService parentService;
        private readonly ILogger logger;
       
       
        public EventController(IEventService _eventService,IParentService _parentService,ILogger<EventController> _logger)
        {
            eventService = _eventService;
            parentService = _parentService;
            logger = _logger;
            
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
        [TeacherFilter]
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

        public async Task <IActionResult> PayEvent(int Id,EventPayModel model)
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

            try
            {
                logger.LogError("Event Controller, Pay for Event");

                await eventService.PayForEventAsync(User.Id(), model);
            }
            catch (AlreadyPaidEventException apee)
            {
             
                return RedirectToAction(nameof(ParentController.PaidEvents), "Parent");
            }

            

            return RedirectToAction(nameof(ParentController.PaidEvents), "Parent");
        }
    }
}
