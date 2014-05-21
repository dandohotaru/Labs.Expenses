using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Labs.Expenses.W.Data.Conventions;
using Labs.Expenses.W.Data.Mappings;
using Labs.Expenses.W.Domain.Adapters;
using Labs.Expenses.W.Domain.Common;
using Labs.Expenses.W.Domain.Entities;

namespace Labs.Expenses.W.Data.Contexts
{
    public class SqlSession : DbContext, ISession
    {
        static SqlSession()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<SqlSession>());
        }

        public SqlSession()
            : base("Sql")
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
            where TEntity : class, IEntityWithId
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

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Conventions.Add(new EntityConventions());

            builder.Configurations.Add(new ExpenseMap());
            builder.Configurations.Add(new MerchantMap());
            builder.Configurations.Add(new PolicyMap());
            builder.Configurations.Add(new TagMap());
        }
    }
}