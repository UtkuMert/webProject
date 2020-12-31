using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketApp.Business.Abstract;
using MarketApp.webUI.Models;

namespace MarketApp.webUI.ViewComponents
{
    public class CategoryListViewComponent:ViewComponent
    {
        private ICategoryService _categoryService;
        public CategoryListViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IViewComponentResult Invoke()
        {
            //Tüm category bilgileri view' e taşınır.
            return View(new CategoryListViewModel()
            { 
                SelectedCategory = RouteData.Values["category"]?.ToString(), // null olan bir değer stringe çevrilemediğinden dolayı null olup olmadığı "?" ile sorgulanır.
                Categories = _categoryService.GetAll()
            });
        }
    }
}
