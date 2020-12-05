using Lib.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lib.Win32.UnitTests
{
    [TestClass]
    public class SystemClipboardUnitTest
    {
        private ISystemClipboardService _systemClipboardService;

        [TestInitialize]
        public void Initialize()
        {
            _systemClipboardService = new SystemClipboardService();
        }

        [TestCleanup]
        public void Cleanup()
        {
        }

        [TestMethod]
        public void SetText_TestMethod()
        {
            var text = "Mon texte";
            _systemClipboardService.SetText(text);
            Assert.IsTrue(_systemClipboardService.GetText() == text);
        }
    }
}
