using ECommerceTask.Application.Command.UserCommands;
using ECommerceTask.Application.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceTask.Application
{
    public static class ApplicationDI
    {
        public static IServiceCollection InjectApplicationValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<RegisterUserCommand>, RegisterUserValidation>()
                .AddScoped<IValidator<LoginCommand>, LoginUserValidator>();
            return services;
        }
    }
}
