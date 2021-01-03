using System;
using System.Collections.Generic;
using System.Text;

namespace MarketApp.Entity
{
    //Sepette bulunan her bir ürünü temsil edecek
    public class SepetItem
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }  // kullanıcı hangi ürünü eklemiş

        public Sepet Sepet { get; set; }
        public int SepetId { get; set; }  
        // 1 Sepetin içerisinde 1 ürün olur. 
        // Aynı sepete aynı id'li ikinci ürün eklenirse quantity arttırılacak.
        public int Quantity { get; set; }   // kaç tane eklemiş
    }
}
 