using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApp.Entity
{
    public class Sepet
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public List<SepetItem> SepetItems { get; set; } // Kullanıcının sepetinden sepetItems çağrıldığıgında Sepet içerisinde olan tüm sepet bilgileri alınacak. 
    }
}
