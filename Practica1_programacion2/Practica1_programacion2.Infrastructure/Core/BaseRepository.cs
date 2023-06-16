using Microsoft.EntityFrameworkCore;
using Practica1_programacion2.Domain.Repository;
using Practica1_programacion2.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Practica1_programacion2.Infrastructure.Core
{
    public abstract class BaseRepository<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly ShopContext context;
        private readonly DbSet<TEntity> myDbSet;
        public BaseRepository(ShopContext context)
        {
            this.context = context;
            this.myDbSet = this.context.Set<TEntity>();
        }
        public virtual bool Exists(Expression<Func<TEntity, bool>> filter)
        {
            return this.myDbSet.Any(filter);
        }
        public virtual List<TEntity> GetEntities()
        {
            return this.myDbSet.ToList();
        }

        public virtual TEntity GetEntity(int id)
        {
            return this.myDbSet.Find(id);
        }

        public virtual void Add(TEntity entity)
        {
            this.myDbSet.Add(entity);
        }

        public virtual void Add(TEntity[] entities)
        {
            this.myDbSet.AddRange(entities);
        }

        public virtual void Delete(TEntity entity)
        {
            // Recordatorio: Modificar los datos de auditorio.

            this.myDbSet.Remove(entity);
        }

        public virtual void Delete(TEntity[] entities)
        {
            this.myDbSet.RemoveRange(entities);
        }

        public virtual void Update(TEntity entity)
        {
            this.myDbSet.Update(entity);
        }

        public virtual void Update(TEntity[] entities)
        {
            this.myDbSet.UpdateRange(entities);
        }
        public virtual void SaveChanges()
        {
            this.context.SaveChanges();
        }

    }
}
