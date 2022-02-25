using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Application.Contracts.Persistence
{
    public interface IAsyncRepo<T> where T : class
    {
        Task<T> GetAsync(int Id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T item);
        Task<T> UpdateAsync(T item);
        Task DeleteAsync(T item);
    }
}

