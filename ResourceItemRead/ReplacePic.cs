using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceItemRead
{
    class ReplacePic
    {
        public static void Start()
        {
            var minDir = @"C:\Users\Taly\Desktop\Folder";
            var destDir = @"E:\Server\Ahzyzyw\resource";

            var srcImages = new DirectoryInfo(minDir).GetFiles("*.jpg", SearchOption.AllDirectories);
            var destImages = new DirectoryInfo(destDir).GetFiles("*.jpg", SearchOption.AllDirectories);
            foreach (var srcImage in srcImages)
            {
                var dstImage = GetSameNamePath(destImages, srcImage.Name);
                if (!string.IsNullOrEmpty(dstImage))
                {
                    try
                    {
                        File.Copy(srcImage.FullName, dstImage, true);
                    }
                    catch (Exception ex)
                    {
                        
                    }
                }
            }
        }

        private static string GetSameNamePath(FileInfo[] destImages, string srcImageName)
        {
            foreach (var dstImage in destImages)
            {
                if (dstImage.Name.Equals(srcImageName))
                {
                    return dstImage.FullName;
                }
            }

            return null;
        }
    }
}
