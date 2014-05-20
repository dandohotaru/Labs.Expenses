using System;
using Labs.Expenses.W.Domain;
using Labs.Expenses.W.Domain.Adapters;
using Labs.Expenses.W.Domain.Commands;
using Labs.Expenses.W.Domain.Events;
using Labs.Expenses.W.Domain.Values;
using Labs.Expenses.W.Tests.Common;
using Ninject;
using NUnit.Framework;

namespace Labs.Expenses.W.Tests.Handlers
{
    [TestFixture]
    public class AddExpenseFixture : Fixture
    {
        [Test]
        public void ShouldAddExpenseWhenExpenseIsNew()
        {
            // Given
            var date = SystemTime.Now();
            var rootId = Guid.NewGuid();
            var commandId = Guid.NewGuid();
            var expenseId = Guid.NewGuid();
            var command = new AddExpenseCommand(rootId, commandId)
            {
                ExpenseId = expenseId,
                PurchaseDate = date,
                Merchant = "Amazon",
                Amount = 100,
                Vat = 19,
            };

            // When
            var expect = false;
            var bus = Locator.Get<IBus>();
            bus.Subscribe<ExpenseAddedEvent>(e => expect = e.CorrelationId == commandId);

            var service = Locator.Get<IExpensesFacade>();
            service.AddExpense(command);

            // Then
            Assert.That(expect, Is.True);
        }
    }
}