using System.Collections.Generic;

namespace Lib.Core
{
    public interface INetworkInterfaceService
    {
        List<NetworkInterfaceModel> GetAll();

        List<NetworkInterfaceModel> GetActives();
        
        bool IsActive(string name);
    }
}