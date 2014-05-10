using System;
using Labs.Expenses.W.Domain.Common;

namespace Labs.Expenses.W.Domain.Values
{
    public class SystemTenant : ITenant
    {
        private const string Default = "96F9C4F5-32B9-448E-A7AC-FF4D855B3291";

        public static Func<ITenant> Current = () => new SystemTenant();

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