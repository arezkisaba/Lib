using Lib.Core.Services.Interfaces;
using System;
using System.Configuration;
using System.Globalization;

namespace Lib.Core.Services.Implementations
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly string _assemblyPath;
        private Configuration _config;
        private NumberFormatInfo _numberFormatInfo;

        public ConfigurationService(string assemblyPath)
        {
            _assemblyPath = assemblyPath;
            _config = ConfigurationManager.OpenExeConfiguration(_assemblyPath);
            _numberFormatInfo = new NumberFormatInfo()
            {
                NumberGroupSeparator = "",
                CurrencyDecimalSeparator = "."
            };
        }

        public T Get<T>(string name)
        {
            return (T)Convert.ChangeType(_config.AppSettings.Settings[name].Value, typeof(T), _numberFormatInfo);
        }
    }
}
