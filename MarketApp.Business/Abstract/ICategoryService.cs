using MarketApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApp.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetById(int id);
        Category GetByIdWithProducts(int id); // Category ile ilişkili olan ürün bilgileri için.
        void Create(Category entity);
        void Update(Category entity);
        void Delete(Category entity);
        void DeleteFromCategory(int categoryId, int productId);
    }
}
