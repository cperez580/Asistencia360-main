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
    public class InternalServiceDALImpl : IInternalServiceDAL
    {
        private asistencia360Context _context;
        private UnidadDeTrabajo<InternalService> unidad;
        public bool Add(InternalService entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<InternalService>(new asistencia360Context()))
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

        public void AddRange(IEnumerable<InternalService> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InternalService> Find(Expression<Func<InternalService, bool>> predicate)
        {
            IEnumerable<InternalService> list = null;
            using (unidad = new UnidadDeTrabajo<InternalService>(new asistencia360Context()))
            {
                list = unidad.genericDAL.Find(predicate);
            }

            return list;
        }

        public async Task<InternalService> Get(int id)
        {
            InternalService entity = null;
            using (unidad = new UnidadDeTrabajo<InternalService>(new asistencia360Context()))
            {
                entity = await unidad.genericDAL.Get(id);
            }

            return entity;
        }

        public async Task<IEnumerable<InternalService>> GetAll()
        {
            IEnumerable<InternalService> list = null;
            using (unidad = new UnidadDeTrabajo<InternalService>(new asistencia360Context()))
            {
                list = await unidad.genericDAL.GetAll();
            }

            return list;
        }

        public bool Remove(InternalService entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<InternalService> entities)
        {
            throw new NotImplementedException();
        }

        public InternalService SingleOrDefault(Expression<Func<InternalService, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(InternalService entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<InternalService>(new asistencia360Context()))
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

        InternalService IDALGenerico<InternalService>.SingleOrDefault(Expression<Func<InternalService, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
