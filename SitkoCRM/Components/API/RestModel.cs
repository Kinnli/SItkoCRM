using System;
using SitkoCRM.Components.Repository;

namespace SitkoCRM.Components.API
{
    public abstract class RestModel<TEntity, TEntityPk> where TEntity : class, IEntity<TEntityPk>
    {
        public TEntityPk Id { get; set; }

        public TEntity GetEntity(TEntity entity)
        {
            entity = entity ?? Activator.CreateInstance<TEntity>();
            entity.Id = Id;
            FillEntity(entity);
            return entity;
        }

        public abstract void ParseEntity(TEntity entity);
        public abstract void FillEntity(TEntity entity);
    }
}
