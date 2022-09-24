using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.BL.Interface;
using WebApplication7.BL.Repository;
using WebApplication7.DAL.Database;
using AutoMapper;
using WebApplication7.BL.Mapper;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Identity;

namespace WebApplication7
{
    public class Startup
    {

        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {



            services.AddControllersWithViews()
                    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                    .AddDataAnnotationsLocalization()
                    .AddNewtonsoftJson(opt => {
                        opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    });

            services.AddDbContextPool<DbContainer>(opts =>
            opts.UseSqlServer(Configuration.GetConnectionString("SharpDbConnection")));


            services.AddIdentity<IdentityUser, IdentityRole>(options => { 

             // Default Password settings.
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 3;
            options.Password.RequiredUniqueChars = 0;

        }).AddEntityFrameworkStores<DbContainer>()
        .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>(TokenOptions.DefaultProvider);



            services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));

            // Take Instance Every Request
            //services.AddTransient<DepartmentRep>();

            // Take One Instance For Each User
            services.AddScoped<IDepartmentRep,DepartmentRep>();
            services.AddScoped<IEmployeeRep, EmployeeRep>();
            services.AddScoped<ICountryRep, CountryRep>();
            services.AddScoped<ICityRep, CityRep>();
            services.AddScoped<IDistrictRep, DistrictRep>();

            // Take Shared Instance For All Users
            //services.AddSingleton<DepartmentRep>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }


            // Take Instance From Languages
            var supportedCultures = new[] {
                  new CultureInfo("ar-EG"),
                  new CultureInfo("en-US"),
            };


            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
                RequestCultureProviders = new List<IRequestCultureProvider>
                {
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider()
                }
            });




            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}
