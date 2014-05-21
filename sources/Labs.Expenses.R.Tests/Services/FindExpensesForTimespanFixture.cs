﻿using System;
using Labs.Expenses.R.Domain;
using Labs.Expenses.R.Domain.Reports.FindExpensesForTimespan;
using Labs.Expenses.R.Domain.Values;
using Labs.Expenses.R.Tests.Common;
using Ninject;
using NUnit.Framework;

namespace Labs.Expenses.R.Tests.Services
{
    [TestFixture]
    public class FindExpensesForTimespanFixture : Fixture
    {
        [Test]
        public void ShouldAddExpenseWhenExpenseIsNew()
        {
            // Given
            var time = SystemTime.Now();
            var queryId = Guid.NewGuid();
            var tenantId = Guid.Empty;
            var query = new FindExpensesForTimespanQuery
            {
                QueryId = queryId,
                TenantId = tenantId,
                Timestamp = time,
            };

            // When
            var service = Locator.Get<ISearchFacade>();
            var result = service.Find(query);

            // Then
            Assert.That(result, Is.Not.Null);
        }
    }
}