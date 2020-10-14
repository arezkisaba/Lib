using Lib.Core;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace Lib.Win32
{
    public class NetworkInterfaceService : INetworkInterfaceService
    {
        public List<NetworkInterfaceModel> GetAll()
        {
            return NetworkInterface.GetAllNetworkInterfaces().Select(obj => new NetworkInterfaceModel(obj.Name, obj.Description, obj.OperationalStatus == OperationalStatus.Up)).ToList();
        }

        public List<NetworkInterfaceModel> GetActives()
        {
            return NetworkInterface.GetAllNetworkInterfaces().Select(obj => new NetworkInterfaceModel(obj.Name, obj.Description, obj.OperationalStatus == OperationalStatus.Up)).Where(obj => obj.IsActive).ToList();
        }

        public bool IsActive(string networkInterfaceName)
        {
            return GetAll().FirstOrDefault(obj => obj.Description.Contains(networkInterfaceName) && obj.IsActive) != null;
        }
    }
}