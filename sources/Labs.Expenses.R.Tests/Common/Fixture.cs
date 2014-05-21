using Labs.Expenses.R.Tests.Bootstrap;
using Ninject;
using NUnit.Framework;

namespace Labs.Expenses.R.Tests.Common
{
    [TestFixture]
    public abstract class Fixture
    {
        public IKernel Locator { get; set; }

        [TestFixtureSetUp]
        public virtual void FixtureSetUp()
        {
            Locator  = new StandardKernel(new ExpensesModule());
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
