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
            services.AddScoped<IProductRepository, EfCoreProductRepository>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddControllersWithViews();
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
                   name: "default",
                   pattern: "{controller=Home}/{action=index}/{id?}"
                    );
            });
        }
    }
}
