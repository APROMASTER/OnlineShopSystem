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
        private readonly ShopContext shop;
        private readonly DbSet<TEntity> entities;
        public BaseRepository(ShopContext shop)
        {
            this.shop = shop;
            this.entities = this.shop.Set<TEntity>();
        }
        public virtual bool Exists(Expression<Func<TEntity, bool>> filter)
        {
            return this.entities.Any(filter);
        }
        public virtual List<TEntity> GetEntities()
        {
            return this.entities.ToList();
        }

        public virtual TEntity GetEntity(int id)
        {
            return this.entities.Find(id);
        }

        public virtual void Add(TEntity entity)
        {
            this.entities.Add(entity);
        }

        public virtual void Add(TEntity[] entities)
        {
            this.entities.AddRange(entities);
        }

        public virtual void Delete(TEntity entity)
        {
            // Recordatorio: Modificar los datos de auditorio.

            this.entities.Remove(entity);
        }

        public virtual void Delete(TEntity[] entities)
        {
            this.entities.RemoveRange(entities);
        }

        public virtual void Update(TEntity entity)
        {
            this.entities.Update(entity);
        }

        public virtual void Update(TEntity[] entities)
        {
            this.entities.UpdateRange(entities);
        }
        public virtual void SaveChanges()
        {
            this.shop.SaveChanges();
        }

    }
}
