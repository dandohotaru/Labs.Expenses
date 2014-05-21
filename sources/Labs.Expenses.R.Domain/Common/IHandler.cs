namespace Labs.Expenses.R.Domain.Common
{
    public interface IHandler<in TQuery, out TResult>
        where TQuery : IQuery
        where TResult : IResult
    {
        TResult Execute(TQuery query);
    }
}