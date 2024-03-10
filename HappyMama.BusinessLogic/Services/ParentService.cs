using HappyMama.BusinessLogic.Contracts;
using HappyMama.BusinessLogic.ViewModels.Parent;
using HappyMama.Infrastructure.Data;

namespace HappyMama.BusinessLogic.Services
{
	public class ParentService : IParentService
	{
		private readonly HappyMamaDbContext context;
        public ParentService(HappyMamaDbContext _context)
        {
            context = _context;
        }
        public Task<AddParentFormModel> AddParent(AddParentFormModel model)
		{
			throw new NotImplementedException();
		}

		public Task<bool> FirstNameExist(string FirstName)
		{
			throw new NotImplementedException();
		}

		public Task<bool> LastNameExists(string LastName)
		{
			throw new NotImplementedException();
		}
	}
}
