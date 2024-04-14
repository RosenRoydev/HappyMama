using HappyMama.BusinessLogic.ViewModels.Event;
using HappyMama.BusinessLogic.ViewModels.Parent;
using HappyMama.BusinessLogic.ViewModels.Teacher;
using HappyMama.Infrastructure.Data.DataModels;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace HappyMama.BusinessLogic.Contracts
{
    public interface IParentService
	{
		Task <bool> FirstNameExistAsync (string FirstName);
		Task<bool> LastNameExistsAsync(string LastName);

		Task<bool> ExistByIdAsync (string Id);
		Task AddParentAsync(string Id, AddParentFormModel model);
		Task <Parent> ParentByIntIdAsync(int Id);
		Task<List<EventIndexViewModel>> PaidEventsAsync (string Id);
        Task ApproveParentAsync(int Id);
        Task<IEnumerable<AddParentFormModel>> GetParentsNotApprovedAsync();
    }
}
