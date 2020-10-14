using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib.Core
{
    public static class ConversionHelper
    {
        public static string Base64ToString(string toConvert)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(toConvert));
        }

        public static string StringToBase64(string toConvert)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(toConvert));
        }
    }
}