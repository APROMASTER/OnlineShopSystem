using Practica1_programacion2.Domain.Repository;
using System;
using System.Collections.Generic;

namespace Practica1_programacion2.Infrastructure.Core
{
    public abstract class BaseRepository<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        public virtual List<TEntity> GetEntities()
        {
            throw new NotImplementedException();
        }

        public virtual TEntity GetEntityById(int id)
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
