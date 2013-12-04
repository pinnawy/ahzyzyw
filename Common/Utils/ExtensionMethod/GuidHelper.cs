using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Everest.Library.ExtensionMethod
{
    public static class GuidHelper
    {
        static Regex guidFormat = new Regex(
               "^[A-Fa-f0-9]{32}$|" +
               "^({|\\()?[A-Fa-f0-9]{8}-([A-Fa-f0-9]{4}-){3}[A-Fa-f0-9]{12}(}|\\))?$|" +
               "^({)?[0xA-Fa-f0-9]{3,10}(, {0,1}[0xA-Fa-f0-9]{3,6}){2}, {0,1}({)([0xA-Fa-f0-9]{3,4}, {0,1}){7}[0xA-Fa-f0-9]{3,4}(}})$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        public static bool TryParseGuid(string s, out Guid result)
        {
            if (s == null)
                throw new ArgumentNullException("s");

            Match match = guidFormat.Match(s);
            if (match.Success)
            {
                result = new Guid(s);
                return true;
            }
            else
            {
                result = Guid.Empty;
                return false;
            }
        }
    }
}
