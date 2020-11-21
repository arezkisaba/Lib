using Lib.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.Win32.UnitTests
{
    [TestClass]
    public class DisplayUnitTest
    {
        private ISystemDisplayService _systemDisplayService;

        [TestInitialize]
        public void Initialize()
        {
            _systemDisplayService = new SystemDisplayService();
        }

        [TestCleanup]
        public void Cleanup()
        {
        }

        [TestMethod]
        public void GetAll_TestMethod()
        {
            var displays = _systemDisplayService.GetAll();
            Assert.IsTrue(displays != null && displays.Any());
        }

        [TestMethod]
        public void GetCurrent_TestMethod()
        {
            var display = _systemDisplayService.GetCurrent();
            Assert.IsTrue(display != null);
        }

        [TestMethod]
        public void SetCurrent_TestMethod()
        {
            var displays = _systemDisplayService.GetAll();
            Assert.IsTrue(displays != null && displays.Any());
            var lowerDisplay = _systemDisplayService.GetLowerDisplay();
            var higherDisplay = _systemDisplayService.GetHigherDisplay();
            Assert.IsTrue(lowerDisplay != null);
            Assert.IsTrue(higherDisplay != null);
            _systemDisplayService.SetCurrent(lowerDisplay);
            Task.Delay(TimeHelper.FromSecondsToMilliseconds(5)).Wait();
            _systemDisplayService.SetCurrent(higherDisplay);
        }
    }
}
