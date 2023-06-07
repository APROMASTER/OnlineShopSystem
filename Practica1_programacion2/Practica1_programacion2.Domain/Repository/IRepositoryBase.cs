using System.Collections.Generic;

namespace Practica1_programacion2.Domain.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Save(TEntity entity);

        void Update(TEntity entity);

        TEntity GetEntityById(int id);

        List<TEntity> GetEntities();
    }
}
