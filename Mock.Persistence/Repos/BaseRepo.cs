using Microsoft.EntityFrameworkCore;
using Mock.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Persistence.Repos
{
    public class BaseRepo<T> : IAsyncRepo<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        public BaseRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<T> AddAsync(T item)
        {
            //throw new NotImplementedException();
            await _context.Set<T>().AddAsync(item);
            await _context.SaveChangesAsync();
            return item;

        }

        public async Task DeleteAsync(T item)
        {
            //throw new NotImplementedException();
            _context.Set<T>().Remove(item);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int Id)
        {
            return await _context.Set<T>().FindAsync(Id);
        }

        public async Task<T> UpdateAsync(T item)
        {
            //throw new NotImplementedException();
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return item;
        }
    }
}
