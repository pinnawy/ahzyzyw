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
using System.Reflection;

namespace Everest.Library.ExtensionMethod
{
    public static class TypeExtensions
    {
        readonly static List<Type> numericalTypes = new List<Type>(){            
            typeof(Int16),
            typeof(Int32),
            typeof(Int64),
            typeof(float),
            typeof(long),
            typeof(double),
            typeof(decimal)
        };
        /// <summary>
        /// Gets the type name without version.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static string GetTypeNameWithoutVersion(this Type type)
        {
            string[] str = type.AssemblyQualifiedName.Split(',');
            return string.Format("{0},{1}", str[0], str[1]);
        }

        /// <summary>
        /// Gets all child types.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static IEnumerable<Type> GetAllChildTypes(this Type type)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => !a.GlobalAssemblyCache)
                .ToList();
            var types = new List<Type>();
            foreach (var assembly in assemblies)
            {
                try
                {
                    types.AddRange(assembly.GetTypes());
                }
                catch { }
            }
            var targetTypes = types.Where(p => type.IsAssignableFrom(p) && type != p);
            return targetTypes;
        }


        /// <summary>
        /// Determines whether [is numerical type] [the specified type].
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        /// 	<c>true</c> if [is numerical type] [the specified type]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNumericalType(this Type type)
        {
            return numericalTypes.Contains(type);
        }

        /// <summary>
        /// Gets the property value.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="o">The o.</param>
        /// <returns></returns>
        public static object GetPropertyValue(this Type type, string propertyName, object o)
        {
            var propertyInfo = type.GetProperty(propertyName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            if (propertyInfo != null)
            {
                var value = propertyInfo.GetValue(o, new object[0]);
                return value;
            }
            return null;
        }

        /// <summary>
        /// Sets the property value.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="o">The o.</param>
        /// <param name="value">The value.</param>
        public static void SetPropertyValue(this Type type, string propertyName, object o, object value)
        {
            var propertyInfo = type.GetProperty(propertyName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            propertyInfo.SetValue(o, value, new object[0]);
        }
    }
}

