using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using System.Security.Claims;
using Application;
using AspNetCoreHero.ToastNotification;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Stripe;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.Razor;

namespace WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(opt => opt.LowercaseUrls = true);
            services.AddLocalization(opt => { opt.ResourcesPath = "Resources"; });
            services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();
            services.AddNotyf(opt =>
            {
                opt.DurationInSeconds = 5;
                opt.Position = NotyfPosition.TopRight;
                opt.IsDismissable = true;
            });
            
            services.AddAutoMapper(typeof(Startup));
            services.AddSession(); 
            services.AddApplication();
            services.AddAuthentication(opt => opt.DefaultScheme = "User_Schema")
                .AddCookie("Admin_Schema",options =>
                {
                    options.LoginPath = "/admin/account/login";
                    options.AccessDeniedPath = "/admin/dashboard/accessdenied";
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                })
                .AddCookie("User_Schema", options =>
                {
                    options.LoginPath = "/account/login";
                    options.AccessDeniedPath = "/account/accessdenied";
                });

            services.Configure<RequestLocalizationOptions>(opt =>
            {
                var supportedCultures = new List<CultureInfo>
                {
                    new CultureInfo("sq"),
                    new CultureInfo("en")
                };
                opt.DefaultRequestCulture = new RequestCulture("sq");
                opt.SupportedCultures = supportedCultures;
                opt.SupportedUICultures = supportedCultures;
            });

            StripeConfiguration.ApiKey = Configuration.GetSection("Stripe")["SecretKey"];
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            StripeConfiguration.ApiKey = Configuration.GetSection("Stripe")["SecretKey"];
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

            app.Use(async (context, next) =>
            {
                var principal = new ClaimsPrincipal();
                var result1 = await context.AuthenticateAsync("User_Schema");
                if (result1?.Principal != null)
                {
                    principal.AddIdentities(result1.Principal.Identities);
                }
                
                var result2 = await context.AuthenticateAsync("Admin_Schema");
                if (result2?.Principal != null)
                {
                    principal.AddIdentities(result2.Principal.Identities);
                }

                context.User = principal;
                
                await next();

            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.UseRequestLocalization(
                app.ApplicationServices
                .GetRequiredService<IOptions<RequestLocalizationOptions>>()
                .Value);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name : "areas",
                    pattern : "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
                
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "products",
                    pattern: "products/{categorySlug}",
                    defaults: new { controller = "Produktet", action = "FilterProductsByCategories" }
                );
            });
        }
    }
}