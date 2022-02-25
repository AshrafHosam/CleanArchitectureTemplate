using Mock.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Application.Contracts.Persistence
{
    public interface ICategoryRepo : IAsyncRepo<Category>
    {
        Task<bool> IsCategoryNameUnique(string name);
    }
}
