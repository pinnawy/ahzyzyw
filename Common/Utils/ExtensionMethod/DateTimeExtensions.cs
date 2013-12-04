using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Everest.Library.ExtensionMethod
{
    /// <summary>
    /// 
    /// </summary>
    public static class DateTimeExtensions
    {

        /// <summary>
        /// Toes the globalized date time string.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <returns></returns>
        public static string ToGlobalizedDateTimeString(this DateTime dt)
        {
            return dt.ToString("s");
        }

        /// <summary>
        /// Toes the globalized date string.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <returns></returns>
        public static string ToGlobalizedDateString(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// Toes the globalized time string.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <returns></returns>
        public static string ToGlobalizedTimeString(this DateTime dt)
        {
            return dt.ToString("HH:mm:ss");
        }
    }
}
