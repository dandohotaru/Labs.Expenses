using System.Data.Entity;
using System.Linq;
using Labs.Expenses.R.Data.Conventions;
using Labs.Expenses.R.Domain.Adapters;
using Labs.Expenses.R.Domain.Common;
using Labs.Expenses.R.Domain.Entities;

namespace Labs.Expenses.R.Data.Contexts
{
    public class SqlSession : DbContext, ISession
    {
        static SqlSession()
        {
            Database.SetInitializer(new NullDatabaseInitializer<SqlSession>());
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

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Conventions.Add(new EntityConventions());
        }
    }
}