using MarketApp.webUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketApp.webUI.ViewComponents
{
    public class CategoriesViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var categories = new List<Category>()
            {
                new Category {Name="Meyveler",Description="Meyve Bölümü"},
                new Category {Name="Sebzeler",Description="Sebze Bölümü"},
                new Category {Name="Kıyafet",Description="Kıyafet Bölümü"}
            };

            return View(categories);
        }
    }
}
