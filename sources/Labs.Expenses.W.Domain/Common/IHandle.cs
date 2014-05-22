namespace Labs.Expenses.W.Domain.Common
{
    public interface IHandle<in TCommand>
        where TCommand : ICommand
    {
        void Execute(TCommand command);
    }
}