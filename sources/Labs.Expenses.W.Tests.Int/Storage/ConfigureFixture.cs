using System;
using System.Linq;
using Labs.Expenses.W.Domain.Adapters;
using Labs.Expenses.W.Domain.Entities;
using Labs.Expenses.W.Domain.Values;
using Labs.Expenses.W.Tests.Common;
using Ninject;
using NUnit.Framework;

namespace Labs.Expenses.W.Tests.Storage
{
    [TestFixture]
    public class ConfigureFixture : Fixture
    {
        [Test]
        public void ShouldCreateDatabaseIfNotExisting()
        {
            // Given
            var builder = Locator.Get<Func<ISession>>();
            using (var context = builder())
            {
                var tagId = Guid.NewGuid();
                var tenantId = SystemTenant.Current().Id;
                var tag = new Tag
                {
                    Id = tagId,
                    TenantId = tenantId,
                };

                // When
                context.Add(tag);
                context.Save();

                // Then
                var expect = context
                    .Query<Tag>()
                    .SingleOrDefault(p => p.Id == tagId);
                Assert.That(expect, Is.Not.Null);
            }
        }
    }
}