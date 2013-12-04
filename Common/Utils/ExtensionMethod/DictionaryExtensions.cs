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
using System.Linq;
using System.Text;
using System.Collections.Specialized;

namespace Everest.Library.ExtensionMethod
{
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Gets the string.
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="dic">The dic.</param>
        /// <param name="key">The key.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static string GetString<K, V>(this IDictionary<K, V> dic, K key, string defaultValue)
        {
            if (dic.ContainsKey(key) && dic[key] != null)
            {
                return dic[key].ToString();
            }
            return defaultValue;
        }
        /// <summary>
        /// Gets the boolean.
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="dic">The dic.</param>
        /// <param name="key">The key.</param>
        /// <param name="defaultValue">if set to <c>true</c> [default value].</param>
        /// <returns></returns>
        public static bool GetBoolean<K, V>(this IDictionary<K, V> dic, K key, bool defaultValue)
        {
            bool value = defaultValue;
            if (dic.ContainsKey(key) && dic[key] != null)
            {
                bool.TryParse(dic[key].ToString(), out value);
            }
            return value;
        }
        /// <summary>
        /// Gets the boolean.
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="dic">The dic.</param>
        /// <param name="key">The key.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static bool? GetBoolean<K, V>(this IDictionary<K, V> dic, K key, bool? defaultValue)
        {
            if (dic.ContainsKey(key) && dic[key] != null)
            {
                return bool.Parse(dic[key].ToString());
            }
            return defaultValue;
        }
        /// <summary>
        /// Gets the int.
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="dic">The dic.</param>
        /// <param name="key">The key.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static int GetInt<K, V>(this IDictionary<K, V> dic, K key, int defaultValue)
        {
            int value = defaultValue;
            if (dic.ContainsKey(key) && dic[key] != null)
            {
                int.TryParse(dic[key].ToString(), out value);
            }
            return value;
        }
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="dic">The dic.</param>
        /// <param name="key">The key.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static T GetValue<K, V, T>(this IDictionary<K, V> dic, K key, T defaultValue)
            where T : class
        {
            if (dic.ContainsKey(key) && dic[key] is T)
            {
                return dic[key] as T;
            }
            return defaultValue;
        }

        /// <summary>
        /// Serializes the dictionary to XML.
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="dic">The dic.</param>
        /// <returns></returns>
        public static string SerializeDictionaryToXml<K, V>(this IDictionary<K, V> dic)
        {
            List<KeyValuePair<K, V>> list = new List<KeyValuePair<K, V>>();
            foreach (var item in dic)
            {
                list.Add(item);
            }
            return list.SerializeToXml();
        }
        /// <summary>
        /// Deserializes the dictionary from XML string.
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="xml">The XML.</param>
        /// <returns></returns>
        public static IDictionary<K, V> DeserializeDictionaryFromXmlString<K, V>(string xml)
        {
            List<KeyValuePair<K, V>> list = ObjectExtensions.DeserializeFromXmlString<List<KeyValuePair<K, V>>>(xml);
            Dictionary<K, V> dic = new Dictionary<K, V>();
            foreach (var item in list)
            {
                dic.Add(item.Key, item.Value);
            }
            return dic;
        }

        /// <summary>
        /// Toes the name value collection.
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="dic">The dic.</param>
        public static NameValueCollection ToNameValueCollection<K, V>(this IDictionary<K, V> dic)
        {
            if (dic == null)
            {
                return null;
            }
            NameValueCollection nameValues = new NameValueCollection();
            foreach (var value in dic)
            {
                nameValues.Add(value.Key.ToString(), (value.Value == null || value.Value is DBNull) ? "" : value.Value.ToGlobalizedString());
            }
            return nameValues;
        }

        public static void CopyTo<K, V>(this IDictionary<K, V> source, IDictionary<K, V> target)
        {
            foreach (var key in source.Keys)
            {
                if (!target.ContainsKey(key))
                {
                    target.Add(key, source[key]);
                }
            }
        }

        /// <summary>
        /// Determines whether [is value empty] [the specified source].
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>
        /// 	<c>true</c> if [is value empty] [the specified source]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValueEmpty(this IDictionary<string, string> source)
        {
            bool isBlank = true;
            foreach (var value in source.Values)
            {
                if (StringExtensions.IsNullOrEmptyTrim(value))
                {
                    isBlank = true;
                }
                else
                {
                    isBlank = false;
                    break;
                }
            }
            return isBlank;
        }

        public static string ToKeyValueString<T, V>(this IDictionary<T, V> dic)
        {
            if (dic == null)
            {
                return null;
            }
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var key in dic.Keys)
            {
                stringBuilder.AppendFormat("{0}:{1},", key, dic[key]);
            }
            stringBuilder.RemoveLastSpecifiedChar(',');
            return stringBuilder.ToString();
        }
    }

}

