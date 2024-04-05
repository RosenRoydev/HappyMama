using HappyMama.BusinessLogic.Contracts;
using HappyMama.BusinessLogic.Enums;
using HappyMama.BusinessLogic.ViewModels.Forum;
using HappyMama.Infrastructure.Data;
using HappyMama.Infrastructure.Data.DataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static HappyMama.Infrastructure.Constants.DataValidationConstants;

namespace HappyMama.BusinessLogic.Services
{
	public class ForumService : IForumService
	{
		private readonly HappyMamaDbContext context;
		private readonly IHttpContextAccessor httpContextAccessor;
		public ForumService(HappyMamaDbContext _context, IHttpContextAccessor _httpContextAccessor)
		{
			context = _context;
			httpContextAccessor = _httpContextAccessor;
		}

		public async Task AddThemeAsync(string Id, AddThemeFormModel model)
		{
			var user = httpContextAccessor.HttpContext.User;

			var entity = new Theme()
			{
				Title = model.Title,
				CreatedOn = DateTime.UtcNow,
				CreatorId = GetUserId(user),
			};

			await context.Themes.AddAsync(entity);
			await context.SaveChangesAsync();
		}

		public async Task<AllThemesViewModel> AllThemesAsync(string searchingWord = null, ThemeEnum orderedThemes = ThemeEnum.Newest,
			int currentPage = 1, int themesPerPage = 1)
		{
			var themesQuery = context.Themes.AsQueryable();



			if (!string.IsNullOrEmpty(searchingWord))
			{
				string normalizedWord = searchingWord.ToLower();

				themesQuery = themesQuery.Where(t => t.Title.Contains(normalizedWord.ToLower()) ||
						 (t.Creator.UserName.Contains(searchingWord.ToLower())));

			}

			themesQuery = orderedThemes switch
			{
				ThemeEnum.Newest => themesQuery.OrderByDescending(t => t.CreatedOn),
				ThemeEnum.Oldest => themesQuery.OrderBy(t => t.Id),
			};

			var themesCount = await themesQuery.CountAsync();

			var themes = await themesQuery
				.Skip((currentPage - 1) * themesPerPage)
				.Take(themesPerPage)
				.Select(t => new ThemeFormViewModel
				{
					Id = t.Id,
					Title = t.Title,
					CreatedOn = t.CreatedOn.ToString(FormatForDate),
					Creator = t.Creator.UserName,
					Posts = context.Posts
										 .Where(p => p.ThemeId == t.Id)
										 .OrderBy(p => p.CreatedOn)
										  .Select(p => new PostFormViewModel
										  {
											  Id = p.Id,
											  Content = p.Content,
											  CreatedOn = t.CreatedOn.ToString(FormatForDate),
											  Creator = t.Creator.UserName,
											  ThemeId = t.Id,
										  })
					                       .ToList()

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

		public async Task EditThemeAsync(int id, AddThemeFormModel model)
		{
			var theme = await context.Themes
				.Where(t => t.Id == id)
				.FirstOrDefaultAsync();

			if (theme != null)
			{
				theme.Title = model.Title;
				theme.CreatedOn = model.CreatedOn;

				await context.SaveChangesAsync();
			}

		}

		private string GetUserId(ClaimsPrincipal user)
		{
			return user.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
		}

		public async Task<AddThemeFormModel?> GetThemeById(int id)
		{
			var model = await context.Themes
							   .Where(t => t.Id == id)
							   .Select(t => new AddThemeFormModel()
							   {
								   Id = t.Id,
								   Title = t.Title,
								   CreatedOn = t.CreatedOn,
								   CreatorId = t.CreatorId,
								   Posts = t.Posts,

							   }).FirstOrDefaultAsync();

			return model;


		}

		public async Task DeleteThemeAsync(int id)
		{
			var model = await context.Themes
				.Where(t => t.Id == id)
				.FirstOrDefaultAsync();

			if (model != null)
			{
				context.Themes.Remove(model);
				await context.SaveChangesAsync();
			}

		}

		public async Task<AllPostFormViewModel> AllPostsAsync(int themeId, int currentPage = 1, int PostsPerPage = 1)
		{
			var postsQuery = context.Posts
				.Where(p => p.ThemeId == themeId)
				.AsQueryable();

			int totalPosts = await postsQuery.CountAsync();

			var posts = await postsQuery
				.OrderBy(p => p.Id).
				Skip((currentPage - 1) * PostsPerPage)
				.Take(PostsPerPage)
				.Select(p => new PostFormViewModel()
				{
					Id = p.Id,
					Content = p.Content,
					CreatedOn = p.CreatedOn.ToString(FormatForDate),
					Creator = p.Creator.UserName,
					ThemeId = p.ThemeId,
				}).ToListAsync();

			int totalPages = (int)Math.Ceiling(totalPosts / (double)PostsPerPage);

			return new AllPostFormViewModel
			{
				TotalPages = totalPages,
				CurrentPage = currentPage,
				Posts = posts,
				TotalPosts = totalPosts
			};

		}
	}
}
