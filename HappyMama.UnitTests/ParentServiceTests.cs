using HappyMama.BusinessLogic.Contracts;
using HappyMama.BusinessLogic.Services;
using HappyMama.BusinessLogic.ViewModels.Event;
using HappyMama.BusinessLogic.ViewModels.Parent;
using HappyMama.Infrastructure.Data;
using HappyMama.Infrastructure.Data.DataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using static HappyMama.UnitTests.NewFolder.DatabaseSeeder;

namespace HappyMama.UnitTests
{
    public class ParentServiceTests
    {
        private DbContextOptions<HappyMamaDbContext> options;
        private HappyMamaDbContext context;

        private IParentService parentService;
        
      

        [OneTimeSetUp]

        public void Setup()
        {
            this.options = new DbContextOptionsBuilder<HappyMamaDbContext>()
                .UseInMemoryDatabase("HappyMamaDbInMemory" + new Guid().ToString())
                .Options;

            this.context = new HappyMamaDbContext(this.options);

            this.context.Database.EnsureCreated();

            SeedDatabase(this.context);

   

           
            this.parentService = new ParentService(this.context);
           
            


        }

        [Test]
        public async Task AddParentAsyncShouldReturnCorrectTeachersCount()
        {
            var parentsbeforeNewOne = context.Parents.Count();

            AddParentFormModel model = new AddParentFormModel()
            {
                Amount = 1,
                IsApproved = false,
                FirstName = "Parent",
                LastName = "Parentov"
            };

            await parentService.AddParentAsync("a05289cd-5411-45bb-b863-ba2akdkadakdak",model );
            var actualResult = context.Parents.Count();

            Assert.AreEqual(4, parentsbeforeNewOne);
            Assert.AreEqual(5, actualResult);


        }

        [Test]
        public async  Task ApproveParentShoultReturnTrueWhenIsCalled()
        {
            AddParentFormModel model = new AddParentFormModel()
            {
                Amount = 145,
                IsApproved = false,
                FirstName = "Evlogi",
                LastName = "Mishkov"
            };
            
            await parentService.AddParentAsync("a05289cd-5411-45bb-b863-ba2dadadarrkdak", model);

            var parentsNotApproved = await parentService.GetParentsNotApprovedAsync();

            var countBeforeApprovedMethod = parentsNotApproved.Count();

            await parentService.ApproveParentAsync(6);

            var parentsNotApprovedAfterApproveOne = await parentService.GetParentsNotApprovedAsync();
            var countAfterApprovedMethod = parentsNotApprovedAfterApproveOne.Count();

            Assert.AreEqual(6, countBeforeApprovedMethod);
            Assert.AreEqual(5, countAfterApprovedMethod);

        }

        [Test]
        public async Task ExistByIdAsyncShouldReturnTrueWhenIdExist()
        {
            Assert.IsTrue(await parentService.ExistByIdAsync("a05289cd-5411-45bb-b863-ba2dadadarrkdak"));
            Assert.IsFalse(await parentService.ExistByIdAsync("aa2dadadarrkdak"));
        }

        [Test]
        public async Task FirstNameExistAsyncShouldReturnTrueIfExist()
        {
            Assert.IsTrue(await parentService.FirstNameExistAsync("Evlogi"));
            Assert.IsFalse(await parentService.FirstNameExistAsync("Rosen"));
        }

        [Test]
        public async Task LastNameExistAsyncShouldReturnTrueIfExist()
        {
            Assert.IsTrue(await parentService.LastNameExistsAsync("Mishkov"));
            Assert.IsFalse(await parentService.LastNameExistsAsync("Rosenov"));
        }

        [Test]
        public async Task PaidEventsAsyncShouldReturnCorrectCountOfPaidEvents()
        {

           var paidEvents =  await parentService.PaidEventsAsync("a05289cd-5411-45bb-b863-ba2dadadarrkdak");

            var countPaidEvents = paidEvents.Count();

            Assert.AreEqual(0, countPaidEvents); 


        }
    }
}
