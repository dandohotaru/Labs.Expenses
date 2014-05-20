using Labs.Expenses.W.Domain.Commands;

namespace Labs.Expenses.W.Domain
{
    public interface IExpensesFacade
    {
        void AddExpense(AddExpenseCommand command);

        void ModifyExpense(ModifyExpenseCommand command);
    }
}