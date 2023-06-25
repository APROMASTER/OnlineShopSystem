
using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace Practica1_programacion2.Domain.Repository
{
    public interface IBaseRepository<TEntity > where TEntity : class
    {

        void Save(TEntity entity);
        void Update(TEntity entity);
        TEntity GetEntityById(int id);
        List<TEntity> GetEntities();
        void Remove(TEntity entity);
        bool Exists(Expression<Func<TEntity, bool>> filter);
    }
}
