using System;
using Labs.Expenses.W.Domain.Adapters;
using Labs.Expenses.W.Domain.Commands;
using Labs.Expenses.W.Domain.Events;
using Labs.Expenses.W.Domain.Handlers;
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
        public void ShouldAddExpenseWhenCommandIsValid()
        {
            // Given
            var date = SystemTime.Now();
            var tenantId = SystemTenant.Current().Id;
            var policyId = SystemPolicy.Current().Id;
            var commandId = Guid.NewGuid();
            var expenseId = Guid.NewGuid();
            var command = new AddExpenseCommand(tenantId, commandId)
            {
                ExpenseId = expenseId,
                PolicyId = policyId,
                PurchaseDate = date,
                Merchant = "Amazon",
                Amount = 100,
                Vat = 19,
            };

            // When
            var expect = false;
            var bus = Locator.Get<IEventBus>();
            bus.Subscribe<ExpenseAddedEvent>(e => expect = true);
            var builder = Locator.Get<Func<IDataContext>>();
            using (var context = builder())
            {
                var handler = new AddExpenseHandler(context, bus);
                handler.Execute(command);
                context.Save();

                // Then
                Assert.That(expect, Is.True);
            }
        }
    }
}