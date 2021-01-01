using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lib.ApiServices.Torrents.UnitTests
{
    [TestClass]
    public class ScrappingHelperUnitTest
    {
        [TestMethod]
        public void ConvertSizeStringToNumber_TestMethod()
        {
            var result = ScrappingHelper.ConvertSizeStringToNumber("1.37 GB");
            Assert.IsTrue(result == 1471026298.88);
        }
    }
}
