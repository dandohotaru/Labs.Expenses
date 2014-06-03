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
    public class AddExpenseFixture : Fixture
    {
        [Test]
        public void ShouldAddExpenseWhenExpenseIsNew()
        {
            // Given
            var time = SystemTime.Now();
            var tenantId = SystemTenant.Current().Id;
            var commandId = Guid.NewGuid();
            var expenseId = Guid.NewGuid();
            var command = new AddExpenseCommand
            {
                TenantId = tenantId,
                CommandId = commandId,
                ExpenseId = expenseId,
                PurchaseDate = time.Date,
                Timestamp = time,
                Merchant = "Amazon",
                Amount = 100,
                Vat = 19,
            };

            // When
            var expect = false;
            var subscriber = Locator.Get<ISubscriber>();
            subscriber.Subscribe<ExpenseAddedEvent>(e => expect = e.CorrelationId == commandId);

            var service = Locator.Get<IExpensesFacade>();
            service.Execute(command);

            // Then
            Assert.That(expect, Is.True);
        }
    }
}