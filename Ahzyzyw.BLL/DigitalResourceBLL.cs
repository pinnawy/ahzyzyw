using System;
using System.Drawing;
using System.Collections.Generic;
using System.IO;
using System.Threading;

using Ahzyzyw.BLL.Interface;
using Ahzyzyw.Common;
using Ahzyzyw.DAL.Interface;
using Ahzyzyw.Model;
using Library;
using Utils;
using ElpSimWan.Utils;

namespace Ahzyzyw.BLL
{
    public class DigitalResourceBLL : IDigitalResourceBLL
    {
        private readonly IDigitalResourceDAL _resourceDAL = UnityContext.LoadDalModel<IDigitalResourceDAL>();

        public List<DigitalResource> GetDigitalResourceList(DigitalResourceQueryOption option, out int recordCount)
        {
            var resList = _resourceDAL.GetDigitalResourceList(option, out recordCount);
            foreach (var resource in resList)
            {
                AddResourceImage(resource);
            }
            return resList;
        }


        //public Resource GetResource(string resID)
        //{
        //    var res =_resourceDAL.GetResource(resID);
        //    AddResourceImage(res);
        //    return res;
        //}

      

        public string SaveTempImage(byte[] imageBytes, string ext)
        {
            try
            {
                string imagePath = Path.Combine(CurrentContext.Instance.TempDir, Guid.NewGuid().ToString() + ext);
                Image image = Image.FromStream(new MemoryStream(imageBytes));
                image.Save(imagePath);
                return imagePath;
            }
            catch (Exception ex)
            {
                LogUtil.Log.Error("RecourceBLL::SaveTempImage, Exception:", ex);
                return string.Empty;
            }
        }

        //public bool UpdateResourceImage(string resID, byte[] imageBytes, string ext)
        //{
        //    string imageName = Guid.NewGuid().ToString() + ".jpg";
        //    //string imagePath = GetResImagePath(new Guid(resID), imageName);

        //    string imagePath = Path.Combine("GenImage",resID, imageName);

        //    string iamgeDir = Path.GetDirectoryName(imagePath);
        //    if (iamgeDir != null && !Directory.Exists(iamgeDir))
        //    {
        //        Directory.CreateDirectory(iamgeDir);
        //    }

        //    using (Image tempImage = ImageHelper.GenerateThumbnail(imageBytes, 300, 215, ThumbnailMode.WH))
        //    {
        //        tempImage.Save(imagePath);
        //    }

           
        //}

        private static void AddResourceImage(DigitalResource resource)
        {
            if (resource == null)
            {
                return;
            }

            string imagePath = GetResImagePath("medicien", resource.Image);

            // 药材图
            if (File.Exists(imagePath))
            {
                resource.Image = UrlConverter.GetHttpUrl(imagePath);
            }
            else
            {
                resource.Image = string.Format(string.Format("images/{0}", CurrentContext.Instance.DefaultResImageName));
            }

            // 植物原图
            for (int index = 0; index < resource.PlantImageList.Count; index++)
            {
                var plantImage = resource.PlantImageList[index];
                imagePath = GetResImagePath("plant", plantImage);
                if (File.Exists(imagePath))
                {
                    resource.PlantImageList[index] = UrlConverter.GetHttpUrl(imagePath);
                }
            }


            // 伪品图
            for (int index=0; index<resource.FakePicList.Count; index++)
            {
                var fakeImage = resource.FakePicList[index];
                imagePath = GetResImagePath("fake", fakeImage);
                if (File.Exists(imagePath))
                {
                    resource.FakePicList[index] = UrlConverter.GetHttpUrl(imagePath);
                }
            }
            
        }

        private static string GetResImagePath(string prefix, string imageName)
        {
            return Path.Combine(CurrentContext.Instance.ResourceDir, "digital", prefix, imageName);
        }

        
    }
}
