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
    public class ServiceDALImpl: IServiceDAL
    {
        private asistencia360Context _context;
        private UnidadDeTrabajo<Service> unidad;

        public bool Add(Service entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Service> (new asistencia360Context()))
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

        public void AddRange(IEnumerable<Service> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Service> Find(Expression<Func<Service, bool>> predicate)
        {
            IEnumerable<Service> list = null;

            using (unidad = new UnidadDeTrabajo<Service>(new asistencia360Context()))
            {
                list = unidad.genericDAL.Find(predicate);
            }

            return list;
        }

        public async Task<Service> Get(int id)
        {
            Service entity = null;

            using (unidad = new UnidadDeTrabajo<Service>(new asistencia360Context()))
            {
                entity = await unidad.genericDAL.Get(id);
            }

            return entity;
        }

        public async Task<IEnumerable<Service>> GetAll()
        {
            IEnumerable<Service> list = null;

            using (unidad = new UnidadDeTrabajo<Service>(new asistencia360Context()))
            {
                list = await unidad.genericDAL.GetAll();
            }

            return list;
        }

        public bool Remove(Service entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Service> entities)
        {
            throw new NotImplementedException();
        }

        public Service SingleOrDefault(Expression<Func<Service, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Service entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Service>(new asistencia360Context()))
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
