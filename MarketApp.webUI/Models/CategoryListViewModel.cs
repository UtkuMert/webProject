using MarketApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketApp.webUI.Models
{
    public class CategoryListViewModel
    {
        public string SelectedCategory { get; set; } // seçilmiş kategori bilgisini tutar.
        public List<Category> Categories { get; set; }
    }
}
