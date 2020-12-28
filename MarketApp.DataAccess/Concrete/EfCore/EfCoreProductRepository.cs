﻿using MarketApp.DataAccess.Abstract;
using MarketApp.Entity;
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
    }
}
