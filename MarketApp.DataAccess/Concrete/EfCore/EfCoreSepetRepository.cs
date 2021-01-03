using MarketApp.DataAccess.Abstract;
using MarketApp.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarketApp.DataAccess.Concrete.EfCore
{
    public class EfCoreSepetRepository : EfCoreGenericRepository<Sepet, ShopContext>, ISepetRepository
    {
        public void DeleteFromCart(int cartId, int productId)
        {
            using (var context = new ShopContext())
            {
                var cmd = @"delete from SepetItem where SepetId=@p0 And ProductId=@p1";
                context.Database.ExecuteSqlRaw(cmd, cartId, productId);
            }
        }

        public Sepet GetByUserId(string userId)
        {
            using (var context = new ShopContext())
            {
                return context.Sepets
                                     .Include(i => i.SepetItems)
                                     .ThenInclude(i => i.Product)
                                     .FirstOrDefault(i=>i.UserId == userId);
            }
        }
        public override void Update(Sepet entity)
        {

            using (var context = new ShopContext())
            {
                context.Sepets.Update(entity);
                context.SaveChanges();
            }
        }
    }
}
