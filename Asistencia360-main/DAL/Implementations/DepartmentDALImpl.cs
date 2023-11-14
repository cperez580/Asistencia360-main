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
    public class DepartmentDALImpl : IDepartmentDAL
    {
        private asistencia360Context _context;
        private UnidadDeTrabajo<Department> unidad;
        public bool Add(Department entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Department>(new asistencia360Context()))
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

        public void AddRange(IEnumerable<Department> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Department> Find(Expression<Func<Department, bool>> predicate)
        {
            IEnumerable<Department> list = null;
            using (unidad = new UnidadDeTrabajo<Department>(new asistencia360Context()))
            {
                list = unidad.genericDAL.Find(predicate);
            }

            return list;
        }

        public async Task<Department> Get(int id)
        {
            Department entity = null;
            using (unidad = new UnidadDeTrabajo<Department>(new asistencia360Context()))
            {
                entity = await unidad.genericDAL.Get(id);
            }

            return entity;
        }

        public async Task<IEnumerable<Department>> GetAll()
        {
            IEnumerable<Department> list = null;
            using (unidad = new UnidadDeTrabajo<Department>(new asistencia360Context()))
            {
                list = await unidad.genericDAL.GetAll();
            }

            return list;
        }

        public bool Remove(Department entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Department> entities)
        {
            throw new NotImplementedException();
        }

        public bool Update(Department entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Department>(new asistencia360Context()))
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

        Department IDALGenerico<Department>.SingleOrDefault(Expression<Func<Department, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
