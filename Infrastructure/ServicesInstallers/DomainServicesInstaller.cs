using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Employee;
using Application.DomainServices;

namespace Infrastructure.ServicesInstallers
{
    public static class DomainServicesInstaller
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeUniquenessChecker, EmployeeUniquenessChecker>();

            return services;
        }
    }
}
