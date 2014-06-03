using System;
using Labs.Expenses.W.Domain;
using Labs.Expenses.W.Domain.Adapters;
using Labs.Expenses.W.Domain.Commands;
using Labs.Expenses.W.Domain.Events;
using Labs.Expenses.W.Domain.Values;
using Labs.Expenses.W.Tests.Common;
using Ninject;
using NUnit.Framework;

namespace Labs.Expenses.W.Tests.Facades
{
    [TestFixture]
    public class RemoveExpenseFixture : Fixture
    {
        [Test]
        public void ShouldRemoveExpenseWhenExpenseExists()
        {
            // Given
            var service = Locator.Get<IExpensesFacade>();
            var subscriber = Locator.Get<ISubscriber>();

            var time = SystemTime.Now();
            var tenantId = SystemTenant.Current().Id;
            var expenseId = Guid.NewGuid();

            var addId = Guid.NewGuid();
            var add = new AddExpenseCommand
            {
                TenantId = tenantId,
                CommandId = addId,
                ExpenseId = expenseId,
                Timestamp = time,
                PurchaseDate = time.Date,
                Merchant = "Amazon",
                Amount = 100,
                Vat = 19,
                
            };
            service.Execute(add);

            var removeId = Guid.NewGuid();
            var remove = new RemoveExpenseCommand
            {
                CommandId = removeId,
                ExpenseId = expenseId,
                TenantId = tenantId,
                Timestamp = time.AddHours(1),
            };

            // When
            var expect = false;
            subscriber.Subscribe<ExpenseRemovedEvent>(e => expect = e.CorrelationId == removeId);
            service.Execute(remove);

            // Then
            Assert.That(expect, Is.True);
        }
    }
}