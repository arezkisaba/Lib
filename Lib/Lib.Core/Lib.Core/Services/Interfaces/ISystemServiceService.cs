using System.Collections.Generic;

namespace Lib.Core
{
    public interface ISystemServiceService
    {
        List<SystemServiceModel> GetAll();

        bool Start(string serviceName);

        bool Stop(string serviceName);

        bool EnableStartupOnBoot(string serviceName);

        bool DisableStartupOnBoot(string serviceName);
    }
}