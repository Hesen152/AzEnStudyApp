using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzEnStudyApp.Application.Interfaces.Repository
{
    public interface  IGenericRepositoryAsync<T> where T :class 
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T> AddAsync(T entity);
         
        
    }
}