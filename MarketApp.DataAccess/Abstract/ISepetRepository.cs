using MarketApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApp.DataAccess.Abstract
{
    public interface ISepetRepository : IRepository<Sepet>
    {
        Sepet GetByUserId(string userId);
        void DeleteFromCart(int cartId, int productId);
    }
}
