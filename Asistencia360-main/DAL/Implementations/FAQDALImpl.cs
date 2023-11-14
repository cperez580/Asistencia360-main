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
    public class FAQDALImpl : IFAQDAL
    {
        private asistencia360Context _context;
        private UnidadDeTrabajo<Faq> unidad;
        public bool Add(Faq entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Faq>(new asistencia360Context()))
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

        public void AddRange(IEnumerable<Faq> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Faq> Find(Expression<Func<Faq, bool>> predicate)
        {
            IEnumerable<Faq> list = null;
            using (unidad = new UnidadDeTrabajo<Faq>(new asistencia360Context()))
            {
                list = unidad.genericDAL.Find(predicate);
            }

            return list;
        }

        public async Task<Faq> Get(int id)
        {
            Faq entity = null;
            using (unidad = new UnidadDeTrabajo<Faq>(new asistencia360Context()))
            {
                entity = await unidad.genericDAL.Get(id);
            }

            return entity;
        }

        public async Task<IEnumerable<Faq>> GetAll()
        {
            IEnumerable<Faq> list = null;
            using (unidad = new UnidadDeTrabajo<Faq>(new asistencia360Context()))
            {
                list = await unidad.genericDAL.GetAll();
            }

            return list;
        }

        public bool Remove(Faq entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Faq> entities)
        {
            throw new NotImplementedException();
        }

        public bool Update(Faq entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Faq>(new asistencia360Context()))
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

        Faq IDALGenerico<Faq>.SingleOrDefault(Expression<Func<Faq, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
