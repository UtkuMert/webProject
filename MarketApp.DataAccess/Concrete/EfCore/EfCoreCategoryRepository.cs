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
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category, ShopContext>, ICategoryRepository
    {
        public void DeleteFromCategory(int categoryId, int productId)
        {
           using (var context = new ShopContext())
            {
                var cmd = @"delete from ProductCategory where ProductId=@p0 And CategoryId=@p1";
                context.Database.ExecuteSqlRaw(cmd, productId, categoryId);
            }
        }

        public Category GetByIdWithProducts(int id)
        {                                                       
            using (var context = new ShopContext()) 
            {
                return context.Categories                       //Category entity'si içerisinde bir category bilgisi, onun yanında da
                    .Where(i => i.Id == id)                     // o category e ait tüm product bilgileri gelecek.
                    .Include(i => i.ProductCategories)
                    .ThenInclude(i => i.Product)
                    .FirstOrDefault();
                    
            }
        }
    }
}
