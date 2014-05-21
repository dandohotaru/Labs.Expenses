namespace Labs.Expenses.W.Domain.Common
{
    public interface IHandler<in TCommand>
        where TCommand : ICommand
    {
        void Execute(TCommand command);
    }
}