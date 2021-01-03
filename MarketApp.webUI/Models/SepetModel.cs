using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketApp.webUI.Models
{
    public class SepetModel
    {
        public int SepetId { get; set; }
        public List<SepetItemModel> SepetItems { get; set; }
        public double TotalPrice()
        {
            return SepetItems.Sum(i => i.Price * i.Quantity);
        }
    }
    public class SepetItemModel
    {
        public int SepetItemId { get; set; } // Db'den eklenen her bir ürüne karşılık gelir.
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
    }
}
