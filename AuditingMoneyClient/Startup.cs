using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AuditingMoneyClient
{

    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }
       
        public void ConfigureServices(IServiceCollection services)
        {
            //var connectionString = _config.GetConnectionString("DefaultConnection");
            //services.AddDbContext<AuditingDbContext>(config =>
            //{
            //    config.UseSqlServer(connectionString);
            //});

            services.AddAuthentication(config =>
            {
                config.DefaultScheme = "Cookie";
                config.DefaultChallengeScheme = "oidc";
            })
             .AddCookie("Cookie")
             .AddOpenIdConnect("oidc", config =>
             {
                 config.Authority = "https://localhost:44393/";
                 config.ClientId = "client_id_mvc";
                 config.ClientSecret = "client_secret_mvc";
                 config.SaveTokens = true;
                 config.SignedOutCallbackPath = "/Home/Index";
                 config.ResponseType = "code";

                  //configure cookie claim mapping
                  //config.ClaimActions.DeleteClaim("amr");
                  //config.ClaimActions.MapUniqueJsonKey("Some.Grandma", "rc.grandma");

                  ////configure scope
                  //config.Scope.Clear();
                  //config.Scope.Add("openid");
                  //config.Scope.Add("rs.scope");

                  //two trips to load claims in the cookie
                  //but the id token is smaller !
                  //config.GetClaimsFromUserInfoEndpoint = true;
              });
            services.AddHttpClient();
            services.AddControllersWithViews();

            //services.AddTransient<IBalanceRepository, BalanceRepository>();
        }

       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            //using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            //{
            //    // automatic migration
            //    var context = serviceScope.ServiceProvider.GetRequiredService<AuditingDbContext>();
            //    context.Database.Migrate();

            //    ConfigDatabase.Initilize(context);
            //}
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
