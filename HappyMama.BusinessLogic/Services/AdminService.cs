using HappyMama.BusinessLogic.Contracts;
using HappyMama.Infrastructure.Data;
using HappyMama.Infrastructure.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		public async Task<bool> ExistAdminById(string Id)
		{
			return await context.Admins.AnyAsync(a => a.UserId == Id);
		}
	}
}
