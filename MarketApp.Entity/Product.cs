using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApp.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImgUrl { get; set; }

        public List<ProductCategory> ProductCategories { get; set; } //Cok-Cok bagintisi

    }
}
