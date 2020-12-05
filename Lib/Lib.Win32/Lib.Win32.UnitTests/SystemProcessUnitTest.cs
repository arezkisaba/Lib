using Lib.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading;

namespace Lib.Win32.UnitTests
{
    [TestClass]
    public class SystemProcessUnitTest
    {
        private const string processName = "notepad";
        private ISystemProcessService _systemProcessService;

        [TestInitialize]
        public void Initialize()
        {
            _systemProcessService = new SystemProcessService();
        }

        [TestCleanup]
        public void Cleanup()
        {
        }

        [TestMethod]
        public void StartAndStop_TestMethod()
        {
            _systemProcessService.Start(processName);
            Thread.Sleep(1000);

            var processes = _systemProcessService.GetByName(processName);
            Assert.IsTrue(processes.Any());

            _systemProcessService.Stop(processName);
            Thread.Sleep(1000);

            processes = _systemProcessService.GetByName(processName);
            Assert.IsTrue(!processes.Any());
        }
    }
}
