using System;

namespace Labs.Expenses.W.Domain.Values
{
    public static class SystemTime
    {
        public static Func<DateTime> Now = () => DateTime.Now;
    }
}