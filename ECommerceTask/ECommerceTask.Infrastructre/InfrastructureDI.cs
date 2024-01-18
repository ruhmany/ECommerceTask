using ECommerceTask.Domain.Interfaces;
using ECommerceTask.Domain.Interfaces.Repositories;
using ECommerceTask.Infrastructre.Presistance;
using ECommerceTask.Infrastructre.Presistance.Repositories;
using ECommerceTask.Infrastructre.Presistance.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceTask.Infrastructre
{
    public static class InfrastructureDI
    {
        public static IServiceCollection InjectRepos(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IProductRepository, ProductRepository>()
                .AddScoped<IAuthService, AuthService>()
                .AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
