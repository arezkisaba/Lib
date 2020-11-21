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
        private ISystemPowerService _systemPowerService;

        [TestInitialize]
        public void Initialize()
        {
            _systemPowerService = new SystemPowerService();
        }

        [TestCleanup]
        public void Cleanup()
        {
        }

        [TestMethod]
        public void PowerOff_TestMethod()
        {
            var result = _systemPowerService.PowerOff();
            Assert.IsTrue(result);
        }
    }
}
