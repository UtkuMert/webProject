using MarketApp.Business.Abstract;
using MarketApp.webUI.Models;
using MarketApp.webUI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketApp.webUI.Controllers
{
    public class HomeController:Controller
    {
        private IProductService _productService;
        public HomeController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
                
            return View(new ProductListModel() { 
                Products = _productService.GetAll()
            });
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult ChangeLanguage(string returnUrl)
        {
            var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = rqf.RequestCulture.Culture;

            if (culture.Name == "en-US")
            {
                Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture("tr")),
                    new CookieOptions { Expires = DateTimeOffset.Now.AddDays(10) });
            }
            else
            {
                Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture("en-US")),
                    new CookieOptions { Expires = DateTimeOffset.Now.AddDays(10) });
            }

            return Redirect(returnUrl);
        }
    }
   
}
