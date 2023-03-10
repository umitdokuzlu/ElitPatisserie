using ElitPatisserie.Business.Abstract;
using ElitPatisserie.Business.Concrete;
using ElitPatisserie.Data.Abstract;
using ElitPatisserie.Data.Concrete.EntityFramework.Contexts;
using ElitPatisserie.Data.Concrete.EntityFramework.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ElitPatisserie.MVC
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
            services.AddScoped<ICategoryRepository, EfCategoryRepository>();
            services.AddScoped<IChefRepository, EfChefRepository>();
            services.AddScoped<IContactRepository, EfContactRepository>();
            services.AddScoped<IHomeSliderRepository, EfHomeSliderRepository>();
            services.AddScoped<IMenuSliderRepository, EfMenuSliderRepository>();
            services.AddScoped<IProductRepository, EfProductRepository>();
            services.AddScoped<IUserRepository, EfUserRepository>();

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IChefService, ChefManager>();
            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IHomeSliderService, HomeSliderManager>();
            services.AddScoped<IMenuSliderService, MenuSliderManager>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IUserService, UserManager>();


            services.AddDbContext<ElitPatisserieContext>();
            services.AddControllersWithViews();

            services.AddSession();

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                           .RequireAuthenticatedUser()
                           .Build();
                config.Filters.Add(new AuthorizeFilter(policy));

            });
            services.AddMvc();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(x =>
                {
                    x.LoginPath = "/Login/Index";
                });

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
