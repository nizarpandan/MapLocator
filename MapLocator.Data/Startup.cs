using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace MapLocator.Data
{
    public class Startup
    {
		IConfiguration _config;

		public Startup(IConfiguration config)
		{
			_config = config;
		}

		public void ConfigureServices(IServiceCollection services)
        {
			services.AddDbContext<DutchContext>(cfg =>
			{
				cfg.UseSqlServer(_config.GetConnectionString("LaptopConnectionString"));
			});

			services.AddTransient<DutchSeeder>();
			services.AddScoped<IDutchRepository, DutchRepository>();
		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

			if (env.IsDevelopment())
			{
				// Seed the database
				using (var scope = app.ApplicationServices.CreateScope())
				{
					var seeder = scope.ServiceProvider.GetService<DutchSeeder>();
					seeder.Seed();
				}
			}
        }
    }
}
