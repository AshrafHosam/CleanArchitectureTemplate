using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mock.Application.Contracts.Persistence;
using Mock.Domain.Entities;
using Mock.Persistence.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration confiuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(confiuration.GetConnectionString("DefualtConnectionString")));

            services.AddScoped(typeof(IAsyncRepo<>), typeof(BaseRepo<>));

            services.AddScoped<IAsyncRepo<Category>, CategoryRepo>();

            return services;
        }
    }
}
