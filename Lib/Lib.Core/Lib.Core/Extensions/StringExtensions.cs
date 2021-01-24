using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Lib.Core
{
    public static class StringExtensions
    {
        public static bool ContainsIgnoreCase(this string source, string target, bool ignoreAccents = true)
        {
            if (ignoreAccents)
            {
                source = source.ReplaceAccentsByOriginalLetters();
                target = target.ReplaceAccentsByOriginalLetters();
            }

            return source.IndexOf(target, StringComparison.CurrentCultureIgnoreCase) != -1;
        }

        public static int IndexOfIgnoreCase(this string source, string target, bool ignoreAccents = true)
        {
            if (ignoreAccents)
            {
                source = source.ReplaceAccentsByOriginalLetters();
                target = target.ReplaceAccentsByOriginalLetters();
            }

            return source.IndexOf(target, StringComparison.CurrentCultureIgnoreCase);
        }
        
        public static bool EndsWithIgnoreCase(this string source, string target, bool ignoreAccents = true)
        {
            if (ignoreAccents)
            {
                source = source.ReplaceAccentsByOriginalLetters();
                target = target.ReplaceAccentsByOriginalLetters();
            }

            return source.EndsWith(target, StringComparison.CurrentCultureIgnoreCase);
        }

        public static bool StartsWithIgnoreCase(this string source, string target, bool ignoreAccents = true)
        {
            if (ignoreAccents)
            {
                source = source.ReplaceAccentsByOriginalLetters();
                target = target.ReplaceAccentsByOriginalLetters();
            }

            return source.StartsWith(target, StringComparison.CurrentCultureIgnoreCase);
        }

        public static string Clean(this string text)
        {
            return text.RemoveBracketsContent().RemoveParenthesisContent().RemoveSpecialCharacters().RemoveDoubleSpacesAndTrim();
        }

        public static string RemoveFirstCharacter(this string text)
        {
            return text.Substring(1, text.Length - 1);
        }

        public static string RemoveLastCharacter(this string text)
        {
            return text.Substring(0, text.Length - 1);
        }

        public static string RemoveCarriageReturnAndOtherFuckingCharacters(this string text)
        {
            return text
                .Replace("<br>", string.Empty)
                .Replace("<br/>", string.Empty)
                .Replace("<br />", string.Empty)
                .Replace("\t", string.Empty)
                .Replace("\r\n", string.Empty)
                .Replace("\r", string.Empty)
                .Replace("\n", string.Empty)
                .RemoveDoubleSpacesAndTrim();
        }

        public static string RemoveHtml(this string text)
        {
            return RemovePattern(text, "<.*?>");
        }

        public static string RemoveBracketsContent(this string text, string replaceBy = "")
        {
            return RemovePattern(text, "\\[.*?\\]", replaceBy);
        }

        public static string RemoveParenthesisContent(this string text, string replaceBy = "")
        {
            return RemovePattern(text, "\\(.*?\\)", replaceBy);
        }

        public static string RemovePattern(this string text, string pattern, string replaceBy = "")
        {
            return Regex.Replace(text, $"{pattern}", replaceBy, RegexOptions.Singleline);
        }

        public static string RemoveSpecialCharacters(this string text, string replaceBy = "")
        {
            return Regex.Replace(text, "[^a-zA-Z0-9\u00C0-\u00FF]", replaceBy);
        }

        public static string RemoveDoubleSpacesAndTrim(this string text)
        {
            text = text.Replace("&nbsp;", " ");

			while (text.Contains("  "))
			{
				text = text.Replace("  ", " ");
			}

            return text.Trim();
        }

        public static string ReplaceAccentsByOriginalLetters(this string text)
        {
            return text
                .Replace("à", "a")
                .Replace("â", "a")
                .Replace("é", "e")
                .Replace("è", "e")
                .Replace("ê", "e")
                .Replace("î", "i")
                .Replace("ï", "i")
                .Replace("ô", "o")
                .Replace("ö", "o")
                .Replace("ù", "u")
                .Replace("û", "u")
                .Replace("ü", "u");
        }

        public static string TransformForStorage(this string text)
        {
            foreach (var forbiddenCharacter in Path.GetInvalidFileNameChars())
            {
                text = text.Replace(forbiddenCharacter.ToString(), string.Empty);
            }

            return text.Replace("&", "and").RemoveDoubleSpacesAndTrim();
        }
    }
}
