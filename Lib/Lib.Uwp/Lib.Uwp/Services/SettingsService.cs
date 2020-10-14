using Lib.Core;
using Windows.Storage;

namespace Lib.Uwp
{
    public class SettingsService : ISettingsService
	{
		private readonly object _lock = new object();

		public bool Contains(string key)
		{
			lock (_lock)
			{
				if (ApplicationData.Current.LocalSettings.Values.ContainsKey(key))
				{
					return true;
				}
			}

			return false;
		}

		public T Get<T>(string key, T defaultValue = default(T))
		{
			object value;
			lock (_lock)
			{
				if (ApplicationData.Current.LocalSettings.Values.ContainsKey(key))
				{
					value = (T)ApplicationData.Current.LocalSettings.Values[key];
				}
				else
				{
					Set(key, defaultValue);
					value = defaultValue;
				}
			}

			return (T)value;
		}

		public void Set<T>(string key, T value)
		{
			lock (_lock)
			{
				if (ApplicationData.Current.LocalSettings.Values.ContainsKey(key))
				{
					ApplicationData.Current.LocalSettings.Values[key] = value;
				}
				else
				{
					ApplicationData.Current.LocalSettings.CreateContainer(key, ApplicationDataCreateDisposition.Always);
					ApplicationData.Current.LocalSettings.Values[key] = value;
				}
			}
		}
	}
}