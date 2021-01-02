using MarketApp.Business.Abstract;
using MarketApp.Business.Concrete;
using MarketApp.DataAccess.Abstract;
using MarketApp.DataAccess.Concrete.EfCore;
using MarketApp.webUI.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        private IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<UserIdentityDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection")));

            services.AddIdentity<UserIdentity, IdentityRole>()
                .AddEntityFrameworkStores<UserIdentityDbContext>()
                .AddDefaultTokenProviders(); //Sifre reset veya mail değismede benzersiz bir token üretir
            services.Configure<IdentityOptions>(options =>
            {
                //sifre
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 1;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;


                options.Lockout.MaxFailedAccessAttempts = 5; //yanlıs girme hakı
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
                options.Lockout.AllowedForNewUsers = true; //yeni kullanıcıda yanlıs girme hakki

                options.User.RequireUniqueEmail = true; //aynı mail ile olusmaz
                options.SignIn.RequireConfirmedEmail = false; //mail onayi
                options.SignIn.RequireConfirmedPhoneNumber = false;//telefon onayi
            });

            services.ConfigureApplicationCookie(options => 
            {
                options.LoginPath = "/account/login";
                options.LogoutPath = "/account/logout";
                options.AccessDeniedPath = "/account/accessdenied"; //giris hakki olmayan yerden buraya yonlendirir
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60); //cookie saklanmasi
                options.SlidingExpiration = true;
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = ".MarketApp.Security.Cookie", //disardan script bu bilgilere ulasması engellenir
                    SameSite = SameSiteMode.Strict
                };
            });

            services.AddControllersWithViews();
            
            services.AddScoped<IProductRepository, EfCoreProductRepository>(); // IProductRepository cagrıldıgında EfCoreProductRepository gönderilir.
            services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>(); // ICategoryRepository cagrıldıgında EfCoreCategoryRepository gönderilir.

            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,UserManager<UserIdentity> userManager, RoleManager<IdentityRole> roleManager)
        {
            app.UseStaticFiles();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                SeedDatabase.Seed();
                SeedIdentity.Seed(userManager,roleManager,Configuration).Wait();
            }

            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                name: "adminProducts",                 // id parametresi ile birlikte gönderirse edit iþlemi yapmak istediði anlaþýlýr.
                pattern: "admin/{products}/{id?}",    
                defaults: new { controller = "Admin", action = "EditProduct" });

                endpoints.MapControllerRoute(
                  name: "adminProducts",
                  pattern: "admin/{products}",
                  defaults: new { controller = "Admin", action = "ProductList" });

                endpoints.MapControllerRoute(
                    name: "products",      // Url'ye products yazilmasi durumunda kategori bilgisi gerekmeksizin urunler listelenir. 
                    pattern: "products/{category?}",        //kategori bilgisi var ise eslesen urunler listelenir.
                    defaults: new { controller = "User", action = "List" });

                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Home}/{action=index}/{id?}"
                    );
            });
        }
    }
}
