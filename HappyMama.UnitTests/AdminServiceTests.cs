using HappyMama.BusinessLogic.Contracts;
using HappyMama.BusinessLogic.Services;
using HappyMama.Infrastructure.Data;
using HappyMama.Infrastructure.Data.SeedDb;
using Microsoft.EntityFrameworkCore;
using static HappyMama.UnitTests.NewFolder.DatabaseSeeder;

namespace HappyMama.UnitTests
{
    public class AdminServiceTests
    {
        private DbContextOptions<HappyMamaDbContext> dbOptions;
        private HappyMamaDbContext dbContext;

        private IAdminService adminService;

       

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            this.dbOptions = new DbContextOptionsBuilder<HappyMamaDbContext>()
                .UseInMemoryDatabase("HappyMamaDbInMemory" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new HappyMamaDbContext(this.dbOptions);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.adminService = new AdminService(this.dbContext);
            
        }

        [Test]
        public async Task AddAdminShouldReturnCorrectNickNameAndId()
        {
            var adminId = "579cfd9f-0dfd-4775-b05d-e2ca79d70b92";
            var adminNickName = "petrova";

            await  this.adminService.AddAdminAsync("579cfd9f-0dfd-4775-b05d-e2ca79d70b92", "petrova");
            var admin = await dbContext.Admins.FirstOrDefaultAsync(a=> a.UserId ==adminId);

            Assert.IsNotNull(admin);
            Assert.AreEqual(adminNickName, admin.Nickname);
        }

        [Test]
        public async Task AllTeachersAsyncShouldReturnCorrectCount()
        {
          

           var teachers= await this.adminService.AllTeachersAsync();
            var expectedCount = 3;

            Assert.IsNotNull(teachers);
            Assert.AreEqual(expectedCount,teachers.Count());
        }

        [Test]
        public async Task AllParentsAsyncShouldReturnCorrectCount()
        {


            var parents = await this.adminService.AllParentsAsync();
            var expectedCount = 4;

            Assert.IsNotNull(parents);
            Assert.AreEqual(expectedCount, parents.Count());
        }


        [Test]
        public async Task ExistByIdMusReturnCorrectIdIfExist()
        {
            var userId = "579cfd9f-0dfd-4775-b05d-e2ca79d70b92";

            Assert.IsTrue(await adminService.ExistAdminById(userId));
        }
    }
}