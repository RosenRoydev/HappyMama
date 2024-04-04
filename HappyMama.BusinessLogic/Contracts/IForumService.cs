using HappyMama.BusinessLogic.Enums;
using HappyMama.BusinessLogic.ViewModels.Forum;

namespace HappyMama.BusinessLogic.Contracts
{
    public interface IForumService
	{
		public Task <AllThemesViewModel> AllThemesAsync(string searchingWord = null, ThemeEnum orderedTheme = ThemeEnum.Newest,
			int currentPage = 1, int eventsPerPage = 1);

		public Task AddThemeAsync(string Id, AddThemeFormModel model);
		public Task EditThemeAsync(int id,AddThemeFormModel model);
		public Task <AddThemeFormModel?> GetThemeById(int id);
		public Task DeleteThemeAsync(int id);

    }
}
