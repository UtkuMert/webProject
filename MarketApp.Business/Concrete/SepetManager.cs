using MarketApp.Business.Abstract;
using MarketApp.DataAccess.Abstract;
using MarketApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApp.Business.Concrete
{
    public class SepetManager : ISepetService
    {
        private ISepetRepository _sepetRepository;
        public SepetManager(ISepetRepository sepetRepository)
        {
            _sepetRepository = sepetRepository;
        }

        public void AddToChart(string userId, int productId, int quantity)
        {
            var cart = GetSepetByUserId(userId);
            if (cart != null) // Kullanıcının bir sepeti olup olmadığı kontrol edilir
            {
                var index = cart.SepetItems.FindIndex(i => i.ProductId == productId); // 
                if (index <0)
                {
                    cart.SepetItems.Add(new SepetItem()
                    {
                        ProductId = productId,
                        Quantity = quantity,
                        SepetId = cart.Id
                    });
                }  
                else
                {
                    cart.SepetItems[index].Quantity += quantity;
                }
                _sepetRepository.Update(cart);
            }
        }

        public void DeleteFromCart(string userId, int productId)
        {
            var cart = GetSepetByUserId(userId);
            if (cart != null)
            {
                _sepetRepository.DeleteFromCart(cart.Id, productId);
            }
        }

        public Sepet GetSepetByUserId(string userId)
        {
            return _sepetRepository.GetByUserId(userId);
        }

        public void InitializeSepet(string userId)
        {
            _sepetRepository.Create(new Sepet() { UserId = userId });
        }
    }
}
