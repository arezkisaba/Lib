using Lib.Core;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace Lib.Win32
{
    public class SystemNetworkService : ISystemNetworkService
    {
        public List<NetworkInterfaceModel> GetInterfaces()
        {
            return NetworkInterface.GetAllNetworkInterfaces().Select(obj => new NetworkInterfaceModel(obj.Name, obj.Description, obj.OperationalStatus == OperationalStatus.Up)).ToList();
        }

        public List<NetworkInterfaceModel> GetInterfacesActives()
        {
            return NetworkInterface.GetAllNetworkInterfaces().Select(obj => new NetworkInterfaceModel(obj.Name, obj.Description, obj.OperationalStatus == OperationalStatus.Up)).Where(obj => obj.IsActive).ToList();
        }

        public bool IsInterfaceActive(string networkInterfaceName)
        {
            return GetInterfaces().FirstOrDefault(obj => obj.Description.Contains(networkInterfaceName) && obj.IsActive) != null;
        }

        public bool IsNetworkAvailable()
        {
            int description;
            var state = NativeMethods.Network.InternetGetConnectedState(out description, 0);
            return state;
        }
    }
}