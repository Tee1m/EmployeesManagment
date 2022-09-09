using Application.Employee.Queries;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using MediatR;
using Application.Task.Queries;
using Application.Employee.Commands;
using Application.Configuration.Commands;
using System.Linq;

namespace Infrastructure.ServicesInstallers
{
    public static class MediatRServicesInstaller
    {
        public static IServiceCollection AddMediatRServices(this IServiceCollection services)
        {
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
