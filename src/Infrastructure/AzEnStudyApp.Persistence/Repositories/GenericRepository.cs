using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AzEnStudyApp.Application.Interfaces.Repository;
using AzEnStudyApp.Infrastructure.AppContext;
using Microsoft.EntityFrameworkCore;

namespace AzEnStudyApp.Infrastructure.Repositories
{
    public class GenericRepository<T>:IGenericRepositoryAsync<T> where T:class
    {
        private readonly EnglishAzQuizApplicationContext _context;

        public GenericRepository(EnglishAzQuizApplicationContext context)
        {
            _context = context;
        }

        public async  Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
            
        }

        public Task<T> GetByIdAsync(Guid id)
        {
            
            throw new NotImplementedException();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}