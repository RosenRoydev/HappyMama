using HappyMama.BusinessLogic.Contracts;
using HappyMama.BusinessLogic.ViewModels.Admin;
using HappyMama.Infrastructure.Data;
using HappyMama.Infrastructure.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using static HappyMama.Infrastructure.Constants.DataValidationConstants;

namespace HappyMama.BusinessLogic.Services
{
    public class AdminService : IAdminService
	{
		private readonly HappyMamaDbContext context;

        public AdminService(HappyMamaDbContext _context)
        {
            context = _context;
        }
        public async Task AddAdminAsync(string Id, string nickname)
		{
			Admin admin = new Admin()
			{
				UserId = Id,
				Nickname = nickname,
				
				
			};

			await context.Admins.AddAsync(admin);
			await context.SaveChangesAsync();
		}

        public async Task<IEnumerable<AllUsersViewModel>> AllParentsAsync()
        {
            var allUsers = await context.Parents

                   .Select(p => new AllUsersViewModel()
                   {
                       FirstName = p.FirstName,
                       LastName = p.LastName,
					   CustomerAmount = p.Amount.ToString(),
					   IsApproved = p.IsApproved,


                   }).ToListAsync();

            return allUsers;
        }

        public async Task<IEnumerable<AllUsersViewModel>> AllTeachersAsync()
        {
            var allUsers = await context.Teachers
				      
				    .Select(t => new AllUsersViewModel()
					{
						FirstName = t.FirstName,
						LastName = t.LastName,
						IsApproved = t.IsApproved,
						

					}).ToListAsync();

			return allUsers;
				             
        }

        public async Task<bool> ExistAdminById(string Id)
		{
			return await context.Admins.AnyAsync(a => a.UserId == Id);
		}
	}
}
