using MarketApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApp.Business.Abstract
{
    public interface ISepetService
    {
        void InitializeSepet(string userId); // UserId ye göre Sepet kaydı oluşacak.
        Sepet GetSepetByUserId(string userId);
        void AddToChart(string userId, int productId, int quantity);
        void DeleteFromCart(string userId, int productId);
    }
}
