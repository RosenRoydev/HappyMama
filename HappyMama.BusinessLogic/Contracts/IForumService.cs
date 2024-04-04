using HappyMama.BusinessLogic.Enums;
using HappyMama.BusinessLogic.ViewModels.Forum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyMama.BusinessLogic.Contracts
{
	public interface IForumService
	{
		public Task <AllThemesViewModel> AllThemesAsync(string searchingWord = null, ThemeEnum orderedTheme = ThemeEnum.Newest,
			int currentPage = 1, int eventsPerPage = 1);	
	}
}
