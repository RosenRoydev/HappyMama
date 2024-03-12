﻿using HappyMama.BusinessLogic.ViewModels.Parent;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace HappyMama.BusinessLogic.Contracts
{
    public interface IParentService
	{
		Task <bool> FirstNameExistAsync (string FirstName);
		Task<bool> LastNameExistsAsync(string LastName);

		Task<bool> ExistByIdAsync (string Id);
		Task AddParentAsync(string Id, AddParentFormModel model);
	}
}