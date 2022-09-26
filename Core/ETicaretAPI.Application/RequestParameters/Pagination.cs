using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.RequestParameters
{
    public record Pagination
    {
        public int PageSize { get; set; } = 5;
        public int PageNumber { get; set; } = 0;
        public int TotalDataCount { get; set; }

    }
}
