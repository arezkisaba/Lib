using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.Core.UnitTests
{
    [TestClass]
    public class StringsHelperUnitTest
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
        public void GetStringForStorage_TestMethod()
        {
            var title = StringsHelper.GetStringForStorage("  Star  Wars //    :   L'Ascenscion de   Skywalker    ");
            Assert.IsTrue(!string.IsNullOrWhiteSpace(title));
        }
    }
}
