using Mock.Application.Contracts.Persistence;
using Mock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Persistence.Repos
{
    public class CategoryRepo : BaseRepo<Category>, ICategoryRepo
    {
        public CategoryRepo(ApplicationDbContext context) : base(context)
        {
        }

        public Task<bool> IsCategoryNameUnique(string name)
        {
            //throw new NotImplementedException();
            var exists = _context.Categories.Any(c => c.Name == name);
            return Task.FromResult(exists);
        }
    }
}
