using Lib.Core;
using System;
using System.Text.RegularExpressions;

namespace Lib.ApiServices.Torrents
{
    public static class ScrappingHelper
    {
        public static double ConvertSizeStringToNumber(string sizeString)
        {
            sizeString = sizeString.Replace(",", ".");
            sizeString = sizeString.Replace(" ", " ");

            var parts = sizeString.Split(' ');
            var number = Convert.ToDouble(parts[0]);
            var unit = parts[1];
            double torrentSize;
            
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

        public static Tuple<string, string> GetParamsFromLink(string text)
        {
            var regex = new Regex("<a.*? href=['\"](.*?)['\"].*?>(.*?)</a>", RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);
            var matches = regex.Matches(text);
            if (matches.Count < 1 || matches[0].Groups.Count < 3)
            {
                return null;
            }

            var link = matches[0].Groups[1].Value;
            var name = StringExtensions.RemoveHtml(matches[0].Groups[2].Value);

            return Tuple.Create(name, link);
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
