using System;
using Labs.Expenses.Data.Write;
using Labs.Expenses.Domain;
using Labs.Expenses.Domain.Common;
using Ninject;
using NUnit.Framework;

namespace Labs.Expenses.Tests.Int.Common
{
    [TestFixture]
    public abstract class Fixture
    {
        public IKernel Locator { get; set; }

        [TestFixtureSetUp]
        public virtual void FixtureSetUp()
        {
            var kernel = new StandardKernel();
            kernel.Bind<ITenant>().To<SystemTenant>();
            kernel.Bind<Func<IWriter>>().ToMethod(context => (() => new WriteContext()));

            Locator = kernel;
        }

        [SetUp]
        public virtual void TestSetUp()
        {
        }

        [TearDown]
        public virtual void TestTearDown()
        {
        }

        [TestFixtureTearDown]
        public virtual void FixtureTearDown()
        {
        }
    }

}
