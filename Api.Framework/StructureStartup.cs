using AutoMapper;
using Common;
using Infrastructure.DbContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection;

namespace Api.Framework
{
    public static class StructureStartup
    {
        public static IConfiguration DIConfiguration
        {
            get
            {
                return Common.ConfigurationManager.GetConfiguration();
            }
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ILoggerFactory, LoggerFactory>();

            services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSwaggerGen();

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(DIConfiguration.GetConnectionString("Main"),
                providerOptions => providerOptions.EnableRetryOnFailure()));


            Contract.DependencyInjector.Start(services);

        }

        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My WebApi v1");
            });

            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/")
                    //await context.Response.WriteAsync("Server is running ");

                    context.Response.Redirect("/swagger");
                else
                    await next();
            });
        }
    }
}
