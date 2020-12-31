using MarketApp.DataAccess.Abstract;
using MarketApp.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MarketApp.DataAccess.Concrete.EfCore
{
    public class EfCoreProductRepository : EfCoreGenericRepository<Product, ShopContext>, IProductRepository
    {
        public IEnumerable<Product> GetPopularProducts()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsByCategory(string category, int page, int pageSize) //herhangi bir kategori bilgisi yok ise db'deki tüm bilgileri geriye döndürür.
        {                                                           //kategori bilgisi var ise ona göre filtreleme yapılır.
            using (var context = new ShopContext()) {
                var products = context.Products.AsQueryable();
                if (!string.IsNullOrEmpty(category))
                {
                    products = products
                                        .Include(i => i.ProductCategories)
                                        .ThenInclude(i => i.Category)
                                        .Where(i => i.ProductCategories.Any(a => a.Category.Name.ToLower() == category.ToLower()));
                }
                // return products.ToList();
                return products.Skip((page - 1) * pageSize).Take(pageSize).ToList(); // hesaplamadaki değer kadar ürün ötelenir ve sayfaya getirilir.
                // örnek: page=2, pageSize=2,  2-1=1, 1*2=2, ilk 2 ürünü atla ve sayfaya 2 ürün(3. ve 4.) getir.
            }
            
        }

        public Product GetProductDetails(int id)
        {
            using ( var context = new ShopContext()) //Dispose işlemi
            {
                return context.Products
                    .Where(i => i.Id == id)
                    .Include(i => i.ProductCategories) // Product'tan ProductCategories' e geçiş
                    .ThenInclude(i => i.Category)    //ProductCategories'ten category'e geçiş.
                    .FirstOrDefault();
            }
        }

        public int GetCountByCategory(string category)
        {
            using (var context = new ShopContext())
            {
                var products = context.Products.AsQueryable();
                if (!string.IsNullOrEmpty(category))
                {
                    products = products
                                        .Include(i => i.ProductCategories)
                                        .ThenInclude(i => i.Category)
                                        .Where(i => i.ProductCategories.Any(a => a.Category.Name.ToLower() == category.ToLower()));
                }
                return products.Count();
            }
        }
    }
}
