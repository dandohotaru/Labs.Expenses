using System;
using System.Linq;
using Labs.Expenses.R.Domain.Adapters;
using Labs.Expenses.R.Domain.Entities;
using Labs.Expenses.R.Tests.Common;

using Ninject;
using NUnit.Framework;

namespace Labs.Expenses.R.Tests.Storage
{
    [TestFixture]
    public class ConfigureFixture : Fixture
    {
        [Test]
        public void ShouldRetrieveNumberOfExpensesWhenInvoked()
        {
            // Given
            var builder = Locator.Get<Func<ISession>>();
            using (var context = builder())
            {
                // When
                var count = context
                    .Query<Expense>()
                    .Count();

                // Then
                Assert.That(count, Is.GreaterThanOrEqualTo(0));
            }
        }
    }
}