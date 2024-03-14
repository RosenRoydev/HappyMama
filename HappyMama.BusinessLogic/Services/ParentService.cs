using HappyMama.BusinessLogic.Contracts;
using HappyMama.BusinessLogic.ViewModels.Parent;
using HappyMama.Infrastructure.Data;
using HappyMama.Infrastructure.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using static HappyMama.BusinessLogic.Constants.ErrorMessagesConstants;

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
			};
			

			

			await context.Parents.AddAsync(entity);
		    await context.SaveChangesAsync();
			
		}

		public Task<bool> ExistByIdAsync(string Id)
		{
			return context.Parents
				.AnyAsync(p => p.UserId == Id);
		}

		public async Task<bool> FirstNameExistAsync(string FirstName)
		{
			return await context.Parents
				.AnyAsync(p => p.FirstName == FirstName);
		}

		public async Task<bool> LastNameExistsAsync(string LastName)
		{
			return await context.Parents
				.AnyAsync(p => p.LastName == LastName);
		}
	}
}
