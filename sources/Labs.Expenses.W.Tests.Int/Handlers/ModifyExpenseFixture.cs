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
            service.AddExpense(add);

            var modifyId = Guid.NewGuid();
            var modify = new ModifyExpenseCommand
            {
                CommandId = modifyId,
                TenantId = tenantId,
                ExpenseId = expenseId,
                Timestamp = time.AddHours(1),
                PurchaseDate = time.Date,
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