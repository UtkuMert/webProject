﻿using MarketApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MarketApp.DataAccess.Abstract
{
    public interface IProductRepository:IRepository<Product>
    {
        IEnumerable<Product> GetPopularProducts();
    }
}
