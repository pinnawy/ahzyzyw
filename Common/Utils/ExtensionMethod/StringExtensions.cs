/*
Kooboo is a content management system based on ASP.NET MVC framework. Copyright 2009 Yardi Technology Limited.

This program is free software: you can redistribute it and/or modify it under the terms of the
GNU General Public License version 3 as published by the Free Software Foundation.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with this program.
If not, see http://www.kooboo.com/gpl3/.
*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Everest.Library.ExtensionMethod
{
    public static class StringExtensions
    {
        #region Join
        /// <summary>
        /// Removes the last specified char.
        /// </summary>
        /// <param name="stringBuilder">The string builder.</param>
        /// <param name="c">The c.</param>
        public static StringBuilder RemoveLastSpecifiedChar(this StringBuilder stringBuilder, char c)
        {
            if (stringBuilder.Length == 0)
                return stringBuilder;
            if (stringBuilder[stringBuilder.Length - 1] == c)
            {
                stringBuilder.Remove(stringBuilder.Length - 1, 1);
            }
            return stringBuilder;
        }

        /// <summary>
        /// Joins the string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <param name="separator">The separator.</param>
        /// <returns></returns>
        public static string JoinString<T>(this IEnumerable<T> enumerable, string separator)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in enumerable)
            {
                stringBuilder.AppendFormat("{0},", item.ToString());
            }
            stringBuilder.RemoveLastSpecifiedChar(',');
            return stringBuilder.ToString();
        }
        #endregion

        #region Strip Tags
        /// <summary>
        /// 去除Html Xml 标记        
        /// </summary>
        /// <param name="content">The content.</param>
        /// <returns></returns>
        public static string StripHtmlXmlTags(this string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                return content;
            }
            return Regex.Replace(content, "<[^>]+>?", "", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }

        /// <summary>
        /// 去除所有的标记
        /// </summary>
        /// <param name="stringToStrip">The string to strip.</param>
        /// <returns></returns>
        public static string StripAllTags(this string stringToStrip)
        {
            if (string.IsNullOrEmpty(stringToStrip))
            {
                return stringToStrip;
            }
            // paring using RegEx
            //
            stringToStrip = Regex.Replace(stringToStrip, "</p(?:\\s*)>(?:\\s*)<p(?:\\s*)>", "\n\n", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            stringToStrip = Regex.Replace(stringToStrip, "<br(?:\\s*)/>", "\n", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            stringToStrip = Regex.Replace(stringToStrip, "\"", "''", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            stringToStrip = StripHtmlXmlTags(stringToStrip);

            return stringToStrip;
        }
        #endregion

        /// <summary>
        /// Truncates the specified s.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="wordsLimit">The words limit.</param>
        /// <returns></returns>
        public static string Truncate(this string s, int wordsLimit)
        {
            if (s.Length < wordsLimit)
            {
                return s;
            }
            return s.Substring(0, wordsLimit);
        }

        #region Cast type
        /// <summary>
        /// To the int.
        /// </summary>
        /// <param name="s">The s ,for example:"1,2,3" .</param>
        /// <param name="spliter">The spliter. for example:','</param>
        /// <returns></returns>
        public static IEnumerable<int> ToInt(this string s, params char[] spliter)
        {
            string[] strArr = s.Split(spliter);
            List<int> ints = new List<int>();
            foreach (var str in strArr)
            {
                if (!string.IsNullOrEmpty(str))
                {
                    ints.Add(int.Parse(str));
                }
            }
            return ints;
        }

        /// <summary>
        /// Gets the nullable bool.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool? GetNullableBool(this string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return bool.Parse(value);
            }
            return null;
        }
        /// <summary>
        /// Gets the nullable int.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static int? GetNullableInt(this string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return int.Parse(value);
            }
            return null;
        }

        /// <summary>
        /// Gets the nullable GUID.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static Guid? GetNullableGuid(this string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return new Guid(value);
            }
            return null;
        }
        #endregion

        #region Trim
        /// <summary>
        /// Trims the specified s.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns></returns>
        public static string TryTrim(this string s)
        {
            if (s != null)
            {
                return s.Trim();
            }
            return s;
        }
        #endregion

        static Regex unasscii = new Regex(@"[^a-z|^_|^\d|^\u4e00-\u9fa5]+", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase);
        /// <summary>
        /// Replaces to valid URL.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns></returns>
        public static string ReplaceToValidUrl(this string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                return unasscii.Replace(s, "-");
            }
            return s;
        }

        /// <summary>
        /// Replaces the specified s.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        /// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
        /// <returns></returns>
        public static string Replace(this string s, string oldValue, string newValue, bool ignoreCase)
        {
            if (ignoreCase)
            {
                return Microsoft.VisualBasic.Strings.Replace(s, oldValue, newValue, 1, -1, Microsoft.VisualBasic.CompareMethod.Text);
            }
            else
            {
                return s.Replace(oldValue, newValue);
            }
        }

        /// <summary>
        /// Determines whether [is null or empty trim] [the specified s].
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>
        /// 	<c>true</c> if [is null or empty trim] [the specified s]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrEmptyTrim(string s)
        {
            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(s.Trim()))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Trims the specified s.
        /// </summary>
        /// <param name="s">The s.</param>
        public static string Trim(string s)
        {
            if (s == null)
            {
                return null;
            }
            return s.Trim();
        }

        /// <summary>
        /// Appends the HTML line.
        /// </summary>
        /// <param name="stringBuilder">The string builder.</param>
        /// <param name="s">The s.</param>
        public static void AppendHtmlLine(this StringBuilder stringBuilder, string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                stringBuilder.AppendFormat("{0}<br/>", s);
            }
        }


        /// <summary>
        /// Determines whether the specified s is true.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>
        /// 	<c>true</c> if the specified s is true; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsTrue(string s)
        {
            if (IsNullOrEmptyTrim(s))
            {
                return false;
            }
            s = s.ToLower();
            return s == "on" || s == "true";
        }

        private static Regex chineseRegex = new Regex("[\u4e00-\u9fa5]", RegexOptions.Compiled);

        /// <summary>
        /// ToSqlLikeQueryString  add by yuwang 2011-1-5
        /// </summary>
        /// <param name="s">The s</param>
        public static string ToSqlLikeQueryString(this string s)
        {
            return s.Replace("'", "''").Replace("[", "[[]").Replace("%", "[%]").Replace("_", "[_]");
        }

        /// <summary>
        /// 获取字符串右边的子串
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="count">获取数量</param>
        /// <returns>子串</returns>
        public static string RightSubstring(this string str, int count)
        {
            if (str.Length <= count)
                return str;

            return str.Substring(str.Length - count);
        }

        /// <summary>
        /// EscapeHTML add by yuwang 2011-1-21
        /// </summary>
        /// <param name="s">The s</param>
        public static string EscapeHTML(this string s)
        {
            return s.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;");
        }

        /// <summary>
        /// 判断字符串是否是可忽略的数据查询参数
        /// </summary>
        /// <param name="param">参数值</param>
        public static bool IsIgnoreQueryCondition(this string param)
        {
            return string.IsNullOrEmpty(param) || string.IsNullOrWhiteSpace(param) || param == "null";
        }
    }
}

