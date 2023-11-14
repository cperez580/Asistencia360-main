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
    public class CompanyDALImpl: ICompanyDAL
    {
        private asistencia360Context _context;
        private UnidadDeTrabajo<Company> unidad;
        public bool Add(Company entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Company>(new asistencia360Context()))
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

        public void AddRange(IEnumerable<Company> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Company> Find(Expression<Func<Company, bool>> predicate)
        {
            IEnumerable<Company> list = null;
            using (unidad = new UnidadDeTrabajo<Company>(new asistencia360Context()))
            {
                list = unidad.genericDAL.Find(predicate);
            }

            return list;
        }

        public async Task<Company> Get(int id)
        {
            Company entity = null;
            using (unidad = new UnidadDeTrabajo<Company>(new asistencia360Context()))
            {
                entity = await unidad.genericDAL.Get(id);
            }

            return entity;
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            IEnumerable<Company> list = null;
            using (unidad = new UnidadDeTrabajo<Company>(new asistencia360Context()))
            {
                list = await unidad.genericDAL.GetAll();
            }

            return list;
        }

        public bool Remove(Company entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Company> entities)
        {
            throw new NotImplementedException();
        }

        public Company SingleOrDefault(Expression<Func<Company, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Company entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Company>(new asistencia360Context()))
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
