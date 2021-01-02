using MarketApp.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketApp.webUI.Models
{
    public class ProductModel
    {
        // Bu Model üzerinden entity bilgileri gönderilecek.
        public int Id { get; set; }

        [Required]
        [StringLength(20,MinimumLength =5, ErrorMessage ="En az 5 en fazla 20 karakter girebilirsiniz.")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Bir Fiyat belirtiniz")]
        [Range(0,10000)]  // Price negatif olamaz.
        public double? Price { get; set; }
        [Required]
        public string ImgUrl { get; set; }
        public string Description { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
        public List<Category> SelectedCategories { get; set; } // Daha önceden ürün ile ilişkilendirilmiş bir kategori varsa seçili olarak gelir.
        
    }
}
 