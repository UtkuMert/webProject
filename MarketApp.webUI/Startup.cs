using MarketApp.Business.Abstract;
using MarketApp.Business.Concrete;
using MarketApp.DataAccess.Abstract;
using MarketApp.DataAccess.Concrete.EfCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketApp.webUI
{
    public class Startup
    {
     
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            
            services.AddScoped<IProductRepository, EfCoreProductRepository>(); // IProductRepository �a�r�ld���nda EfCoreProductRepository g�nderilir.
            services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>(); // ICategoryRepository �a�r�ld���nda EfCoreCategoryRepository g�nderilir.

            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                SeedDatabase.Seed();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "products",      // Url'ye products yaz�lmas� durumunda kategori bilgisi gerekmeksizin �r�nler listelenir. 
                    pattern: "products/{category?}",        //kategori bilgisi var ise e�le�en �r�nler listelenir.
                    defaults: new { controller = "User", action = "List" });

                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Home}/{action=index}/{id?}"
                    );
            });
        }
    }
}
