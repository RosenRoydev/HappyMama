using HappyMama.BusinessLogic.Contracts;
using HappyMama.BusinessLogic.Services;
using HappyMama.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using static HappyMama.UnitTests.NewFolder.DatabaseSeeder;

namespace HappyMama.UnitTests
{
    public class TeacherServiceTests
    {
        private DbContextOptions<HappyMamaDbContext> dbOptions;
        private HappyMamaDbContext dbContext;

        private ITeacherService teacherService;



        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            this.dbOptions = new DbContextOptionsBuilder<HappyMamaDbContext>()
                .UseInMemoryDatabase("HappyMamaDbInMemory" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new HappyMamaDbContext(this.dbOptions);
           
            this.dbContext.Database.EnsureCreated();
             SeedDatabase(this.dbContext);

            this.teacherService = new TeacherService(this.dbContext);

        }

        [Test]
        public async Task AddTeacherAsyncShouldReturnTeachersCount()
        {
            
             await teacherService.AddTeacherAsync("a05289cd-5411-45bb-b863-ba2394c21358", "Ivanka", "Ivanova");
            var actualResult = dbContext.Teachers.Count();

            Assert.AreEqual(4, actualResult);
            

        }

        [Test]
        public async Task ApproveTeacherShouldReturnTrue()
        {
          await teacherService.ApproveTeacherAsync(4);

            Assert.IsTrue(await teacherService.IsApproved("a05289cd-5411-45bb-b863-ba2394c21342"));
            
        }

        [Test]
        public async Task ExistTeacherByIdTeacherShouldReturnTrue()
        {
            await teacherService.ApproveTeacherAsync(4);

            Assert.IsTrue(await teacherService.ExistById("a05289cd-5411-45bb-b863-ba2394c21342"));

        }

        [Test]
        public async Task ExistTeacherByFirstNameShouldReturnTrueOrFalse()
        {
            Assert.IsFalse(await teacherService.ExistTeacherByFirstNameAsync("Jordan"));
            Assert.IsTrue(await teacherService.ExistTeacherByFirstNameAsync("Ivanka"));
        }

        [Test]
        public async Task ExistTeacherByLastNameShouldReturnTrueOrFalse()
        {
            Assert.IsFalse(await teacherService.ExistTeacherByLastNameAsync("Dankova"));
            Assert.IsTrue(await teacherService.ExistTeacherByLastNameAsync("Manov"));
        }

        [Test]
        public async Task GetTeachersNotApprovedAsyncShouldReturnCorrectCount()
        {
            int expectedCount = 3;
            var teachers = await teacherService.GetTeachersNotApprovedAsync();
            Assert.AreEqual(expectedCount,teachers.Count());
        }
    }
}
