using MarketApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketApp.webUI.Models
{
    public class ProductModel
    {
        // Bu Model üzerinden entity bilgileri gönderilecek.
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImgUrl { get; set; }
        public string Description { get; set; }

        public List<ProductCategory> ProductCategories { get; set; } 

    }
}
