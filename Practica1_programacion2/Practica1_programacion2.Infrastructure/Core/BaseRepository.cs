
using Practica1_programacion2.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Practica1_programacion2.Infrastructure.Core
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        public virtual bool Exists(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public virtual List<TEntity> GetEntities()
        {
            throw new NotImplementedException();
        }

        public virtual TEntity GetEntityById(int id)
        {
            throw new NotImplementedException();
        }

        public virtual void Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Save(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
