using System;
using System.Collections.Generic;
using System.Linq;
using Labs.Expenses.W.Domain.Common;

namespace Labs.Expenses.W.Domain.Adapters
{
    public interface IDataContext : IDisposable
    {
        IQueryable<TEntity> Query<TEntity>() where TEntity : class, IEntity;

        void Add<TEntity>(TEntity entity) where TEntity : class, IEntity;

        void Add<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IEntity;

        void Remove<TEntity>(TEntity entity) where TEntity : class, IEntity;

        void Remove<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IEntity;

        void Save();
    }
}