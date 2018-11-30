using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace AspNetCoreWebAppTodoList
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoList"));
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
        }

        public void Configure(IApplicationBuilder appBuilder)
        {
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
