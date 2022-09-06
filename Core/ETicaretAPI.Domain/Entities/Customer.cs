using ETicaretAPI.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities
{
    public class Customer:BaseEntity
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }
        public string Name { get; set; }
        //Bir müşterinin birden fazla siparişi olabilir
        public ICollection<Order> Orders { get; set; }
    }
}
