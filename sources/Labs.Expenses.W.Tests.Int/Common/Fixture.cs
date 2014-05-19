using Labs.Expenses.W.Tests.Bootstrap;
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
