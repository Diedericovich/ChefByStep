using ChefByStep.API.Entities;
using ChefByStep.API.Helpers;
using ChefByStep.API.Repos;
using ChefByStep.API.Repos.Interfaces;
using ChefByStep.API.Services;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChefByStep.API
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
            services.AddControllers().AddNewtonsoftJson(
                options => options.SerializerSettings.ReferenceLoopHandling =
                               Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddSwaggerGen(
                c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "ChefByStep.API", Version = "v1" }); });

            services.AddDbContext<DatabaseContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("LocalConnectionString")));
            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

            services.AddCors();

            services.AddScoped<IGenericRepo<Step>, GenericRepo<Step>>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IRecipeRepo, RecipeRepo>();
            services.AddScoped<IIngredientRepo, IngredientRepo>();
            services.AddScoped<IRecipeRatingRepo, RecipeRatingRepo>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<IRecipeRatingService, RecipeRatingService>();
            services.AddScoped<IIngredientService, IngredientService>();
            services.AddScoped<IStepService, StepService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ChefByStep.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:5001"));

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}