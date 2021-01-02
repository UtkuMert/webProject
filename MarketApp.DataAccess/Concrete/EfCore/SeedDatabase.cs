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
                    context.AddRange(ProductCategory); // Liste eklenir.
                }
                context.SaveChanges();
            }
        }
        private static Category[] Categories = {
            new Category(){Name="Meyve"},
            new Category(){Name="Sebze"}
        };
        private static Product[] Products = {
            new Product(){Name="Elma", Price=10,ImgUrl="elma.jpg", Description="Açıklama"},
            new Product(){Name="Armut", Price=20,ImgUrl="armut.jpg", Description="Açıklama"},
            new Product(){Name="Ayva", Price=30,ImgUrl="ayva.jpg", Description="Açıklama"},
            new Product(){Name="Soğan", Price=40,ImgUrl="sogan.jpg", Description="Açıklama"},
            new Product(){Name="Limon", Price=50,ImgUrl="limon.jpg", Description="Açıklama"}
        };
        private static ProductCategory[] ProductCategory =
        {
            new ProductCategory() {Product = Products[0], Category=Categories[0]},
            new ProductCategory() {Product = Products[1], Category=Categories[0]},
            new ProductCategory() {Product = Products[2], Category=Categories[0]},
            new ProductCategory() {Product = Products[3], Category=Categories[1]},
            new ProductCategory() {Product = Products[4], Category=Categories[0]},
            
        };
    }
}
