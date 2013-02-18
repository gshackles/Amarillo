using NUnit.Framework;

namespace Amarillo.IntegrationTests
{
    [TestFixture(Category = "Integration")]
    public abstract class IntegrationTestsBase
    {
        protected IAmarilloClient Client { get; private set; }

        [SetUp]
        public void SetUp()
        {
            Client = new AmarilloClient("");
        }
    }
}
