using Labs.Expenses.W.Domain.Commands;

namespace Labs.Expenses.W.Tests.Facades
{
    public interface IExpensesFacade
    {
        void AddExpense(AddExpenseCommand command);
    }
}