using ETicaretAPI.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities
{
    public class Product:BaseEntity
    {
        public Product()
        {
            Orders = new HashSet<Order>();
            ProductImages = new HashSet<ProductImages>();
        }
        public string Name { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
        //bir ürün brden fazla siparişte bulunabilir
        public ICollection<Order> Orders { get; set; }
        public ICollection<ProductImages> ProductImages { get; set; }
    }
}
