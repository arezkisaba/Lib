using Lib.Core;
using static Lib.Win32.NativeMethods;

namespace Lib.Win32
{
    public class ConnectivityService : IConnectivityService
    {
        public bool IsNetworkAvailable()
        {
            int description;
            var state = InternetGetConnectedState(out description, 0);
            return state;
        }
    }
}