using System;
using System.Text.RegularExpressions;

namespace Lib.Core
{
    public static class RegexHelper
    {
        public static Tuple<string, string> GetParamsFromLink(string text)
        {
            var regex = new Regex("<a.*? href=['\"](.*?)['\"].*?>(.*?)</a>", RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace);
            var matches = regex.Matches(text);
            if (matches.Count < 1 || matches[0].Groups.Count < 3)
            {
                return null;
            }

            var link = matches[0].Groups[1].Value;
            var name = RemoveHtml(matches[0].Groups[2].Value);

            return Tuple.Create(name, link);
        }

        public static string RemoveCarriageReturnAndOtherFuckingCharacters(string text)
        {
            return text
                .Replace("<br>", "")
                .Replace("<br/>", "")
                .Replace("<br />", "")
                .Replace("  ", " ")
                .Replace("  ", " ")
                .Replace("\t", "")
                .Replace("\r\n", "")
                .Replace("\r", "")
                .Replace("\n", "")
                .Replace(">               <", "><")
                .Replace(">              <", "><")
                .Replace(">             <", "><")
                .Replace(">            <", "><")
                .Replace(">           <", "><")
                .Replace(">          <", "><")
                .Replace(">         <", "><")
                .Replace(">        <", "><")
                .Replace(">       <", "><")
                .Replace(">      <", "><")
                .Replace(">     <", "><")
                .Replace(">    <", "><")
                .Replace(">   <", "><")
                .Replace(">  <", "><")
                .Replace("> <", "><").Trim();
        }

        public static string RemoveHtml(string text)
        {
            return Regex.Replace(text, @"\s*<.*?>\s*", " ", RegexOptions.Singleline).Replace("  ", " ").Replace("&nbsp;", "").Trim();
        }

        public static string RemovePattern(string text, string pattern)
        {
            return Regex.Replace(text, $@"\s*{pattern}\s*", " ", RegexOptions.Singleline).Replace("  ", " ").Replace("&nbsp;", "").Trim();
        }

        public static string RemoveBrackets(string text)
        {
            return RegexHelper.RemovePattern(text, "(\\(.*?\\))");
        }
    }
}