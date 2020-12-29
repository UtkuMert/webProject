using MarketApp.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarketApp.DataAccess.Concrete.EfCore
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context = new ShopContext();
            if(context.Database.GetPendingMigrations().Count()==0)
            {
                if(context.Categories.Count()==0)
                {
                    context.Categories.AddRange(Categories);
                }
                if (context.Products.Count() == 0)
                {
                    context.Products.AddRange(Products);
                }
                context.SaveChanges();
            }
        }
        private static Category[] Categories = {
            new Category(){Name="Meyve"},
            new Category(){Name="Sebze"},
        };
        private static Product[] Products = {
            new Product(){Name="Elma", Price=10,ImgUrl="1.jpg"},
            new Product(){Name="Armut", Price=20,ImgUrl="2.jpg"},
            new Product(){Name="Ayva", Price=30,ImgUrl="3.jpg"},
            new Product(){Name="Soğan", Price=40,ImgUrl="4.jpg"},
            new Product(){Name="Limon", Price=50,ImgUrl="5.jpg"}
        };
    }
}
