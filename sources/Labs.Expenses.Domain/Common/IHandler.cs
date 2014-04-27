namespace Labs.Expenses.W.Domain.Common
{
    public interface IHandler<in TCommand, out TResult>
        where TCommand : ICommand
        where TResult : IResult
    {
        TResult Execute(TCommand command);
    }
}