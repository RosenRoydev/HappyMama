using HappyMama.BusinessLogic.Contracts;
using HappyMama.BusinessLogic.Exceptions;
using HappyMama.BusinessLogic.Services;
using HappyMama.BusinessLogic.ViewModels.Event;
using HappyMama.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using static HappyMama.UnitTests.NewFolder.DatabaseSeeder;

namespace HappyMama.UnitTests
{
    public class EventServiceTests
    {
        private DbContextOptions<HappyMamaDbContext> dbOptions;
        private HappyMamaDbContext context;

        private IEventService eventService;
        private IParentService parentService;
        private IHttpContextAccessor httpContextAccessor;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<HappyMamaDbContext>()
                .UseInMemoryDatabase("HappyMamaDbInMemory" + Guid.NewGuid().ToString())
                .Options;

            this.context = new HappyMamaDbContext(this.dbOptions);
            this.context.Database.EnsureCreated();

            SeedDatabase(this.context);

            this.httpContextAccessor = new HttpContextAccessor();
            var httpContext = new DefaultHttpContext();
            httpContext.User = new System.Security.Claims.ClaimsPrincipal(new System.Security.Claims.ClaimsIdentity(new[]
            {
                new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.NameIdentifier, "579cfd9f-0dfd-4775-b05d-e2ca79d70b92")
            }));
            this.httpContextAccessor.HttpContext = httpContext;

            this.eventService = new EventService(this.context, httpContextAccessor);
            this.parentService = new ParentService(this.context);
        }

        [Test]
        public async Task AddEventAsyncShouldReturnCorrectCountsOfEvents()
        {
            var currentUser = httpContextAccessor.HttpContext.User;
            AddEventFormModel model = new AddEventFormModel()
            {
                Name = "New Options for food",
                Description = "If you want your kid to eat healthy food you can pay additional for it",
                NeededAmount = 100,
                SumForPay = 10,
                DeadlineTime = new DateTime(2024, 06, 13, 12, 00, 00),


            };

            await eventService.AddEventAsync(model, "579cfd9f-0dfd-4775-b05d-e2ca79d70b92");

            Assert.AreEqual(3, context.Events.Count());
        }

        [Test]
        public async Task AllEventsAsyncShouldReturnsCorrectEventsAndPagination()
        {

            const int currentPage = 1;
            const int eventsPerPage = 2;
            var expectedTotalCount = await this.context.Events.CountAsync();
            var expectedTotalPages = (int)Math.Ceiling((double)expectedTotalCount / eventsPerPage);

            var result = await this.eventService.AllEventsAsync(currentPage, eventsPerPage);

            Assert.NotNull(result);
            Assert.AreEqual(expectedTotalCount, result.EventsCount);
            Assert.AreEqual(currentPage, result.CurrentPage);
            Assert.AreEqual(expectedTotalPages, result.TotalPages);


        }

        [Test]
        public async Task CorrectEditorShouldreturnTrueOrFalseIfCreatorExistorNot()
        {

            var trueResult = await eventService.CorrectEditor("579cfd9f-0dfd-4775-b05d-e2ca79d70b92");
            var falseResult = await eventService.CorrectEditor("579cfd9f-jdjdjdjdje2ca79d70b92");

            Assert.True(trueResult);
            Assert.False(falseResult);

        }

        [Test]
        public async Task EditEventShouldChangeNameOfEventAndSumForCollect()
        {
            var model = new AddEventFormModel()
            {
                Id = 3,
                Name = "Test",
                Description = "TestDescription",
                SumForPay = 20,
                NeededAmount = 200,
                DeadlineTime = new DateTime(2024, 07, 13, 12, 00, 00)
            };

           await eventService.EditEventAsync(3, model);

            Assert.AreEqual(model.Name, "Test");
            Assert.AreEqual(model.Description, "TestDescription");
            Assert.AreEqual(model.NeededAmount, 200);
            Assert.AreEqual(model.SumForPay, 20);

        }

        [Test]
        public async Task ExistEventByIdShouldReturnTrueIfEventExist()
        {
            var result = await eventService.ExistEventByIdAsync(3);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task ExistEventByIdShouldReturnFalseIfEventNotExist()
        {
            var result = await eventService.ExistEventByIdAsync(69);

            Assert.False(result);
        }

        [Test]
        public async Task GetEventModelByIdAsyncShouldReturnRightEvent()
        {
            var result = await eventService.GetEventModelById(3);

            Assert.AreEqual(result.Name, "Test");
            Assert.AreEqual(result.Description, "TestDescription");
            Assert.AreEqual(result.NeededAmount, 200);
            Assert.AreEqual(result.SumForPay, 20);
        }

        [Test]
        public async Task PayForEventAsyncShouldReduceAmountOfEventAndAmountOfParent()
        {
            var model = await eventService.GetEventModelById(3);
            var eventForPay = new EventPayModel()
            {
                Id = model.Id,
                EventName = model.Name,
                PaySum = model.SumForPay,
            };
            await eventService.PayForEventAsync("228dfc0a-78a8-4163-aff3-94a5c1014fbb", eventForPay);

            var paidEvent = await eventService.GetEventModelById(3);
            var parent = await parentService.ParentByIntIdAsync(1);

            Assert.AreEqual(180, paidEvent.NeededAmount);
            Assert.AreEqual(160, parent.Amount);
            
        }

        [Test]
        public async Task PayForEventShouldThrowExceptionIfEventIsAlreadyPaid()
        {
            var model = await eventService.GetEventModelById(3);
            var eventForPay = new EventPayModel()
            {
                Id = model.Id,
                EventName = model.Name,
                PaySum = model.SumForPay,
            };
            var exception = Assert.ThrowsAsync<AlreadyPaidEventException>(async () =>
            {
                await eventService.PayForEventAsync("228dfc0a-78a8-4163-aff3-94a5c1014fbb", eventForPay);
            });

            Assert.That(exception.Message, Is.EqualTo("You  already paid for this event!")); // Optionally, verify the exception message
        }
    }

    
}
