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
    public class HardDriveDALImpl : IHardDriveDAL
    {
        private asistencia360Context _context;
        private UnidadDeTrabajo<HardDrive> unidad;
        public bool Add(HardDrive entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<HardDrive>(new asistencia360Context()))
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

        public void AddRange(IEnumerable<HardDrive> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HardDrive> Find(Expression<Func<HardDrive, bool>> predicate)
        {
            IEnumerable<HardDrive> list = null;
            using (unidad = new UnidadDeTrabajo<HardDrive>(new asistencia360Context()))
            {
                list = unidad.genericDAL.Find(predicate);
            }

            return list;
        }

        public async Task<HardDrive> Get(int id)
        {
            HardDrive entity = null;
            using (unidad = new UnidadDeTrabajo<HardDrive>(new asistencia360Context()))
            {
                entity = await unidad.genericDAL.Get(id);
            }

            return entity;
        }

        public async Task<IEnumerable<HardDrive>> GetAll()
        {
            IEnumerable<HardDrive> list = null;
            using (unidad = new UnidadDeTrabajo<HardDrive>(new asistencia360Context()))
            {
                list = await unidad.genericDAL.GetAll();
            }

            return list;
        }

        public bool Remove(HardDrive entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<HardDrive> entities)
        {
            throw new NotImplementedException();
        }

        public bool Update(HardDrive entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<HardDrive>(new asistencia360Context()))
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

        HardDrive IDALGenerico<HardDrive>.SingleOrDefault(Expression<Func<HardDrive, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
