using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTADotNet
{
    public class QueryStringFormatter
    {
        public string Format(IList<Tuple<string, string>> parameters)
        {
            if (parameters == null)
                return string.Empty;
            var sb = new StringBuilder();
            if (parameters.Count > 0)
                sb.Append("?");
            bool isFirst = true;
            foreach(var p in parameters)
            {
                if (!isFirst)
                    sb.Append("&");
                isFirst = false;
                sb.AppendFormat("{0}={1}", p.Item1, p.Item2);
            }
            return sb.ToString();
        }

    }
}
