using System.Collections.Generic;
using System.Linq;

namespace Labs.Expenses.Domain.Common
{
    public interface IDataContext
    {
        IQueryable<TEntity> Query<TEntity>() where TEntity : class, IEntity;

        void Add<TEntity>(TEntity entity) where TEntity : class, IEntity;

        void Add<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IEntity;

        void Remove<TEntity>(TEntity entity) where TEntity : class, IEntity;

        void Remove<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IEntity;

        void Save();

        void Clear();
    }
}