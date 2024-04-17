using HappyMama.BusinessLogic.Contracts;
using HappyMama.BusinessLogic.Enums;
using HappyMama.BusinessLogic.Services;
using HappyMama.BusinessLogic.ViewModels.Forum;
using HappyMama.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using static HappyMama.UnitTests.NewFolder.DatabaseSeeder;

namespace HappyMama.UnitTests
{
    public class ForumServiceTests
    {
        private DbContextOptions<HappyMamaDbContext> options;
        private HappyMamaDbContext dbContext;

        private IForumService forumService;
        private IHttpContextAccessor accessor;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.options = new DbContextOptionsBuilder<HappyMamaDbContext>()
                .UseInMemoryDatabase("HappyMamaDbInMemory" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new HappyMamaDbContext(this.options);

            this.dbContext.Database.EnsureCreated();

            SeedDatabase(this.dbContext);

            this.accessor = new HttpContextAccessor();
            var httpContext = new DefaultHttpContext();
            httpContext.User = new System.Security.Claims.ClaimsPrincipal(new System.Security.Claims.ClaimsIdentity(new[]
            {
                new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.NameIdentifier, "228dfc0a-78a8-4163-aff3-94a5c1014fbb")
            }));
            this.accessor.HttpContext = httpContext;

            this.forumService = new ForumService(this.dbContext, accessor);

        }

        [Test]

        public async Task AddThemeAsyncShouldReturnCorrectCountOfThemes()
        {
            var user = accessor.HttpContext.User;

            AddThemeFormModel model = new AddThemeFormModel()
            {
                CreatorId = user.ToString(),
                Title = "I want to create new theme",
                CreatedOn = new DateTime(2024, 05, 06, 10, 58, 26),

            };

            await forumService.AddThemeAsync("228dfc0a-78a8-4163-aff3-94a5c1014fbb", model);

            Assert.IsNotNull(model.Posts);
            Assert.AreEqual(3, dbContext.Themes.Count());


        }

        [Test]
        public async Task AllThemesShouldReturnCorectThemesAndPages()
        {
            string searchingWord = null;
            var orderedThemes = ThemeEnum.Newest;
            var currentPage = 1;
            var themesPerPage = 2;

            var user = accessor.HttpContext.User;

            var result = await this.forumService.AllThemesAsync(searchingWord, orderedThemes, currentPage, themesPerPage);
            var totalPages = (int)Math.Ceiling(result.ThemesCount / (double)themesPerPage);


            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.ThemesCount);
            Assert.AreEqual(1, result.currentPage);
            Assert.AreEqual(2, totalPages);
        }

        [Test]
        public async Task EditTehmeShouldReturnNewNameOfEditedTheme()
        {
            AddThemeFormModel model = new AddThemeFormModel()
            {
                Title = "Edited Title"
            };

            await forumService.EditThemeAsync(2, model);

            var theme = await forumService.GetThemeById(2);

            Assert.AreEqual("Edited Title", theme.Title);

        }

        [Test]

        public async Task DeleteThemeShouldDecreaseTheCountOfThemesWhenDeleteTheme()
        {
            var countBeforeDelete = dbContext.Themes.Count();

            await forumService.DeleteThemeAsync(3);

            var countAfterDelete = dbContext.Themes.Count();

            Assert.AreEqual(3, countBeforeDelete);
            Assert.AreEqual(2, countAfterDelete);
        }

        [Test]
        public async Task AllPostsAsyncShouldReturnsCorrectPostsAndPages()
        {


            int currentPage = 1;
            int postsPerPage = 2;

            var theme = await forumService.GetThemeById(1);

            var result = await forumService.AllPostsAsync(theme.Id, currentPage, postsPerPage);

            int totalPages = (int)Math.Ceiling(result.TotalPosts / (double)postsPerPage);

            Assert.AreEqual(1, totalPages);
            Assert.AreEqual(2, result.TotalPosts);

        }

        [Test]
        public async Task AddPostShouldIncreaseNumberOfPostForTheTheme()
        {
            var theme = await forumService.GetThemeById(2);
            var user = accessor.HttpContext.User;

            var postsBeforeNewOne = dbContext.Posts.Where(p => p.ThemeId == theme.Id).Count();

            AddPostFormModel model = new AddPostFormModel()
            {
                Content = "I just want add one post more",
                ThemeId = theme.Id,
                CreatorId = user.Identity.ToString(),
                CreatedOn = new DateTime(2024, 4, 18, 10, 0, 0),

            };



            await forumService.AddPostAsync(theme.Id, model);


            var postsAfterNewOne = dbContext.Posts.Where(p => p.ThemeId == theme.Id).Count();

            Assert.AreEqual(0, postsBeforeNewOne);
            Assert.AreEqual(1, postsAfterNewOne);

        }

        [Test]
        public async Task DeletePostShoulDecreaseTheCountsOfPosts()
        {
            var postsBeforeDeleting = dbContext.Posts.Count();

            await forumService.DeletePostByIdAsync(1);

            var postsAfterDeletePost = dbContext.Posts.Count();

            Assert.AreEqual(5, postsBeforeDeleting);
            Assert.AreEqual(4, postsAfterDeletePost);
        }

        [Test]

        public async Task GetPostByIdShouldReturnPostIfExistPostWithGivenId()
        {
            var result = await forumService.GetPostById(3);

            Assert.IsNotNull(result);

            var nonExist = await forumService.GetPostById(29);

            Assert.IsNull(nonExist);

        }

        [Test]
        public async Task EditPostShouldReturnEditedContentOfPost()
        {
            var postBeforeEditing = await forumService.GetPostById(3);

            AddPostFormModel model = new AddPostFormModel()
            {
                Content = "EditedContent",
                CreatedOn = new DateTime(2024, 4,17,15,0,0)
                
            };

            await forumService.EditPostAsync(3, model);

            var postAfterEditing =  await forumService.GetPostById(3);

            Assert.AreEqual(" The teachers are perfect . What do you think?",postBeforeEditing.Content);
            Assert.AreEqual("EditedContent", postAfterEditing.Content);
        }


        
     
    }
}
    

