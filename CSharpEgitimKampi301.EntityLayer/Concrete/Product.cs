using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.EntityLayer.Concrete
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductStock { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductDesc { get; set; }
        
        //kategori tablosu ile ilişki kurma
        public int CategoryId { get; set; } // her ürünün bir kategorisi olması gerektiği için
        public virtual Category Category { get; set; } // kategori tablosunun değerlerine ürün üzerinde ulaşmak için
        public List<Order> Orders { get; set; }






    }
}
