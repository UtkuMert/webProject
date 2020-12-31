using MarketApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApp.Business.Abstract
{
    public interface IProductService
    {
        Product GetById(int id);
        List<Product> GetAll();
        Product GetProductDetails(int id);
        List<Product> GetProductsByCategory(string category, int page, int pageSize);
        void Create(Product entity);
        void Update(Product entity);
        void Delete(Product entity);
        int GetCountByCategory(string category);
    }
}
