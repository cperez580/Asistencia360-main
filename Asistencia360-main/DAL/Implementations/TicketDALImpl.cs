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
    public class TicketDALImpl : ITicketDAL
    {
        private asistencia360Context _context;
        private UnidadDeTrabajo<Ticket> unidad;

        public bool Add(Ticket entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Ticket>(new asistencia360Context()))
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

        public void AddRange(IEnumerable<Ticket> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ticket> Find(Expression<Func<Ticket, bool>> predicate)
        {
            IEnumerable<Ticket> list = null;

            using (unidad = new UnidadDeTrabajo<Ticket>(new asistencia360Context()))
            {
                list = unidad.genericDAL.Find(predicate);
            }

            return list;
        }

        public async Task<Ticket> Get(int id)
        {
            Ticket entity = null;

            using (unidad = new UnidadDeTrabajo<Ticket>(new asistencia360Context()))
            {
                entity = await unidad.genericDAL.Get(id);
            }

            return entity;
        }

        public async Task<IEnumerable<Ticket>> GetAll()
        {
            IEnumerable<Ticket> list = null;

            using (unidad = new UnidadDeTrabajo<Ticket>(new asistencia360Context()))
            {
                list = await unidad.genericDAL.GetAll();
            }

            return list;
        }

        public bool Remove(Ticket entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Ticket>(new asistencia360Context()))
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

        public void RemoveRange(IEnumerable<Ticket> entities)
        {
            throw new NotImplementedException();
        }

        public Ticket SingleOrDefault(Expression<Func<Ticket, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Ticket entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Ticket>(new asistencia360Context()))
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