using DAL.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class DALGenericoImpl<T> : IDALGenerico<T> where T : class
    {
        protected readonly asistencia360Context Context;

        public DALGenericoImpl(asistencia360Context context)
        {
            Context = context;
        }


        public bool Add(T entity)
        {
            try
            {
                Context.Set<T>().Add(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void AddRange(IEnumerable<T> entities)
        {
            try
            {
                Context.Set<T>().AddRange(entities);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return Context.Set<T>().Where(predicate).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<T> Get(int id)
        {
            try
            {
                return await Context.Set<T>().FindAsync(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                return await Context.Set<T>().ToListAsync();

            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool Remove(T entity)
        {
            try
            {
                Context.Set<T>().Attach(entity);
                Context.Set<T>().Remove(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            try
            {
                Context.Set<T>().RemoveRange(entities);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return Context.Set<T>().SingleOrDefault(predicate);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Update(T entity)
        {
            try
            {
                Context.Entry(entity).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
