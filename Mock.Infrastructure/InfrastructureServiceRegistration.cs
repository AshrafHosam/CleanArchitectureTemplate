using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mock.Application.Contracts.Infrastructure;
using Mock.Application.Models.Mail;
using Mock.Infrastructure.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
