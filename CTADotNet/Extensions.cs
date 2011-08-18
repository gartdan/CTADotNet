using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CTADotNet
{
    public static class Extensions
    {
        public static void AddIfNotNull(this List<Tuple<string, string>> list, object o, Tuple<string, string> itemToAdd)
        {
            if (o != null)
                list.Add(itemToAdd);
        }

        public static string ToYYYYMMDD(this DateTime? date)
        {
            if (date == null)
                return string.Empty;
            var val = date.Value.ToString("yyyyMMdd");
            return val;
        }

        public static string RemoveWhitespace(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            return new Regex(@"\s*").Replace(str, string.Empty);
        }
    }
}
