using Lib.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.ServiceProcess;

namespace Lib.Win32
{
    public class SystemServiceService : ISystemServiceService
    {
        private const int Timeout = 5000;

        public List<SystemServiceModel> GetAll()
        {
            return ServiceController.GetServices().Select(obj => new SystemServiceModel(
                obj.ServiceName,
                obj.Status == ServiceControllerStatus.Running,
                obj.StartType == ServiceStartMode.Automatic || obj.StartType == ServiceStartMode.Boot || obj.StartType == ServiceStartMode.System
            )).ToList();
        }

        public bool Start(string serviceName)
        {
            var service = new ServiceController(serviceName);

            try
            {
                var timeout = TimeSpan.FromMilliseconds(Timeout);
                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running, timeout);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Stop(string serviceName)
        {
            var service = new ServiceController(serviceName);

            try
            {
                var timeout = TimeSpan.FromMilliseconds(Timeout);
                service.Stop();
                service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EnableStartupOnBoot(string serviceName)
        {
            try
            {
                ChangeStartMode(serviceName, ServiceStartMode.Automatic);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DisableStartupOnBoot(string serviceName)
        {
            try
            {
                ChangeStartMode(serviceName, ServiceStartMode.Manual);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void ChangeStartMode(string serviceName, ServiceStartMode mode)
        {
            var scManagerHandle = NativeMethods.Service.OpenSCManager(null, null, NativeMethods.Service.SC_MANAGER_ALL_ACCESS);
            if (scManagerHandle == IntPtr.Zero)
            {
                throw new ExternalException("Open Service Manager Error");
            }

            var serviceHandle = NativeMethods.Service.OpenService(scManagerHandle, serviceName, NativeMethods.Service.SERVICE_QUERY_CONFIG | NativeMethods.Service.SERVICE_CHANGE_CONFIG);

            if (serviceHandle == IntPtr.Zero)
            {
                throw new ExternalException("Open Service Error");
            }

            var result = NativeMethods.Service.ChangeServiceConfig(
                serviceHandle,
                NativeMethods.Service.SERVICE_NO_CHANGE,
                (uint)mode,
                NativeMethods.Service.SERVICE_NO_CHANGE,
                null,
                null,
                IntPtr.Zero,
                null,
                null,
                null,
                null);

            if (result == false)
            {
                var nError = Marshal.GetLastWin32Error();
                var win32Exception = new Win32Exception(nError);
                throw new ExternalException("Could not change service start type: " + win32Exception.Message);
            }

            NativeMethods.Service.CloseServiceHandle(serviceHandle);
            NativeMethods.Service.CloseServiceHandle(scManagerHandle);
        }
    }
}
