using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
namespace Everest.Library.ExtensionMethod
{
    public static class AssemblyExtesions
    {
        public static Version GetAssemblyVersion(string filePath)
        {
            var assemblyName = AssemblyName.GetAssemblyName(filePath);

            return assemblyName.Version;
        }
    }
}
