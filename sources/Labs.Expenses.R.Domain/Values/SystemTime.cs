using System;

namespace Labs.Expenses.R.Domain.Values
{
    public static class SystemTime
    {
        public static Func<DateTime> Now = () => DateTime.Now;
    }
}