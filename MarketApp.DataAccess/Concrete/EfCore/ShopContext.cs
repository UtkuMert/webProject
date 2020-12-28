using MarketApp.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApp.DataAccess.Concrete.EfCore
{
    public class ShopContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ShopDB;integrated security=true;");
        }
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

    }
}
