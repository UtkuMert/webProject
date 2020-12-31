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
            Product product = _productService.GetProductDetails((int)id);
            if (product == null)    // alınan id değerine karşılık bir ürün bulunamamışsa hata döndürür.
            {
                return NotFound();
            }
            return View(new ProductDetailsModel()   // id değeri bulunan ürün categori bilgisiyle gönderilir.
                {
                Product = product,
                Categories = product.ProductCategories.Select(i=>i.Category).ToList()
            }); 
        }
        public IActionResult List(string category, int page=1)     // Tüm kayıtlar listelenir.
        {                                                          //sayfa numarası varsayılan olarak 1 verildi.
            const int pageSize = 5; // bir sayfada bulunacak ürün adedi.
            return View(new ProductListModel()
            {
                PageInfo = new PageInfo()
                {
                    TotalProducts = _productService.GetCountByCategory(category),
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    CurrentCategory=category
                },
                Products = _productService.GetProductsByCategory(category, page, pageSize)  
            }) ;
        }
    }
}
