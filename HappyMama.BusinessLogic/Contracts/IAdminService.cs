using HappyMama.BusinessLogic.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyMama.BusinessLogic.Contracts
{
	public interface IAdminService
	{
		public Task AddAdminAsync(string Id, string nickname);

		public Task<bool> ExistAdminById (string Id);

		public Task<IEnumerable<AllUsersViewModel>> AllTeachersAsync ();
        public Task<IEnumerable<AllUsersViewModel>> AllParentsAsync();
    }
}
