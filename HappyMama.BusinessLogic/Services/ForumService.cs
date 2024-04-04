using HappyMama.BusinessLogic.Contracts;
using HappyMama.BusinessLogic.Enums;
using HappyMama.BusinessLogic.ViewModels.Forum;
using HappyMama.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using static HappyMama.Infrastructure.Constants.DataValidationConstants;

namespace HappyMama.BusinessLogic.Services
{
    public class ForumService : IForumService
	{
		private readonly HappyMamaDbContext context;
        public ForumService(HappyMamaDbContext _context)
        {
            context = _context;
        }
        public async Task<AllThemesViewModel> AllThemesAsync(string searchingWord = null, ThemeEnum orderedThemes = ThemeEnum.Newest,
			int currentPage = 1, int themesPerPage = 1)
		{
			var themesQuery =  context.Themes.AsQueryable();

			

			if (!string.IsNullOrEmpty(searchingWord))
			{
				string normalizedWord = searchingWord.ToLower();

				themesQuery = themesQuery.Where(t => t.Title.Contains(normalizedWord.ToLower()) ||
						 ( t.Creator.UserName.Contains(searchingWord.ToLower())));
						  
			}

			themesQuery = orderedThemes switch
			{
				ThemeEnum.Newest => themesQuery.OrderBy(t => t.Id),
				ThemeEnum.Oldest => themesQuery.OrderByDescending(t => t.Id),
			};

			var themesCount = await themesQuery.CountAsync();

			var themes =  await themesQuery
				.OrderBy(t => t.Id)
				.Skip((currentPage-1) * themesPerPage )
				.Take(themesPerPage)
				.Select(t => new ThemeFormViewModel
				{
					Id = t.Id,
					Title = t.Title,
					CreatedOn = t.CreatedOn.ToString(FormatForDate),
					Creator = t.Creator.UserName
				})
				.ToListAsync();

			
			var totalPages = (int)Math.Ceiling(themesCount / (double)themesPerPage);

			return new AllThemesViewModel()
			{
				currentPage = currentPage,
				Themes = themes,
				ThemesCount = themesCount,
				totalPages = totalPages

			};
				


		}
	}
}
