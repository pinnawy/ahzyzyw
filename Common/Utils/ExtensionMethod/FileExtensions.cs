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
using System.IO;
using System.Security.AccessControl;

namespace Everest.Library.ExtensionMethod
{
    public static class FileExtensions
    {
        /// <summary>
        /// Gets the file body.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public static string GetFileBody(string absoluteFilePath)
        {
            using (FileStream fileStream = new FileStream(absoluteFilePath, FileMode.Open, FileAccess.Read))
            {
                return fileStream.ReadString();
            }
        }

        /// <summary>
        /// Gets the file body.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public static byte[] GetFileBodyB(string absoluteFilePath)
        {
            return File.ReadAllBytes(absoluteFilePath);
        }

        /// <summary>
        /// Saves the file body.
        /// </summary>
        /// <param name="absoluteFilePath">The absolute file path.</param>
        /// <param name="body">The body.</param>
        public static void SaveFileBody(string absoluteFilePath, string body)
        {
            FileExtensions.EnsureDirtectoryExists(Path.GetDirectoryName(absoluteFilePath));

            using (FileStream fileStream = new FileStream(absoluteFilePath, FileMode.Create, FileAccess.Write))
            {
                fileStream.WriteString(body);
            }
        }

        /// <summary>
        /// Saves the file body.
        /// </summary>
        /// <param name="absoluteFilePath">The absolute file path.</param>
        /// <param name="body">The body.</param>
        public static void SaveFileBodyB(string absoluteFilePath, byte[] body)
        {
            File.WriteAllBytes(absoluteFilePath, body);
        }

        /// <summary>
        /// Deletes the file.
        /// </summary>
        /// <param name="path">The path.</param>
        public static void DeleteFile(string absolutePath)
        {
            if (File.Exists(absolutePath))
                File.Delete(absolutePath);
        }

        /// <summary>
        /// 删除目录
        /// </summary>
        /// <param name="path">目录路径</param>
        public static void DeleteDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                foreach (string file in Directory.GetFiles(path))
                    File.Delete(file);

                foreach (string dir in Directory.GetDirectories(path))
                    DeleteDirectory(dir);

                Directory.Delete(path);
            }
        }

        /// <summary>
        /// Ensures the dirtectory exists.
        /// </summary>
        /// <param name="dir">The dir.</param>
        public static void EnsureDirtectoryExists(string dir)
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }
        /// <summary>
        /// Copies the directory.
        /// </summary>
        /// <param name="src">The SRC.</param>
        /// <param name="dst">The DST.</param>
        public static void CopyDirectory(string src, string dst)
        {
            CopyDirectory(src, dst, true);
        }
        /// <summary>
        /// Copies the directory.
        /// </summary>
        /// <param name="src">The SRC.</param>
        /// <param name="dst">The DST.</param>
        public static void CopyDirectory(string src, string dst, bool @override)
        {
            if (dst[dst.Length - 1] != Path.DirectorySeparatorChar)
                dst += Path.DirectorySeparatorChar;
            if (!Directory.Exists(dst)) Directory.CreateDirectory(dst);
            DirectoryInfo directoryInfo = new DirectoryInfo(src);
            var files = directoryInfo.GetFileSystemInfos();
            foreach (var f in files)
            {
                if ((f.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                {
                    // Sub directories

                    if (Directory.Exists(f.FullName))
                        CopyDirectory(f.FullName, dst + Path.GetFileName(f.Name), @override);
                    // Files in directory

                    else
                    {
                        var dstFile = dst + Path.GetFileName(f.FullName);
                        if (!File.Exists(dstFile) || (File.Exists(dstFile) && @override))
                        {
                            File.Copy(f.FullName, dstFile, @override);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Determines whether [has write permission on dir] [the specified path].
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>
        /// 	<c>true</c> if [has write permission on dir] [the specified path]; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasWritePermissionOnDir(string path)
        {
            if (Directory.Exists(path))
            {
                try
                {
                    string temp = Path.Combine(path, Guid.NewGuid().ToString());
                    Directory.CreateDirectory(temp);
                    Directory.Delete(temp);
                }
                catch (UnauthorizedAccessException e)
                {
                    return false;
                }
            }
            else if (File.Exists(path))
            {
                try
                {
                    using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Write, FileShare.None))
                    {

                    }
                }
                catch (UnauthorizedAccessException e)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 去掉文件只读属性
        /// </summary>
        /// <param name="path"></param>
        public static void DelReadOnlyAttrib(string path)
        {
            FileAttributes atr = File.GetAttributes(path);
            //如果属性中包含只读性   
            if (atr == (atr | FileAttributes.ReadOnly))
            {
                //去除文件只读性   
                atr = atr & (~FileAttributes.ReadOnly);
                File.SetAttributes(path, atr);
            }
        }
    }
}

