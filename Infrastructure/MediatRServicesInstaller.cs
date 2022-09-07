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

namespace Infrastructure
{
    public static class MediatRServicesInstaller
    {
        public static IServiceCollection AddMediatRServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(GetAllEmployeesQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetAllTasksQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CreateEmployeeCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(DeleteEmployeeCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CreateTaskCommand).GetTypeInfo().Assembly);

            return services;
        }
    }
}
