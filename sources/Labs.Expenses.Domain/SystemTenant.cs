using System;
using Labs.Expenses.Domain.Common;

namespace Labs.Expenses.Domain
{
    public class SystemTenant : ITenant
    {
        private const string Default = "96F9C4F5-32B9-448E-A7AC-FF4D855B3291";

        public SystemTenant(Func<Guid> builder)
        {
            Builder = builder;
        }

        public SystemTenant()
            : this(() => new Guid(Default))
        {
            Id = Builder();
        }

        protected Func<Guid> Builder { get; private set; }

        public Guid Id { get; private set; }
    }
}