using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.EntityLayer.Concrete
{
    public class Order
    {
        public int OrderId { get; set; }

        //ürün tablosuyla ilişkilendirdik
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; } // kaç adet satıldı
        public decimal UnitPrice { get; set; } // birim fiyatı
        public decimal TotalPrice { get; set; } // toplam fiyatı
        public int CustomerId { get; set; } // ürün kime satıldı
        public virtual Customer Customer { get; set; } // diğer bilgiler
    }
}
