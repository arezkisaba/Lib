using System;

namespace Lib.Samples.WebApi
{
    public class AppSettings : IAppSettings
    {
        public string EnvironmentName { get; set; }
    }

    public interface IAppSettings
    {
        public string EnvironmentName { get; set; }
    }
}
