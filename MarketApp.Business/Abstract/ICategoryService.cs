using MarketApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApp.Business.Abstract
{
    interface ICategoryService
    {
        List<Category> GetAll();
        void Create(Category entity);
        void Update(Category entity);
        void Delete(Category entity);
    }
}
