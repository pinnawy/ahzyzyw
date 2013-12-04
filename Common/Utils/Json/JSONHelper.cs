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
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ElpSimWan.Json
{
    public static class JSONHelper
    {
        static readonly long DatetimeMinTimeTicks = new DateTime(0x7b2, 1, 1, 0, 0, 0, DateTimeKind.Utc).Ticks;

        /// <summary>
        /// Toes the JSON.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns></returns>
        public static string ToJSON(this object obj)
        {
            return JsonConvert.SerializeObject(obj, new JavaScriptDateTimeConverter());
        }
        /// <summary>
        /// Deserilizes the JSON.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json">The json.</param>
        /// <returns></returns>
        public static T DeserializeJSON<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// Deserilizes the JSON.
        /// </summary>
        /// <param name="json">the json</param>
        /// <param name="type">object type</param>
        /// <returns></returns>
        public static object DeserializeObject(this string json, Type type)
        {
            return JsonConvert.DeserializeObject(json, type);
        }

        /// <summary>
        /// Deserializes the string into date time.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns></returns>
        public static DateTime DeserializeStringIntoDateTime(this string s)
        {
            long num;
            Match match = Regex.Match(s, "^/Date\\((?<ticks>-?[0-9]+)(?:[a-zA-Z]|(?:\\+|-)[0-9]{4})?\\)/");
            if (long.TryParse(match.Groups["ticks"].Value, out num))
            {
                return new DateTime((num * 0x2710L) + DatetimeMinTimeTicks, DateTimeKind.Utc);
            }
            return DateTime.MinValue;
        }


        /// <summary>
        /// Quotes the string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string QuoteString(string value)
        {
            StringBuilder builder = null;
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }
            int startIndex = 0;
            int count = 0;
            for (int i = 0; i < value.Length; i++)
            {
                char c = value[i];
                if ((((c == '\r') || (c == '\t')) || ((c == '"') || (c == '\''))) || ((((c == '<') || (c == '>')) || ((c == '\\') || (c == '\n'))) || (((c == '\b') || (c == '\f')) || (c < ' '))))
                {
                    if (builder == null)
                    {
                        builder = new StringBuilder(value.Length + 5);
                    }
                    if (count > 0)
                    {
                        builder.Append(value, startIndex, count);
                    }
                    startIndex = i + 1;
                    count = 0;
                }
                switch (c)
                {
                    case '<':
                    case '>':
                    case '\'':
                        {
                            AppendCharAsUnicode(builder, c);
                            continue;
                        }
                    case '\\':
                        {
                            builder.Append(@"\\");
                            continue;
                        }
                    case '\b':
                        {
                            builder.Append(@"\b");
                            continue;
                        }
                    case '\t':
                        {
                            builder.Append(@"\t");
                            continue;
                        }
                    case '\n':
                        {
                            builder.Append(@"\n");
                            continue;
                        }
                    case '\f':
                        {
                            builder.Append(@"\f");
                            continue;
                        }
                    case '\r':
                        {
                            builder.Append(@"\r");
                            continue;
                        }
                    case '"':
                        {
                            builder.Append("\\\"");
                            continue;
                        }
                }
                if (c < ' ')
                {
                    AppendCharAsUnicode(builder, c);
                }
                else
                {
                    count++;
                }
            }
            if (builder == null)
            {
                return value;
            }
            if (count > 0)
            {
                builder.Append(value, startIndex, count);
            }
            return builder.ToString();
        }

        /// <summary>
        /// Appends the char as unicode.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="c">The c.</param>
        private static void AppendCharAsUnicode(StringBuilder builder, char c)
        {
            builder.Append(@"\u");
            builder.AppendFormat(CultureInfo.InvariantCulture, "{0:x4}", new object[] { (int)c });
        }


        /// <summary>
        /// Quotes the string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="addQuotes">if set to <c>true</c> [add quotes].</param>
        /// <returns></returns>
        public static string QuoteString(string value, bool addQuotes)
        {
            string str = QuoteString(value);
            if (addQuotes)
            {
                str = "\"" + str + "\"";
            }
            return str;
        }

    }
}

