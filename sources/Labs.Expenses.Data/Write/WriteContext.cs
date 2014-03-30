using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Labs.Expenses.Domain.Common;
using Labs.Expenses.Domain.Entities;

namespace Labs.Expenses.Data.Write
{
    public class WriteContext : DbContext, IWriter
    {
        static WriteContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<WriteContext>());
        }

        public WriteContext()
            : base("Name=SqlContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public IDbSet<Policy> Policies { get; set; }

        public IDbSet<Expense> Expenses { get; set; }

        public IDbSet<Merchant> Merchants { get; set; }

        public IDbSet<Tag> Tags { get; set; }

        public IQueryable<TEntity> Query<TEntity>()
            where TEntity : class, IEntity
        {
            return Set<TEntity>();
        }

        public TEntity Find<TEntity>(Guid id)
            where TEntity : class, IEntity
        {
            return Set<TEntity>().Find(id);
        }

        public void Add<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
            Set<TEntity>().Add(entity);
        }

        public void Add<TEntity>(IEnumerable<TEntity> entities)
            where TEntity : class, IEntity
        {
            foreach (var entity in entities)
            {
                Set<TEntity>().Add(entity);
            }
        }

        public void Remove<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
            Set<TEntity>().Remove(entity);
        }

        public void Remove<TEntity>(IEnumerable<TEntity> entities)
            where TEntity : class, IEntity
        {
            foreach (var entity in entities)
            {
                Set<TEntity>().Remove(entity);
            }
        }

        public void Save()
        {
            SaveChanges();
        }
    }
}
