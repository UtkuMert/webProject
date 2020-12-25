using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketApp.webUI.Models
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string IsApproved { get; set; }
    }
}
