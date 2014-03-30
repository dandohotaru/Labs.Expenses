using System;

namespace Labs.Expenses.Domain.Common
{
    public interface ITenant
    {
        Guid Id { get; }
    }
}