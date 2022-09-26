using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.ViewModels.ProductsVM
{
        public class ProductListWCount
        {
            public IList<ProductListViewModel> ProductListViewModel { get; set; }
            public int TotalCount { get; set; }
        }
}
