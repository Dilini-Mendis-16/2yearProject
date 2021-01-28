using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarmerWebAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FarmerWebAPI
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
            /*services.AddControllers();
            services.AddDbContext<FarmerDataBaseContext>(options =>
             options.UseSqlServer("Data Source=DESKTOP-5U2U73I;Initial Catalog=TestDB;Integrated Security=True")
            );*/

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            string connectionstring = "Data Source=DESKTOP-5U2U73I;Initial Catalog=FarmerDataBase;Integrated Security=True";
            services.AddMvc();
            services.AddDbContext<FarmerDataBaseContext>(cfg => cfg.UseSqlServer(connectionstring));
            
           
            /*services.AddMvc();

            services.AddDbContext<FarmerDataBaseContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("FarmerDataBaseContext")));

            */


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
