using MarketApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketApp.webUI.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; } // Kategori içerisinde olabilicek ürünleri temsil eden liste
    }
}
