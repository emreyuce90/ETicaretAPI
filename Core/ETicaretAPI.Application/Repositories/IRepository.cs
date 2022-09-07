using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories
{
    public interface IRepository<T> where T:class
    {
        //Veritabanımızdaki tablomuza işaret eder
        DbSet<T> Table { get; }
    }
}
