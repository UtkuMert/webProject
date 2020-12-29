using MarketApp.Business.Abstract;
using MarketApp.webUI.Models;
using MarketApp.webUI.ViewModels;
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
    }
   
}
