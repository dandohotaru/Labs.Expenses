using Labs.Expenses.W.Domain.Commands;
using Labs.Expenses.W.Domain.Common;

namespace Labs.Expenses.W.Domain
{
    public interface IExpensesFacade :
        IHandle<AddExpenseCommand>,
        IHandle<ModifyExpenseCommand>,
        IHandle<RemoveExpenseCommand>
    {
    }
}