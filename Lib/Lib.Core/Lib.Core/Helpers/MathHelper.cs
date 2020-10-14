using System;

namespace Lib.Core
{
	public static class MathHelper
	{
		public static double CalculateDistance(float[] p1, float[] p2)
		{
			return CalculateDistance(p1[0], p1[1], p2[0], p2[1]);
		}

		public static double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
		{
			const double circumference = 40000.0;
			double distance;
			var latitude1Rad = DegreesToRadians(lat1);
			var longitude1Rad = DegreesToRadians(lon1);
			var latititude2Rad = DegreesToRadians(lat2);
			var longitude2Rad = DegreesToRadians(lon2);
			var logitudeDiff = Math.Abs(longitude1Rad - longitude2Rad);

			if (logitudeDiff > Math.PI)
			{
				logitudeDiff = 2.0 * Math.PI - logitudeDiff;
			}

			var angleCalculation = Math.Acos(Math.Sin(latititude2Rad) * Math.Sin(latitude1Rad) + Math.Cos(latititude2Rad) * Math.Cos(latitude1Rad) * Math.Cos(logitudeDiff));
			distance = circumference * angleCalculation / (2.0 * Math.PI);

			return distance * 1000;
		}

		private static double DegreesToRadians(double degrees)
		{
			return degrees * Math.PI / 180.0;
		}

		private static double RadiansToDegrees(double radians)
		{
			return radians / Math.PI * 180.0;
		}
	}
}