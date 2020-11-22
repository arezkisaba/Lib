using System.Collections.Generic;

namespace Lib.Core
{
    public interface ISystemNetworkService
    {
        List<NetworkInterfaceModel> GetInterfaces();

        List<NetworkInterfaceModel> GetInterfacesActives();
        
        bool IsInterfaceActive(string name);

        bool IsNetworkAvailable();
    }
}