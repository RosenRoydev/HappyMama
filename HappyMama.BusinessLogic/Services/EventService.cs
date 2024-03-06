using HappyMama.BusinessLogic.Contracts;
using HappyMama.BusinessLogic.ViewModels.Event;
using HappyMama.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using static HappyMama.Infrastructure.Constants.DataValidationConstants;
namespace HappyMama.BusinessLogic.Services
{
    public class EventService : IEventService
    {
        private readonly HappyMamaDbContext context;

        public EventService(HappyMamaDbContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<EventIndexViewModel>> AllEventsAsync()
        {
            return await context.Events
                .Select(e => new EventIndexViewModel()
                {
                    Name = e.Name,
                    Description = e.Description,
                    DeadTime = e.DeadTime.ToString(FormatForDate),
                    NeededAmount = e.NeededAmount.ToString(),
                    Creator = e.Creator.UserName,

                    
                }).AsNoTracking()
                  .ToListAsync();
        }
    }
}
