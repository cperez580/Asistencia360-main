using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class UserDALImpl: IUserDAL
    {
        private asistencia360Context _context;
        private UnidadDeTrabajo<User> unidad;

        public bool Add(User entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<User>(new asistencia360Context()))
                {
                    unidad.genericDAL.Add(entity);
                    unidad.Complete();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void AddRange(IEnumerable<User> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Find(Expression<Func<User, bool>> predicate)
        {
            IEnumerable<User> list = null;

            using (unidad = new UnidadDeTrabajo<User>(new asistencia360Context()))
            {
                list = unidad.genericDAL.Find(predicate);
            }

            return list;
        }

        public async Task<User> Get(int id)
        {
            User entity = null;

            using (unidad = new UnidadDeTrabajo<User>(new asistencia360Context()))
            {
                entity = await unidad.genericDAL.Get(id);
            }

            return entity;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            IEnumerable<User> list = null;

            using (unidad = new UnidadDeTrabajo<User>(new asistencia360Context()))
            {
                list = await unidad.genericDAL.GetAll();
            }

            return list;
        }

        public bool Remove(User entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<User>(new asistencia360Context()))
                {
                    unidad.genericDAL.Remove(entity);
                    unidad.Complete();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void RemoveRange(IEnumerable<User> entities)
        {
            throw new NotImplementedException();
        }

        public User SingleOrDefault(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(User entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<User>(new asistencia360Context()))
                {
                    unidad.genericDAL.Update(entity);
                    unidad.Complete();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}