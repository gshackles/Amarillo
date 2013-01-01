using NUnit.Framework;

namespace Amarillo.IntegrationTests
{
    [TestFixture(Category = "Integration")]
    public abstract class IntegrationTestsBase
    {
        protected Amarillo Amarillo { get; private set; }

        [SetUp]
        public void SetUp()
        {
            Amarillo = new Amarillo("");
        }
    }
}
