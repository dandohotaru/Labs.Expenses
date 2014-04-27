using System;
using Labs.Expenses.W.Data.Contexts;
using Labs.Expenses.W.Domain.Adapters;
using Labs.Expenses.W.Domain.Common;
using Labs.Expenses.W.Domain.Values;
using Ninject;
using NUnit.Framework;

namespace Labs.Expenses.W.Tests.Common
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
            kernel.Bind<IPolicy>().To<SystemPolicy>();
            kernel.Bind<Func<IDataContext>>().ToMethod(context => (() => new SqlContext()));

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
