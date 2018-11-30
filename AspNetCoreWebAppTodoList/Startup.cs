using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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
                c.SwaggerDoc("v1",new Info{ Title = "My api", Version = "v1"}));
        }

        public void Configure(IApplicationBuilder appBuilder)
        {
            appBuilder.UseMvc();
            appBuilder.UseSwagger();
            appBuilder.UseSwaggerUI(o => o.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1"));
        }
    }
}
