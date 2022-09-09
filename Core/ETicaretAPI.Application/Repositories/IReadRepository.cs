using ETicaretAPI.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        //Tüm verileri getirir
        IQueryable<T> GetAll(bool isTracked=true);
        //Tüm verileri filtreli bir şekilde getirir
        IQueryable<T> GetAll(Expression<Func<T, bool>> expression,bool isTracked= true);
        //Verilen filtreye göre ilk kaydı getirir
        Task<T> GetAsync(Expression<Func<T, bool>> expression, bool isTracked = true);
        //Verilen id ye ait kaydı getirir
        Task<T> GetByIdAsync(string id, bool isTracked = true);
        //Verilen filtreleme neticesinde kayıt var ise true,yok ise false döner
        Task<bool> AnyAsync(Expression<Func<T,bool>> expression, bool isTracked = true);
        //Verilen filtreleme neticesinde kaç kayıt geliyorsa onu count eder
        Task<int> CountAsync(Expression<Func<T, bool>> expression, bool isTracked = true);

    }
}
