using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace MVC.Models.Mapper
{
    public static class AutoMapperServicesInstaller
    {
        public static IServiceCollection AddAutoMapperServices(this IServiceCollection services, Assembly[] assembly)
        {
            var autoMapperProfileTypes = assembly.SelectMany(a => a.GetTypes()
                .Where(p => typeof(Profile).IsAssignableFrom(p) && p.IsPublic && !p.IsAbstract));

            services.AddScoped<IMapper>(context => new MapperConfiguration(config =>
            {
                foreach (var profile in autoMapperProfileTypes)
                {
                    config.AddProfile(profile);
                }

            }).CreateMapper()
            );

            return services;
        }
    }
}
