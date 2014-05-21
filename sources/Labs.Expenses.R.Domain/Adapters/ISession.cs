using System;
using System.Linq;
using Labs.Expenses.R.Domain.Common;

namespace Labs.Expenses.R.Domain.Adapters
{
    public interface ISession : IDisposable
    {
        IQueryable<TEntity> Query<TEntity>() where TEntity : class, IEntity;
    }
}