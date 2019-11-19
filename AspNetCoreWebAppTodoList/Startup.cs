using System;
using System.IO;
using AspNetCoreWebAppTodoList.Context;
using AspNetCoreWebAppTodoList.Logging.Extensions;
using Castle.Windsor;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace AspNetCoreWebAppTodoList
{
    internal class Startup
    {
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoList"));
            services.AddDbContext<VoltageContext>(opt => opt.UseInMemoryDatabase("Voltages"));
            //todo what is the difference between AddMvc and AddMvcCore
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "ToDo-Api",
                    Version = "v1",
                    Description = "API for interacting with ToDo-Items"
                });
                var filePath = Path.Combine(System.AppContext.BaseDirectory, "AspNetCoreWebAppTodoList.xml");
                c.IncludeXmlComments(filePath);
                c.DescribeAllEnumsAsStrings();
                c.DescribeStringEnumsInCamelCase();
            });

            var windsorContainer = new WindsorContainer();
            windsorContainer.Install(new Installer());
            return WindsorRegistrationHelper.CreateServiceProvider(windsorContainer, services);
        }

        public void Configure(IApplicationBuilder appBuilder, IHostingEnvironment env, Microsoft.Extensions.Logging.ILoggerFactory loggerFactory)
        {
            loggerFactory.AddLog4Net(Constants.Log4NetConfigFile);
            appBuilder.UseMvc();
            appBuilder.UseSwagger(o => o.RouteTemplate = "/api-docs/{documentName}/swagger.json");
            appBuilder.UseSwaggerUI(o =>
            {
                o.RoutePrefix = "api-docs";
                o.SwaggerEndpoint("/api-docs/v1/swagger.json", "My API v1");
            });
        }
    }
}
