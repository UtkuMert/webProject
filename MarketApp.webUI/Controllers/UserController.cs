using MarketApp.DataAccess.Abstract;
using MarketApp.Entity;
using MarketApp.webUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketApp.webUI.Controllers
{
    public class UserController : Controller
    {
        private IProductRepository _productService;
        public UserController(IProductRepository productService)
        {
            _productService = productService;
        }
        public IActionResult Details(int? id)
        {
            if (id == null) // herhangi bir id değeri girilmemiş ise hata döndürür.
            {
                return NotFound();
            }
            Product product = _productService.GetById((int)id);
            if (product == null)    // alınan id değerine karşılık bir ürün bulunamamışsa hata döndürür.
            {
                return NotFound();
            }
            return View(product); // id değeri bulunan ürün gönderilir.
        }
        public IActionResult List()     // Tüm kayıtlar listelenir.
        {
            return View(new ProductListModel()
            {
                Products = _productService.GetAll()  
            }) ;
        }
    }
}
