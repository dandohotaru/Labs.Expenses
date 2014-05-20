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
    public class ModifyExpenseFixture : Fixture
    {
        [Test]
        public void ShouldModifyExpenseWhenExpenseExists()
        {
            // Given
            var service = Locator.Get<IExpensesFacade>();
            var bus = Locator.Get<IBus>();

            var date = SystemTime.Now();
            var expenseId = Guid.NewGuid();
            var rootId = Guid.NewGuid();

            var addId = Guid.NewGuid();
            var add = new AddExpenseCommand(rootId, addId)
            {
                ExpenseId = expenseId,
                PurchaseDate = date,
                Merchant = "Amazon",
                Amount = 100,
                Vat = 19,
            };
            service.AddExpense(add);

            var modifyId = Guid.NewGuid();
            var modify = new ModifyExpenseCommand(rootId, modifyId)
            {
                ExpenseId = expenseId,
                PurchaseDate = date,
                Merchant = "Amazon",
                Amount = 101,
                Vat = 21,
            };

            // When
            var expect = false;
            bus.Subscribe<ExpenseModifiedEvent>(e => expect = e.CorrelationId == modifyId);
            service.ModifyExpense(modify);

            // Then
            Assert.That(expect, Is.True);
        }
    }
}