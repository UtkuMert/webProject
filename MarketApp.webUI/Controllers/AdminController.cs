using MarketApp.Business.Abstract;
using MarketApp.Entity;
using MarketApp.webUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MarketApp.webUI.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        public AdminController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        //Product işlemleri
        public IActionResult ProductList()
        {
            
            return View(new ProductListModel
            { 
            Products = _productService.GetAll()
            });
        }
        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View(new ProductModel());
        }
        [HttpPost]
        public IActionResult CreateProduct(ProductModel model)
        {

            if (ModelState.IsValid) // ProductModel'den oluşturulan kopyada girilen veriler kurallara uygun biçimde geldi ise true döner.
            {
                var entity = new Product()
                {
                    Name = model.Name,
                    Price = model.Price,
                    Description = model.Description,
                    ImgUrl = model.ImgUrl
                };
                _productService.Create(entity); // oluşturma işlemi db'de yapılır.

                return RedirectToAction("ProductList"); //Ekleme işleminden sonra ProductList'e yönlendirilerek direkt ürün listesiyle karşılaşılır.

            }
            return View(model); // Doğrulama işlemi hatalı olursa tekrar aynı sayfaya döndürülür.

        }
        public IActionResult EditProduct(int? id)
        {
            if(id == null) // herhangi bir id bilgisi gelmezse
            {
                return NotFound();
            }
            // 
            var entity = _productService.GetByIdWithCategories((int)id); // id gelirse nullable tipinden int'e çevrilmeli 
            if (entity == null)
            {
                return NotFound(); // olmayan ürüne işlem yapılamayacağından dolayı.
            }
            var model = new ProductModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,
                Description = entity.Description,
                ImgUrl = entity.ImgUrl,
                SelectedCategories = entity.ProductCategories.Select(i => i.Category).ToList() //seçili olan kategori bilgileri
            };
            ViewBag.Categories = _categoryService.GetAll(); // DB'deki tüm kategorileri getirir.
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditProduct(ProductModel model, int[] categoryIds, IFormFile file) // seçili olan kategori dizi şeklinde alınır.
        {                                                                                       // "file" = inputtan gelen control name
            if(ModelState.IsValid)
            {
                var entity = _productService.GetById(model.Id);
                if (entity == null)
            {
                return NotFound();
            }
            entity.Name = model.Name;
            entity.Price = model.Price;
            entity.Description = model.Description;
            
            if (file != null)
            {
                entity.ImgUrl = file.FileName;

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", file.FileName); //Root dizinindeki image klasörünün yolu gösterildi, kullanılacak isime göre arama yapıp ekler

                    using (var stream = new FileStream(path, FileMode.Create)) //pathe resmin gönderilmesi
                    {
                        await file.CopyToAsync(stream);
                    }
            }

                _productService.Update(entity, categoryIds); // güncelleme db'de işlemi yapılır

            return RedirectToAction("ProductList");
                // url'ye değil de Rout'a yönlendirme işlemi yapıldı. güncellemeden sonra kullanıcı index'e gönderilir
                // ProductList'e karşılık gelen Url, Rout içerisinden alınacak.
            }
            else
            {
                ViewBag.Categories = _categoryService.GetAll(); // DB'deki tüm kategorileri getirir.
                return View(model);
            }
        }
        [HttpPost]
        public IActionResult DeleteProduct(int productId)
        {
            var entity = _productService.GetById(productId);
            if (entity != null)
            {
                _productService.Delete(entity);
            }
            return RedirectToAction("ProductList");
        }
        // Kategori işlemleri
        public IActionResult CategoryList()
        {
            return View(new CategoryListModel()
             {
                Categories = _categoryService.GetAll()
            });
        }
        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var entity = _categoryService.GetByIdWithProducts(id); // id gönderiyoruz, bize bir kategori bilgisi geliyor
            // onun yanında da o kategoriye ait olan ürünler geliyor. 

            return View(new CategoryModel() 
            {
                Id = entity.Id,             // Db'den gelen Id ve Name Model olarak sayfaya gönderilir.
                Name = entity.Name,
                Products = entity.ProductCategories.Select(p=>p.Product).ToList()
            });
           
        }
        [HttpPost]
        public IActionResult EditCategory(CategoryModel model)
        {
            var entity = _categoryService.GetById(model.Id);
            if (entity ==null)
            {                                              
                return NotFound(); 
            }                                           
            entity.Name = model.Name;                        // Modelden gelen bilgiler db'de güncellenir.
            _categoryService.Update(entity);
            return RedirectToAction("CategoryList");

        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            
            return View();

        }
        [HttpPost]
        public IActionResult CreateCategory(CategoryModel model)
        {
            var entity = new Category()
            {
                Name = model.Name
            };
            _categoryService.Create(entity);
            return RedirectToAction("CategoryList");

        }
        [HttpPost]
        public IActionResult DeleteCategory(int categoryId)
        {
            var entity = _categoryService.GetById(categoryId);
            if (entity != null)
            {
                _categoryService.Delete(entity);
            }
            return RedirectToAction("CategoryList");

        }
        [HttpPost]
        public IActionResult DeleteFromCategory(int categoryId, int productId) // hangi kategorideki hangi ürün
        {
            _categoryService.DeleteFromCategory(categoryId, productId);
            return Redirect("/admin/editcategory/"+categoryId); //editcategory'e istediği parametre gönderilir.
        }

    }
}
