using System;
using Windows.Networking.Connectivity;

namespace Lib.Uwp
{
    public static class NetworkHelper
	{
		public enum NetworkCategory
		{
			None,
			Wifi,
			_4G,
			_3G,
			_2G,
			Edge,
			Ethernet,
			UnknownMobile
		}

		private const uint IANA_ETHERNET = 6;
		private const uint IANA_MOBILE = 243;
		private const uint IANA_MOBILE2 = 244;
		private const uint IANA_WIFI = 71;

		public static NetworkCategory GetNetworkCategory()
		{
			try
			{
				var profile = NetworkInformation.GetInternetConnectionProfile();
				if (profile == null || profile.NetworkAdapter == null)
				{
					return NetworkCategory.None;
				}

				var interfaceType = profile.NetworkAdapter.IanaInterfaceType;

				if (interfaceType == IANA_WIFI)
				{
					return NetworkCategory.Wifi;
				}

				if (interfaceType == IANA_ETHERNET)
				{
					return NetworkCategory.Ethernet;
				}

				if ((interfaceType == IANA_MOBILE || interfaceType == IANA_MOBILE2) && profile.WwanConnectionProfileDetails != null)
				{
					var currentDataClass = profile.WwanConnectionProfileDetails.GetCurrentDataClass();
					if (currentDataClass.Equals(WwanDataClass.None))
					{
						return NetworkCategory.None;
					}

					switch (currentDataClass)
					{
						case WwanDataClass.Edge:
							return NetworkCategory.Edge;
						case WwanDataClass.Gprs:
							return NetworkCategory._2G;
						case WwanDataClass.Cdma1xEvdo:
						case WwanDataClass.Cdma1xEvdoRevA:
						case WwanDataClass.Cdma1xEvdv:
						case WwanDataClass.Cdma1xEvdoRevB:
						case WwanDataClass.Cdma3xRtt:
						case WwanDataClass.Cdma1xRtt:
						case WwanDataClass.Umts:
						case WwanDataClass.Hsupa:
						case WwanDataClass.Hsdpa:
							return NetworkCategory._3G;
						case WwanDataClass.LteAdvanced:
						case WwanDataClass.CdmaUmb:
							return NetworkCategory._4G;
						case WwanDataClass.Custom:
							return NetworkCategory.UnknownMobile;
						default:
							return NetworkCategory.UnknownMobile;
					}
				}
			}
			catch (Exception)
			{
				return NetworkCategory.UnknownMobile;
			}

			return NetworkCategory.None;
		}

		public static bool HasWifi()
		{
			var networkCategory = GetNetworkCategory();
			if (networkCategory == NetworkCategory.Wifi)
			{
				return true;
			}

			return false;
		}
	}
}