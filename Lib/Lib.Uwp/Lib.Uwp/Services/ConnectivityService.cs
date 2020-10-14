using Windows.Networking.Connectivity;
using Lib.Core;

namespace Lib.Uwp
{
    public class ConnectivityService : IConnectivityService
	{
		public bool IsNetworkAvailable()
		{
			var profile = NetworkInformation.GetInternetConnectionProfile();
			if (profile == null)
			{
				return false;
			}

			var level = profile.GetNetworkConnectivityLevel();
			switch (level)
			{
				case NetworkConnectivityLevel.ConstrainedInternetAccess:
				case NetworkConnectivityLevel.None:
				case NetworkConnectivityLevel.LocalAccess:
					return false;
				case NetworkConnectivityLevel.InternetAccess:
					return true;
				default:
					return false;
			}
		}
	}
}