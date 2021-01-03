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
            new Category(){Name="Yiyecek"},
            new Category(){Name="Giyim"},
            new Category(){Name="Meyve"},
            new Category(){Name="Sebze"}
        };
        private static Product[] Products = {
            new Product(){Name="Elma", Price=5,ImgUrl="elma.jpg", Description="<p>Taze ve dogal kırmızı elma</p>"},
            new Product(){Name="Domates", Price=4,ImgUrl="domates.jpg", Description="<p>Taze ve dogal</p>"},
            new Product(){Name="Tisört", Price=40,ImgUrl="siyahtisört.jpg", Description="Açıklama"},
            new Product(){Name="Balık", Price=50,ImgUrl="balık.jpg", Description="Açıklama"}
        };
        private static ProductCategory[] ProductCategory =
        {
            new ProductCategory() {Product = Products[0], Category=Categories[0]},
            new ProductCategory() {Product = Products[0], Category=Categories[2]},
            new ProductCategory() {Product = Products[1], Category=Categories[0]},
            new ProductCategory() {Product = Products[1], Category=Categories[3]},
            new ProductCategory() {Product = Products[2], Category=Categories[1]},
            new ProductCategory() {Product = Products[3], Category=Categories[0]}
        };
    }
}
