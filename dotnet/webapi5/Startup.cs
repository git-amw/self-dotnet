using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using webapi5.Data;

namespace webapi5
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

            services.AddControllers();
               services.AddSwaggerGen(c =>
              {
                  c.SwaggerDoc("v1", new OpenApiInfo { Title = "webapi5", Version = "v1" });
              }); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
              if (env.IsDevelopment())
             {
                 app.UseDeveloperExceptionPage();
                 app.UseSwagger();
                 app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "webapi5 v1"));
             } 

             app.UseHttpsRedirection();

             app.UseRouting();

             app.UseAuthorization();

             app.UseEndpoints(endpoints =>
             {
                 endpoints.MapControllers();
             });

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Middleware1: Incoming Request\n");
            //    await next();
            //    await context.Response.WriteAsync("Middleware1: Outgoing Response\n");
            //});

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Middleware2: Incoming Request\n");
            //    await next();
            //    await context.Response.WriteAsync("Middleware2: Outgoing Response\n");
            //});

            //app.Map("/home", MapHandler =>
            //{
            //    MapHandler.Run(async context =>
            //    {
            //        await context.Response.WriteAsync("Map: Incoming Request\n");
            //        await context.Response.WriteAsync("Map: Outgoing Response\n");
            //    });
            //});
            //app.Map("/account", MapHandler =>
            //{
            //    MapHandler.Run(async context =>
            //    {
            //        await context.Response.WriteAsync("Map2: Incoming Request\n");
            //        await context.Response.WriteAsync("Map2: Hello world\n");
            //        await context.Response.WriteAsync("Map2: Outgoing Response\n");
            //    });
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Last Endpoint \n");
            //});
        }
    }
}
