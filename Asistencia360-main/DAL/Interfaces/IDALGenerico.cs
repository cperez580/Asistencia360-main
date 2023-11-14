using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDALGenerico<T> where T : class
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        T SingleOrDefault(Expression<Func<T, bool>> predicate);
        bool Add(T entity);
        void AddRange(IEnumerable<T> entities);
        bool Update(T entity);
        bool Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
