using Application.Employee.Commands;
using Application.Employee.Queries;
using Application.Task.Queries;
using AutoMapper;
using Infrastructure;
using Infrastructure.DataBase;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVC.Models.Mapper;
using MVC.Models.MapperProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MVC
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        readonly Assembly[] _assembly;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _assembly = AppDomain.CurrentDomain.GetAssemblies();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDataBaseServices(Configuration.GetConnectionString("DevConnection"));
            services.AddMediatRServices();
            services.AddAutoMapperServices(_assembly);

            //var config = new AutoMapper.MapperConfiguration(cfg =>
            //    {
            //        cfg.AddProfile(new EmployeeViewModelProfile());
            //    });

            //var mapper = config.CreateMapper();
            //services.AddSingleton(mapper);

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Employee}/{action=Index}/{id?}");
            });
        }
    }
}
