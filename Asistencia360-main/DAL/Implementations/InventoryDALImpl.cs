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
    public class InventoryDALImpl : IInventoryDAL
    {
        private asistencia360Context _context;
        private UnidadDeTrabajo<Inventory> unidad;
        public bool Add(Inventory entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Inventory>(new asistencia360Context()))
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

        public void AddRange(IEnumerable<Inventory> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Inventory> Find(Expression<Func<Inventory, bool>> predicate)
        {
            IEnumerable<Inventory> list = null;
            using (unidad = new UnidadDeTrabajo<Inventory>(new asistencia360Context()))
            {
                list = unidad.genericDAL.Find(predicate);
            }

            return list;
        }

        public async Task<Inventory> Get(int id)
        {
            Inventory entity = null;
            using (unidad = new UnidadDeTrabajo<Inventory>(new asistencia360Context()))
            {
                entity = await unidad.genericDAL.Get(id);
            }

            return entity;
        }

        public async Task<IEnumerable<Inventory>> GetAll()
        {
            IEnumerable<Inventory> list = null;
            using (unidad = new UnidadDeTrabajo<Inventory>(new asistencia360Context()))
            {
                list = await unidad.genericDAL.GetAll();
            }

            return list;
        }

        public bool Remove(Inventory entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Inventory> entities)
        {
            throw new NotImplementedException();
        }

        public bool Update(Inventory entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Inventory>(new asistencia360Context()))
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

        Inventory IDALGenerico<Inventory>.SingleOrDefault(Expression<Func<Inventory, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
