using Labs.Expenses.W.Domain.Common;

namespace Labs.Expenses.W.Domain.Adapters
{
    public interface IPublisher
    {
        void Publish<TEvent>(TEvent e) where TEvent : IEvent;
    }
}