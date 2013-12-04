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

namespace Everest.Library.ExtensionMethod
{
    /// <summary>
    /// 
    /// </summary>
    public static class StreamExtensions
    {
        /// <summary>
        /// Copies to.
        /// </summary>
        /// <param name="src">The SRC.</param>
        /// <param name="dest">The dest.</param>
        public static void CopyTo(this Stream src, Stream dest)
        {
            byte[] buffer = new byte[0x10000];
            int bytes;
            try
            {
                while ((bytes = src.Read(buffer, 0, buffer.Length)) > 0)
                {
                    dest.Write(buffer, 0, bytes);
                }
            }
            finally
            {
                dest.Flush();
            }
        }

        /// <summary>
        /// Reads the string body.
        /// </summary>
        /// <param name="src">The stream.</param>
        /// <returns></returns>
        public static string ReadString(this Stream src)
        {
            src.Seek(0, SeekOrigin.Begin);
            TextReader reader = new StreamReader(src, Encoding.UTF8);
            return reader.ReadToEnd();
        }
        /// <summary>
        /// Writes the string.
        /// </summary>
        /// <param name="src">The stream.</param>
        /// <param name="s">The s.</param>
        public static void WriteString(this Stream src, string s)
        {
            TextWriter writer = new StreamWriter(src, Encoding.UTF8);
            writer.Write(s);
            writer.Flush();
        }

        /// <summary>
        /// Saves as.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="fileName">Name of the file.</param>
        public static string SaveAs(this Stream stream, string filePath)
        {
            return SaveAs(stream, filePath, true);
        }
        /// <summary>
        /// Saves as.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="isOverwrite">if set to <c>true</c> [is overwrite].</param>
        public static string SaveAs(this Stream stream, string filePath, bool isOverwrite)
        {
            var data = new byte[stream.Length];
            var length = stream.Read(data, 0, (int)stream.Length);
            return SaveAs(data, filePath, isOverwrite);
        }
        /// <summary>
        /// Saves as.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="isOverwrite">if set to <c>true</c> [is overwrite].</param>
        /// <returns>saved file absolute path</returns>
        public static string SaveAs(byte[] data, string filePath, bool isOverwrite)
        {
            string directory = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            if (!isOverwrite && File.Exists(filePath))
            {
                string fileNameWithoutEx = Path.GetFileNameWithoutExtension(filePath);
                string extension = Path.GetExtension(filePath);

                int i = 1;
                do
                {
                    filePath = Path.Combine(directory, string.Format("{0}-{1}{2}", fileNameWithoutEx, i, extension));
                    i++;
                } while (File.Exists(filePath));
            }
            using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                fileStream.Write(data, 0, data.Length);
            }
            return filePath;
        }
    }
}

