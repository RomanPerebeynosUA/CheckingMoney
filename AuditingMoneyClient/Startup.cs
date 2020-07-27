using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using AuditingMoneyClient.Core.Interfaces;
using AuditingMoneyClient.Core.Interfaces.Incomes;
using AuditingMoneyClient.Core.Interfaces.Expenses;
using AuditingMoneyClient.Core.Interfaces.Common;
using AuditingMoneyClient.Core.Mapper;
using AuditingMoneyClient.Core.Repositories;
using AuditingMoneyClient.Core.Repositories.Incomes;
using AuditingMoneyClient.Core.Repositories.Expenses;
using AuditingMoneyClient.Core.Repositories.Common;
using AuditingMoneyClient.Models.Balance;
using AuditingMoneyClient.Models.JsonModels;
using AutoMapper;
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
           
            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

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

                 config.Scope.Add("AuditingMoneyAPI");             

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

            services.AddAutoMapper( 
                c=> c.AddProfile<DomainProfile>(), typeof(Startup));

            services.AddTransient<IHttpClientFactoryRepository, HttpClientFactoryRepository>();
         
            services.AddTransient<IBalanceRepository, BalanceRepository>();
            services.AddTransient<ICashAccountRepository, CashAccountRepository>();
            services.AddTransient<IKindOfCurrencyRepository, KindOfCurrencyRepository>();
            services.AddTransient<IIncomeRepository, IncomeRepository>();
            services.AddTransient<IExpensesRepository, ExpensesRepository>();

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute()
                    .RequireAuthorization();
            });
        }
    }
}
