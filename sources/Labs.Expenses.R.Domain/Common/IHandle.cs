namespace Labs.Expenses.R.Domain.Common
{
    public interface IHandle<in TQuery, out TResult>
        where TQuery : IQuery
        where TResult : IResult
    {
        TResult Execute(TQuery query);
    }
}