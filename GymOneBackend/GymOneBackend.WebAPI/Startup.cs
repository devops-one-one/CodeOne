using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymOneBackend.Core.IServices;
using GymOneBackend.Domain.IRepositories;
using GymOneBackend.Domain.Services;
using GymOneBackend.Repository;
using GymOneBackend.Repository.Repositories;
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

namespace GymOneBackend.WebAPI
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
      services.AddControllers();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1",
          new OpenApiInfo {Title = "GymOneBackend.WebAPI", Version = "v1"});
      });
      
      services.AddScoped<IExerciseService, ExerciseService>();
      services.AddScoped<IExerciseRepository, ExerciseRepository>();
      services.AddScoped<ISetExerciseService, SetExerciseService>();
      services.AddScoped<ISetExerciseRepository, SetExerciseRepository>();

      services.AddDbContext<MainDBContext>(options => { options.UseSqlite("Data Source=main.db"); });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env,  MainDBContext context)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json",
          "GymOneBackend.WebAPI v1"));
        new DbSeeder(context).SeedDevelopment(1);
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
  }
}