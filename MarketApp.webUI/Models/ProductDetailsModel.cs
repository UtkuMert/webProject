using MarketApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketApp.webUI.Models
{
    public class ProductDetailsModel
    {
        //Detay sayfasına gönderilecek ekstra bilgiler için bu sınıf genişletilebilir.

        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
    }
}
