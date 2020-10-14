using Windows.Graphics.Display;

namespace Lib.Uwp
{
    public static class DisplayHelper
	{
		public static bool IsLandscape()
		{
			var orientation = DisplayInformation.GetForCurrentView().CurrentOrientation;
			return orientation == DisplayOrientations.Landscape || orientation == DisplayOrientations.LandscapeFlipped;
		}

		public static bool IsPortrait()
		{
			var orientation = DisplayInformation.GetForCurrentView().CurrentOrientation;
			return orientation == DisplayOrientations.Portrait || orientation == DisplayOrientations.PortraitFlipped;
		}
	}
}