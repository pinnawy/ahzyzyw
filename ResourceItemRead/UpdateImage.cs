using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ahzyzyw.BLL;
using ElpSimWan.Utils;

namespace ResourceItemRead
{
    class UpdateImage
    {
        public static void Update()
        {
            ResourceBLL bll = new ResourceBLL();

            DirectoryInfo imageDir = new DirectoryInfo(@"C:\Users\Taly\Desktop\MedicenImages");
            var images = imageDir.GetFiles("*.jpg");

            int itemCount = 0;
            int successCount = 0;
            foreach (var fileInfo in images)
            {
                var imageName = fileInfo.Name.Substring(0, fileInfo.Name.Length-4).Trim();
                var resList = bll.GetResourceByName(imageName);
                Console.WriteLine("正在保存第{0}个图片: {1}", ++itemCount, imageName);
                if (resList.Count == 1)
                {
                    try
                    {
                        var iamgeBytes = File.ReadAllBytes(fileInfo.FullName);
                        var  result = bll.UpdateResourceImage(resList[0].ResID, iamgeBytes, "jpg");
                        if (result)
                        {
                            Console.WriteLine("保存成功{0}个", ++successCount);
                        }
                        else
                        {
                            LogUtil.Log.Error("保存图片“" + imageName + "”失败");
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        LogUtil.Log.Error("保存图片“" + imageName + "”出错", ex);
                    }
                }
                else
                {
                    LogUtil.Log.WarnFormat("没有找到对应的资源:{0}",imageName);
                }
            }
        }
    }
}
