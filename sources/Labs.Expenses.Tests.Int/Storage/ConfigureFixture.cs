using System;
using System.Linq;
using Labs.Expenses.Domain.Common;
using Labs.Expenses.Domain.Entities;
using Labs.Expenses.Tests.Int.Common;
using Ninject;
using NUnit.Framework;

namespace Labs.Expenses.Tests.Int.Storage
{
    [TestFixture]
    public class ConfigureFixture : Fixture
    {
        [Test]
        public void ShouldCreateDatabaseIfNotExisting()
        {
            // Given
            var tenant = Locator.Get<ITenant>();
            var builder = Locator.Get<Func<IWriter>>();
            using (var context = builder())
            {
                var tagId = Guid.NewGuid();
                var tag = new Tag(tagId, tenant.Id);

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