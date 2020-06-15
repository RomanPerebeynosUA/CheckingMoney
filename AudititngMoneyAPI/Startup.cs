using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuditingMoneyCore.Data;
using AuditingMoneyCore.Interfaces;
using AuditingMoneyCore.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AudititngMoneyAPI
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }
            
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _config.GetConnectionString("DefaultConnection");
            services.AddDbContext<AuditingDbContext>(config =>
            {
                config.UseSqlServer(connectionString);
            });

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", config =>
                {
                    config.Authority = "https://localhost:44393/";
                    
                    config.Audience = "AuditingMoneyAPI";
                    
                });
            services.AddCors(options =>
            {
                // this defines a CORS policy called "default"
                options.AddPolicy("default", policy =>
                {
                    policy.WithOrigins("https://localhost:44328/")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
            services.AddHttpClient();
            services.AddControllersWithViews();

            services.AddTransient<IBalanceRepository, BalanceRepository>();
            services.AddTransient<ICashAccountRepository, CashAccountRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("default");
            
            app.UseAuthentication();
            app.UseAuthorization();
           

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                // automatic migration
                var context = serviceScope.ServiceProvider.GetRequiredService<AuditingDbContext>();
                context.Database.Migrate();

                ConfigDatabase.Initilize(context);
            }
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
