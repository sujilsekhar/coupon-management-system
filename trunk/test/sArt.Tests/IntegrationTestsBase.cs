using System.Transactions;
using NUnit.Framework;

namespace sArt.Tests
{
    public class IntegrationTestsBase
    {
        private TransactionScope scope;

        [SetUp]
        public void Initialize()
        {
            scope = new TransactionScope();
        }

        [TearDown]
        public void TestCleanup()
        {
            scope.Dispose();
        }
    }
}