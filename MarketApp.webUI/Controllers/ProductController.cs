//using MarketApp.webUI.Models;
//using MarketApp.webUI.ViewModels;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace MarketApp.webUI.Controllers
//{
//    public class ProductController:Controller
//    {
//        public IActionResult Index()
//        {
//            return View();
//        }

//        public IActionResult list()
//        {
//            var products = new List<Product>()
//            {
//                new Product {Name="Elma",Price=3,Description="tatlı elma",IsApproved=false},
//                new Product {Name="Yesil Elma",Price=3,Description="ekşi elma",IsApproved=true},
//                new Product {Name="Limon",Price=3,Description="tatlı limon",IsApproved=true},
//                new Product {Name="Sarı Leon",Price=3,Description="eksi elma",}
//            };

//            var productViewModel = new ProductViewModel()
//            {
//                Products = products
//            };
//            return View(productViewModel);
            
//        }

//        public IActionResult Details()
//        {
//            return View();
//        }

//    }
//}
