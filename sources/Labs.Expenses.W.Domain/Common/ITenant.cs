using System;

namespace Labs.Expenses.W.Domain.Common
{
    public interface ITenant
    {
        Guid Id { get; }
    }
}