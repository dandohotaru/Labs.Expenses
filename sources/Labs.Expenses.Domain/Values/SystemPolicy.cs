using System;
using Labs.Expenses.W.Domain.Common;

namespace Labs.Expenses.W.Domain.Values
{
    public class SystemPolicy : IPolicy
    {
        private const string Default = "3E18C046-D993-4CE0-B19C-4530E11C925B";

        public static Func<IPolicy> Current = () => new SystemPolicy();

        public SystemPolicy(Func<Guid> builder)
        {
            Builder = builder;
        }

        public SystemPolicy()
            : this(() => new Guid(Default))
        {
            Id = Builder();
        }

        protected Func<Guid> Builder { get; private set; }

        public Guid Id { get; private set; }
    }
}