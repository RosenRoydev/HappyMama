using HappyMama.BusinessLogic.Contracts;
using HappyMama.BusinessLogic.Enums;
using HappyMama.BusinessLogic.ViewModels.Event;
using HappyMama.Infrastructure.Data;
using HappyMama.Infrastructure.Data.DataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Claims;
using static HappyMama.Infrastructure.Constants.DataValidationConstants;




namespace HappyMama.BusinessLogic.Services
{

    public class EventService : IEventService
    {
        private readonly HappyMamaDbContext context;
        private readonly IHttpContextAccessor accessor;
      

        public EventService(HappyMamaDbContext _context,IHttpContextAccessor _accessor)
        {
            context = _context;
            accessor = _accessor;

        }
        

       
        public async Task AddEventAsync(AddEventFormModel model, string Id)
        {
            
            var currentUser = accessor.HttpContext.User;
                
            var entity = new Event()
            {
                Name = model.Name,
                Description = model.Description,
                NeededAmount = model.NeededAmount,
                DeadTime = model.DeadlineTime,
                CreatorId = GetUserId(currentUser),
                
            };

           await context.Events.AddAsync(entity);
           await context.SaveChangesAsync();
            
        }

		
		public async Task<AllEventsViewModel> AllEventsAsync(int currentPage = 1, int eventsPerPage = 1)
        {
            var eventsQuery = context.Events.Include(e => e.Creator);

            
            var totalCount = await eventsQuery.CountAsync();

            
            var events = await eventsQuery
                .OrderBy(e => e.Id) 
                .Skip((currentPage - 1) * eventsPerPage)
                .Take(eventsPerPage)
                .Select(e => new EventIndexViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    DeadLineTime = e.DeadTime.ToString(FormatForDate),
                    NeededAmount = e.NeededAmount.ToString(),
                    CreatorId = e.CreatorId,
                    Creator = e.Creator.UserName,
                })
                .ToListAsync();

            var totalPages = (int)Math.Ceiling(totalCount / (double)eventsPerPage);

            return new AllEventsViewModel
            {
                EventsCount = totalCount,
                Events = events,
                CurrentPage = currentPage,
                TotalPages = totalPages

            };
        }

		public async Task<AllEventsViewModel> AllEventsSortedAsync(string searchingWord = null, EventEnum eventsSort = EventEnum.DateLine, int currentPage = 1, int eventsPerPage = 3)
		{
            var events = context.Events.AsQueryable();

            

            if(!string.IsNullOrEmpty(searchingWord)) 
            {
                string normalizedWord = searchingWord.ToLower();

                events = events.Where(e => e.Name.Contains(normalizedWord.ToLower()) ||
                          e.Creator.UserName.Contains(searchingWord.ToLower()) ||
                          e.Description.Contains(searchingWord.ToLower()));
            
            }

            events = eventsSort switch
            {
                EventEnum.DateLine => events.OrderBy(e => e.DeadTime),
                EventEnum.AmountForEvent => events.OrderBy(e => e.NeededAmount),
                EventEnum.DateAdded => events.OrderByDescending(e => e.Id)
            };

            var totalEvents = await events.CountAsync();

            var filteredEvents = await events.
                 Skip(currentPage - 1 * eventsPerPage)
                 .Take(eventsPerPage)
                 .Select(e => new EventIndexViewModel
                 {
                     Id = e.Id,
                     Name = e.Name,
                     Description = e.Description,
                     DeadLineTime = e.DeadTime.ToString(FormatForDate),
                     NeededAmount = e.NeededAmount.ToString(),
                     CreatorId = e.CreatorId,
                     Creator = e.Creator.UserName,

                 }).ToListAsync();


              var allEvents = filteredEvents.Count();

            var totalPages = (int)Math.Ceiling(totalEvents / (double)eventsPerPage);

            return  new AllEventsViewModel()
            {
                Events = filteredEvents,
                EventsCount = allEvents,
                CurrentPage = currentPage,
                TotalPages = totalPages
            };

        }

		public Task<bool> CorrectEditor(string Id)
		{
		  return context.Events.AnyAsync(e => e.CreatorId == Id);
		}

		

		public async Task EditEventAsync(int id, AddEventFormModel model)
		{
            var entity = await context.Events
                .Where(entity => entity.Id == id)
                .FirstOrDefaultAsync();

            if (entity != null)
            {
                entity.Id= model.Id;
                entity.Name = model.Name;
                entity.Description = model.Description;
                entity.DeadTime = model.DeadlineTime;
                entity.NeededAmount = model.NeededAmount;
                    
                context.SaveChanges();
            }
			
		}

		public async  Task<bool> ExistEventByIdAsync(int id)
		{
			return await context.Events.AnyAsync(e => e.Id == id);
		}

		public async Task<AddEventFormModel?> GetEventModelById(int Id)
		{
			var model = await context.Events.Where(e => e.Id == Id)
                .Select(e => new AddEventFormModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    DeadlineTime = e.DeadTime,
                    NeededAmount = e.NeededAmount,
                    
                })
                .FirstOrDefaultAsync();

            return model;
		}

		private string GetUserId(ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
	}
}
