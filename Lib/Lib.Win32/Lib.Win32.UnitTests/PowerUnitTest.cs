using Lib.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Lib.Win32.UnitTests
{
    [TestClass]
    public class PowerUnitTest
    {
        private IPowerService _powerService;

        [TestInitialize]
        public void Initialize()
        {
            _powerService = new PowerService();
        }

        [TestCleanup]
        public void Cleanup()
        {
        }

        [TestMethod]
        public void PowerOff_TestMethod()
        {
            var result = _powerService.PowerOff();
            Assert.IsTrue(result);
        }
    }
}
