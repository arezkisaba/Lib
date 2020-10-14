using Lib.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.Win32.UnitTests
{
    [TestClass]
    public class DisplayUnitTest
    {
        private IDisplayService _displayService;

        [TestInitialize]
        public void Initialize()
        {
            _displayService = new DisplayService();
        }

        [TestCleanup]
        public void Cleanup()
        {
        }

        [TestMethod]
        public void GetAll_TestMethod()
        {
            var displays = _displayService.GetAll();
            Assert.IsTrue(displays != null && displays.Any());
        }

        [TestMethod]
        public void GetCurrent_TestMethod()
        {
            var display = _displayService.GetCurrent();
            Assert.IsTrue(display != null);
        }

        [TestMethod]
        public void SetCurrent_TestMethod()
        {
            var displays = _displayService.GetAll();
            Assert.IsTrue(displays != null && displays.Count > 2);
            var lowerDisplay = _displayService.GetLowerDisplay();
            var higherDisplay = _displayService.GetHigherDisplay();
            Assert.IsTrue(lowerDisplay != null);
            Assert.IsTrue(higherDisplay != null);
            _displayService.SetCurrent(lowerDisplay);
            Task.Delay(TimeHelper.FromSecondsToMilliseconds(5)).Wait();
            _displayService.SetCurrent(higherDisplay);
        }
    }
}
