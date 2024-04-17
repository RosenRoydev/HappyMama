using HappyMama.BusinessLogic.Contracts;
using HappyMama.BusinessLogic.Exceptions;
using HappyMama.BusinessLogic.Services;
using HappyMama.BusinessLogic.ViewModels.News;
using HappyMama.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using static HappyMama.UnitTests.NewFolder.DatabaseSeeder;

namespace HappyMama.UnitTests
{
    public class NewsServiceTests
    {
        private DbContextOptions<HappyMamaDbContext> options;
        private HappyMamaDbContext context;

        private INewsService newsService;
        private IHttpContextAccessor accessor;

        [OneTimeSetUp]

        public void OneTimeSetUp()
        { 
            this.options = new DbContextOptionsBuilder<HappyMamaDbContext>()
              .UseInMemoryDatabase("HappyMamaDbInMemory" + Guid.NewGuid().ToString())
              .Options;

            this.context = new HappyMamaDbContext(this.options);

            context.Database.EnsureCreated();

            SeedDatabase(this.context);

            this.accessor = new HttpContextAccessor();
            var httpContext = new DefaultHttpContext();
            httpContext.User = new System.Security.Claims.ClaimsPrincipal(new System.Security.Claims.ClaimsIdentity(new[]
            {
                new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.NameIdentifier, "228dfc0a-78a8-4163-aff3-94a5c1014fbb")
            }));
            this.accessor.HttpContext = httpContext;

            this.newsService = new NewsService(this.context, accessor);
        }

        [Test]
        public async Task AddNewsAsyncShoulIncreaseTheCountOfNews()
        {
            var newsBeforeNewOne = context.News.Count();

            var user = accessor.HttpContext.User;

            NewsFormViewModel viewModel = new NewsFormViewModel()
            {
                Title = "New title for news",
                Description = "That's the description",
                CreatedOn = new DateTime(2024, 4, 17, 16, 0, 0),
               

            };

            newsService.AddNewsAsync(user.ToString(), viewModel);

            var newsAfterNewOne = context.News.Count();

            Assert.AreEqual(1, newsBeforeNewOne);
            Assert.AreEqual(2, newsAfterNewOne);
        }

        [Test]
        public async Task AllNewsAsyncShouldReturnTheCorrectCountsOfNewsAndCorrectCountOfPagesToShowIt()
        {
            int currentPage = 1;
            int newsForPage = 1;

           var result =  await newsService.AllNewsAsync(currentPage, newsForPage);

            int totalNews = result.NewsCount;

            int pages = (int)Math.Ceiling(totalNews / (double)(newsForPage));

            Assert.AreEqual(1, currentPage);
            Assert.AreEqual(2, pages);
            Assert.AreEqual(2, totalNews);
        }

        [Test]
        public async Task DeleteNewsShouldDecreaseCountOfNews()
        {
            var newsBeforeDelete = context.News.Count();

          var newsForDelete = await newsService.GetNewsById(2);

            await newsService.DeleteNewsAsync(newsForDelete.Id );

            var newsAfterDelete = context.News.Count();

            Assert.AreEqual(2, newsBeforeDelete);
            Assert.AreEqual(1, newsAfterDelete);

        }

        [Test]
        public async Task DeleteNewsShouldThrowsAnExceptionWhenIdЕxist()
        {
           

            var exception = Assert.ThrowsAsync<NewsNotExist>(async () =>
            {
                await newsService.DeleteNewsAsync(99);
            });

            Assert.That(exception.Message, Is.EqualTo("The news doesn't exist!"));
        }

        [Test]
        public async Task EditNewsShouldChangeTheTitleAndDescriptionOfNews()
        {
            var news = await newsService.GetNewsById(1);

            Assert.AreEqual("Vaccine against Flu", news.Title);
            Assert.AreEqual("All parents , who want their child to be vaccinated , please contact with me . The vaccination is organized by the Ministry of health and is for free!", news.Description);



            NewsFormViewModel model = new NewsFormViewModel()
            {
                Id = news.Id,
                Title = "Changed title",
                Description = "ChangedDescription",

            };

           await newsService.EditNewsAsync(news.Id, model);

            var result = await newsService.GetNewsById(1);

            Assert.AreEqual("Changed title", result.Title);
            Assert.AreEqual("ChangedDescription", result.Description);
        }

        

            
    }
}
