namespace Lib.Core
{
	public interface ISettingsService
	{
		bool Contains(string key);

		T Get<T>(string key, T defaultValue = default(T));

		void Set<T>(string key, T value);
	}
}