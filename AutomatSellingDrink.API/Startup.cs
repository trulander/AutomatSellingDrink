using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutomatSellingDrink.API.Middlewares;
using AutomatSellingDrink.BusinessLogic.Services;
using AutomatSellingDrink.Core.Interfaces;
using AutomatSellingDrink.DataAccess;
using AutomatSellingDrink.DataAccess.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace AutomatSellingDrink.API
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
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.Name = "AutomatSellingDrink.Session";
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlite(
                    Configuration.GetConnectionString("DefaultConnection"), b =>
                    {
                        b.MigrationsAssembly("AutomatSellingDrink.API");
                    });
                // options.UseSqlServer(
                //     Configuration.GetConnectionString("DefaultConnection"), b=>
                // {
                //     b.MigrationsAssembly("AutomatSellingDrink.API");
                // });
            });
            
            services.AddAutoMapper(conf =>
            {
                conf.AddProfile<ApiMappingProfile>();
                conf.AddProfile<DataAccessMappingProfile>();
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            
            services.AddScoped<IAdminAutomatRepositories, AdminAutomatRepositories>();
            services.AddScoped<IAdminAutomatService, AdminAutomatService>();
            
            services.AddScoped<IUserAutomatRepository, UserAutomatRepository>();
            services.AddScoped<IUserAutomatService, UserAutomatService>();
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "AutomatSellingDrink.API", Version = "v1"});
                var filePath = Path.Combine(System.AppContext.BaseDirectory, "AutomatSellingDrink.API.xml");
                c.IncludeXmlComments(filePath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSession();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AutomatSellingDrink.API v1"));
            }
            
            
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseMiddleware<AutenticationUserMidleware>();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}