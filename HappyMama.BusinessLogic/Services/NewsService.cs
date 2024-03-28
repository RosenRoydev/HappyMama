using HappyMama.BusinessLogic.Contracts;
using HappyMama.BusinessLogic.ViewModels.News;
using HappyMama.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyMama.BusinessLogic.Services
{
    
    public class NewsService : INewsService
    {
        private readonly HappyMamaDbContext context;

        public NewsService(HappyMamaDbContext _context)
        {
                context = _context;
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
    }
}
