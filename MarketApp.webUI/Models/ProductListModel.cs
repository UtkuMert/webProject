using MarketApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketApp.webUI.Models
{

    public class PageInfo
    {
        public int TotalProducts { get; set; } //Toplam ürün sayısı
        public int ItemsPerPage { get; set; }   //her sayfada kaç eleman gösterileceği bilgisi
        public int CurrentPage { get; set; }     // o anda hangi sayfada olunduğu bilgisi
        public string CurrentCategory { get; set; } // o anda kiaktif olan(varsa) kategori bilgisi
        public int TotalPages()
        {
            return (int)Math.Ceiling((decimal)TotalProducts / ItemsPerPage);
        }
    }

    public class ProductListModel
    {
        public PageInfo PageInfo { get; set; }
        public List<Product> Products { get; set; }
    }
}
