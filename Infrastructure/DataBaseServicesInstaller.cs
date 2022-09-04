using Application.Configuration.Data;
using Domain.Employee;
using Domain.Task;
using Infrastructure.DataBase;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public static class DataBaseServicesInstaller
    {
        public static IServiceCollection AddDataBaseServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<EmployeeDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<ISqlConnectionFactory>(context => new SqlConnectionFactory(connectionString));
            services.AddScoped<IEmployeesRepository, EmployeesRepository>();
            services.AddScoped<ITasksRepository, TasksRepoository>();

            return services;
        }
    }
}
