using HappyMama.BusinessLogic.Contracts;
using HappyMama.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace HappyMama.Controllers
{
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
    }
}
