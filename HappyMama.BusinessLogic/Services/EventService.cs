using HappyMama.BusinessLogic.Contracts;
using HappyMama.BusinessLogic.ViewModels.Event;
using HappyMama.Infrastructure.Data;
using HappyMama.Infrastructure.Data.DataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Globalization;
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

        
       
        public  Task<bool> ExistEventByIdAsync(int id)
		{
			return context.Events.AnyAsync(e => e.Id == id);
		}

		private string GetUserId(ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
	}
}
