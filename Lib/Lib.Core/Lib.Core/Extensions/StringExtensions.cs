using System;
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
                source = source.RemoveAccents();
                target = target.RemoveAccents();
            }

            return source.IndexOf(target, StringComparison.CurrentCultureIgnoreCase) != -1;
        }

        public static int IndexOfIgnoreCase(this string source, string target, bool ignoreAccents = true)
        {
            if (ignoreAccents)
            {
                source = source.RemoveAccents();
                target = target.RemoveAccents();
            }

            return source.IndexOf(target, StringComparison.CurrentCultureIgnoreCase);
        }
        
        public static bool EndsWithIgnoreCase(this string source, string target, bool ignoreAccents = true)
        {
            if (ignoreAccents)
            {
                source = source.RemoveAccents();
                target = target.RemoveAccents();
            }

            return source.EndsWith(target, StringComparison.CurrentCultureIgnoreCase);
        }

        public static bool StartsWithIgnoreCase(this string source, string target, bool ignoreAccents = true)
        {
            if (ignoreAccents)
            {
                source = source.RemoveAccents();
                target = target.RemoveAccents();
            }

            return source.StartsWith(target, StringComparison.CurrentCultureIgnoreCase);
        }

        public static string RemoveFirstCharacter(this string text)
        {
            return text.Substring(1, text.Length - 1);
        }

        public static string RemoveLastCharacter(this string text)
        {
            return text.Substring(0, text.Length - 1);
        }

        public static string RemoveAccents(this string text)
        {
            return text.Replace("�", "a")
                .Replace("�", "a")
                .Replace("�", "e")
                .Replace("�", "e")
                .Replace("�", "e")
                .Replace("�", "i")
                .Replace("�", "i")
                .Replace("�", "o")
                .Replace("�", "o")
                .Replace("�", "u")
                .Replace("�", "u")
                .Replace("�", "u");
        }
    }
}