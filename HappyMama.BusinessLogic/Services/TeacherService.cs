﻿using HappyMama.BusinessLogic.Contracts;
using HappyMama.Infrastructure.Data;
using HappyMama.Infrastructure.Data.DataModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HappyMama.BusinessLogic.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly HappyMamaDbContext context;
       

        public TeacherService(HappyMamaDbContext _dbContext)
        {
            context = _dbContext;
        }
        public async Task AddTeacherAsync(string Id, string FirstName, string LastName)
        {
            var teacher = new Teacher
            {
                UserId = Id,
                FirstName = FirstName,
                LastName = LastName

            };
             context.Teachers.Add(teacher);
            await context.SaveChangesAsync();
        }

        public async Task<bool> ExistById(string Id)
        {
            return await context.Teachers
                .Where(t => t.IsApproved == true)
                .AnyAsync( t=> t.UserId == Id);
        }

        public async Task<bool> ExistTeacherByFirstNameAsync(string FirstName)
        {
            return await context.Teachers
               .AnyAsync(t => t.FirstName == FirstName);
        }

        public async Task<bool> ExistTeacherByLastNameAsync(string LastName)
        {
            return await context.Teachers
                .AnyAsync(t => t.LastName == LastName);
        }

        public async Task<bool> IsApproved(string Id)
        {
            return await context.Teachers
                .AnyAsync(t => t.IsApproved);
        }
    }   
}
