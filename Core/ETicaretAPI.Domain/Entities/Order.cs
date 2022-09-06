using ETicaretAPI.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities
{
    public class Order:BaseEntity
    {
        public Order()
        {
            Products = new HashSet<Product>();
        }
        public string Description { get; set; }
        public string Address { get; set; }
        //Bir siparişte birden fazla ürün bulunabilir
        public ICollection<Product> Products { get; set; }

        //Her sipariş tek bir müşteriye aittir
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
    }
}
