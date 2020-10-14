using System;
using System.Text.RegularExpressions;

namespace Lib.Core.OnlineServices.Torrents
{
    public static class ScrappingHelper
    {
        public static double ConvertSizeStringToNumber(string sizeString)
        {
            sizeString = sizeString.Replace(".", ",");
            sizeString = sizeString.Replace(" ", " ");

            var torrentSize = 0d;
            var parts = sizeString.Split(' ');
            var number = Convert.ToDouble(parts[0]);
            var unit = parts[1];

            switch (unit)
            {
                case "Kb":
                case "KB":
                case "Ko":
                case "KO":
                    torrentSize = (double)(number * 1024);
                    break;
                case "Mb":
                case "MB":
                case "Mo":
                case "MO":
                    torrentSize = (double)(number * 1024 * 1024);
                    break;
                case "Gb":
                case "GB":
                case "Go":
                case "GO":
                    torrentSize = (double)(number * 1024 * 1024 * 1024);
                    break;
                default:
                    torrentSize = 0;
                    break;
            }

            return torrentSize;
        }

        public static string GetMagnetLink(string text)
        {
            var regexMagnet = new Regex("href=['\"]magnet:(.*?)['\"]");
            var matchesMagnet = regexMagnet.Matches(text);

            if (matchesMagnet.Count <= 0)
            {
                return null;
            }

            var valueMagnet = matchesMagnet[0].Groups[1].Value;
            return $"magnet:{valueMagnet}";
        }
    }
}
