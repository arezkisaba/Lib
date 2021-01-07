using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lib.Core.UnitTests
{
    [TestClass]
    public class StringExtensionsUnitTest
    {
        [TestInitialize]
        public void Initialize()
        {
        }

        [TestCleanup]
        public void Cleanup()
        {
        }

        [TestMethod]
        public void TransformForStorage_TestMethod()
        {
            var title = "  Star  Wars //    :   L'Ascenscion de   Skywalker    ".TransformForStorage();
            Assert.IsTrue(title == "Star Wars L'Ascenscion de Skywalker");
        }
    }
}
