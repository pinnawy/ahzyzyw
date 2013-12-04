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
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Globalization;
namespace Everest.Library.ExtensionMethod
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Serializes to XML.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="fileName">Name of the file.</param>
        public static void SerializeToXml(this object o, string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(o.GetType());
            FileExtensions.EnsureDirtectoryExists(Path.GetDirectoryName(fileName));
            using (FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(stream, o);
            }
        }
        /// <summary>
        /// Deserializes the XML.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public static T DeserializeFromXmlFile<T>(string fileName)
        {
            T o;
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                o = (T)serializer.Deserialize(stream);
            }
            return o;
        }

        /// <summary>
        /// Serializes to XML.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <returns></returns>
        public static string SerializeToXml(this object o)
        {
            XmlSerializer serializer = new XmlSerializer(o.GetType());
            StringBuilder stringBuilder = new StringBuilder();
            using (TextWriter textWriter = new StringWriter(stringBuilder))
            {
                serializer.Serialize(textWriter, o);
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Deserializes from XML string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml">The XML.</param>
        /// <returns></returns>
        public static T DeserializeFromXmlString<T>(string xml)
        {
            return (T)DeserializeFromXmlString(xml, typeof(T));

        }

        /// <summary>
        /// Deserializes from XML string.
        /// </summary>
        /// <param name="xml">The XML.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static object DeserializeFromXmlString(string xml, Type type)
        {
            object o;
            XmlSerializer serializer = new XmlSerializer(type);
            using (TextReader textReader = new StringReader(xml))
            {
                o = serializer.Deserialize(textReader);
            }
            return o;
        }


        /// <summary>
        /// Toes the globalized string.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <returns></returns>
        public static string ToGlobalizedString(this object o)
        {
            if (o == null)
            {
                return string.Empty;
            }
            if (o is DateTime)
            {
                return ((DateTime)o).ToGlobalizedDateTimeString();
            }
            if (o.GetType().IsNumericalType())
            {
                var enusCulture = new CultureInfo("en-us", false);
                return ((IFormattable)o).ToString("", enusCulture.NumberFormat);
            }
            return o.ToString();
        }

        public static string TryToString(this object o)
        {
            if (o == null)
            {
                return string.Empty;
            }
            return o.ToString();
        }
    }
}

