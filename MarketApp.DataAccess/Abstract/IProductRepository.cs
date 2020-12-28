using MarketApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MarketApp.DataAccess.Abstract
{
    public interface IProductRepository
    {
        Product GetById(int id);

        Product GetOne(Expression<Func<Product, bool>> filter);

        IQueryable<Product> GetAll(Expression<Func<Product, bool>> filter);

        void Create(Product entity);
        void Update(Product entity);
        void Delete(Product entity);

    }
}
