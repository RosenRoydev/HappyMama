using HappyMama.BusinessLogic.Contracts;
using HappyMama.BusinessLogic.ViewModels.News;
using HappyMama.Infrastructure.Data;
using HappyMama.Infrastructure.Data.DataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Principal;

namespace HappyMama.BusinessLogic.Services
{

	public class NewsService : INewsService
    {
        private readonly HappyMamaDbContext context;
		private readonly IHttpContextAccessor accessor;

		public NewsService(HappyMamaDbContext _context,IHttpContextAccessor _accessor)
        {
                context = _context;
                accessor = _accessor;
        }

		public async Task AddNewsAsync(string Id, NewsFormViewModel model)
		{
			var user = accessor.HttpContext.User;

            var entity = new News()
            {

                Title = model.Title,
                Description = model.Description,
                CreatedOn = model.CreatedOn,
                CreatorId = GetUserId(user),
                
                
            };

           await context.News.AddAsync(entity);
            await context.SaveChangesAsync();
		}

		public async Task<AllNewsIndexModel> AllNewsAsync(int currentPage = 1, int totalNewsOnPage = 1)
        {
            var newsQuery = context.News.Include(n => n.Creator);

            var totalNews = newsQuery.Count();

            var news = await newsQuery
                .OrderBy(n => n.Id)
                .Skip((currentPage-1) * totalNewsOnPage)
                .Take(totalNewsOnPage)
                .Select( n => new AllNewsViewModel
                {
                    Id = n.Id,
                    Title = n.Title,
                    Description = n.Description,
                    CreatedOn = n.CreatedOn.ToString(),
                    Creator = n.Creator.UserName,
                    
                })
                .ToListAsync();

            int totalPages = (int)Math.Ceiling(totalNews / (double)totalNewsOnPage);

                return  new AllNewsIndexModel
                {
                    NewsCount = totalNews,
                    TotalPages = totalPages,
                    CurrentPage = currentPage,
                    News = news
                    
                };
        }

		private string GetUserId(ClaimsPrincipal user)
		{
			return user.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
		}
	}
}
