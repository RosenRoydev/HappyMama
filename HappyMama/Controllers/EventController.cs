using HappyMama.BusinessLogic.Contracts;
using HappyMama.BusinessLogic.Services;
using HappyMama.BusinessLogic.ViewModels.Event;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

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
        public async Task<IActionResult> Add()
        {
            var model = new AddEventFormModel();

            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> Add(AddEventFormModel model)
        {
            return null;
        }
    }
}
