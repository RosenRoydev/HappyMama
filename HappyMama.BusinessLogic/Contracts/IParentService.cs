using HappyMama.BusinessLogic.ViewModels.Parent;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace HappyMama.BusinessLogic.Contracts
{
    public interface IParentService
	{
		Task <bool> FirstNameExist (string FirstName);
		Task<bool> LastNameExists(string LastName);
		Task<AddParentFormModel> AddParent(AddParentFormModel model);
	}
}
