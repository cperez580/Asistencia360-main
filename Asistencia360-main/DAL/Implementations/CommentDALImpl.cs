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
    public class CommentDALImpl : ICommentDAL
    {
        private asistencia360Context _context;
        private UnidadDeTrabajo<Comment> unidad;
        public bool Add(Comment entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Comment>(new asistencia360Context()))
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

        public void AddRange(IEnumerable<Comment> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> Find(Expression<Func<Comment, bool>> predicate)
        {
            IEnumerable<Comment> list = null;
            using (unidad = new UnidadDeTrabajo<Comment>(new asistencia360Context()))
            {
                list = unidad.genericDAL.Find(predicate);
            }

            return list;
        }

        public async Task<Comment> Get(int id)
        {
            Comment entity = null;
            using (unidad = new UnidadDeTrabajo<Comment>(new asistencia360Context()))
            {
                entity = await unidad.genericDAL.Get(id);
            }

            return entity;
        }

        public async Task<IEnumerable<Comment>> GetAll()
        {
            IEnumerable<Comment> list = null;
            using (unidad = new UnidadDeTrabajo<Comment>(new asistencia360Context()))
            {
                list = await unidad.genericDAL.GetAll();
            }

            return list;
        }

        public bool Remove(Comment entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Comment> entities)
        {
            throw new NotImplementedException();
        }

        public Comment SingleOrDefault(Expression<Func<Comment, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Comment entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Comment>(new asistencia360Context()))
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

        Comment IDALGenerico<Comment>.SingleOrDefault(Expression<Func<Comment, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
