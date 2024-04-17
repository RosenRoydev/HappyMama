using HappyMama.BusinessLogic.Contracts;
using HappyMama.BusinessLogic.ViewModels.Event;
using HappyMama.BusinessLogic.ViewModels.Parent;
using HappyMama.Infrastructure.Data;
using HappyMama.Infrastructure.Data.DataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace HappyMama.BusinessLogic.Services
{
    public class ParentService : IParentService
	{
		private readonly HappyMamaDbContext context;
       
        public ParentService(HappyMamaDbContext _context)
		{
			context = _context;
			
		}

		public async Task AddParentAsync(string Id, AddParentFormModel model)
		{
		
			var entity = new Parent()
			{
				UserId = Id,
				FirstName = model.FirstName,
				LastName = model.LastName,
				Amount = model.Amount,
				IsApproved = model.IsApproved,
			};
			

			

			await context.Parents.AddAsync(entity);
		    await context.SaveChangesAsync();
			
		}

        public async Task ApproveParentAsync(int Id)
        {
            var parent = await context.Parents
				.Where(p =>  p.Id == Id)
				.FirstOrDefaultAsync();

			if (parent != null && parent.IsApproved == false)
			{
				parent.IsApproved = true;

				await context.SaveChangesAsync();
			}
        }

        public Task<bool> ExistByIdAsync(string Id)
		{
			return context.Parents
				.Where(p => p.IsApproved == true)
				.AnyAsync(p => p.UserId == Id);
		}

		public async Task<bool> FirstNameExistAsync(string FirstName)
		{
			return await context.Parents
				.AnyAsync(p => p.FirstName == FirstName);
		}

        public async Task<IEnumerable<AddParentFormModel>> GetParentsNotApprovedAsync()
        {
            return await context.Parents
				.Where(p => p.IsApproved == false)
				.Select(p => new AddParentFormModel()
				{
					Id = p.Id,
					FirstName = p.FirstName,
					LastName = p.LastName,
					Amount = p.Amount,
				
				})
				.ToListAsync();
        }

        public async Task<bool> IsApproved(string Id)
        {
            return await context.Parents.
                Where(p => p.UserId == Id).AnyAsync();
        }

        public async Task<bool> LastNameExistsAsync(string LastName)
		{
			return await context.Parents
				.AnyAsync(p => p.LastName == LastName);
		}

        public async Task<List<EventIndexViewModel>> PaidEventsAsync(string  Id)
        {
			var parent = await context.Parents
				.Where(p => p.UserId == Id).FirstOrDefaultAsync();


			List<EventIndexViewModel>? model = await context.EventsParents
				.Where(ep => ep.ParentId == parent.Id)
				.Select(ep => new EventIndexViewModel
				{
					EventId = ep.EventId,
					Name = ep.Event.Name,
					Description = ep.Event.Description,
					DeadLineTime = ep.Event.DeadTime.ToString(),
					Creator = ep.Event.Creator.UserName,
				}).ToListAsync();

			return model;
        }

        public async  Task <Parent> ParentByIntIdAsync(int Id)
        {
          return await context.Parents.
				Where(p => p.Id == Id).FirstOrDefaultAsync();

        }
    }
}
