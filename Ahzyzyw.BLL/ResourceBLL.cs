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
    public class ResourceBLL : IResourceBLL
    {
        private readonly IResourceDAL _resourceDAL = UnityContext.LoadDalModel<IResourceDAL>();

        public List<Resource> GetResourceList(ResourceQueryOption option, out int recordCount)
        {
            var resList = _resourceDAL.GetResourceList(option, out recordCount);
            foreach (var resource in resList)
            {
                AddResourceImage(resource);
            }
            return resList;
        }

        public List<Resource> GetRecommendResourceList()
        {
            ResourceQueryOption option = new ResourceQueryOption
            {
                State = ResourceState.Recommend
            };
            int recordCount;
            return GetResourceList(option, out recordCount);
        }

        public Resource GetResource(string resID)
        {
            var res =_resourceDAL.GetResource(resID);
            AddResourceImage(res);
            return res;
        }

        public List<Resource> GetResourceByName(string resCnName)
        {
            return _resourceDAL.GetResourceByName(resCnName);
        }

        public string AddResource(Resource resource)
        {
            resource.ResID = Guid.NewGuid().ToString();

            try
            {
                if (resource.Image.EndsWith(CurrentContext.Instance.DefaultResImageName))
                {
                    resource.Image = string.Empty;
                }

                // 将上传的图片处理后放到资源目录下
                else
                {
                    string tempImagePath = UrlConverter.GetPhysicalPathFromVirtualUrl(resource.Image);
                    string iamgeName = Path.GetFileName(tempImagePath);
                    string imagePath = GetResImagePath(new Guid(resource.ResID), iamgeName);

                    string iamgeDir = Path.GetDirectoryName(imagePath);
                    if (iamgeDir != null && !Directory.Exists(iamgeDir))
                    {
                        Directory.CreateDirectory(iamgeDir);
                    }

                    byte[] imageBytes = File.ReadAllBytes(tempImagePath);
                    using (Image tempImage = ImageHelper.GenerateThumbnail(imageBytes, 300, 215, ThumbnailMode.WH))
                    {
                        tempImage.Save(imagePath);
                    }

                    //// 删除临时目录
                    //new Thread(() =>
                    //{
                    //    try
                    //    {
                    //        File.Delete(tempImagePath);
                    //    }
                    //    catch
                    //    {
                    //        // Do Nothing
                    //    }
                    //}).Start();

                    resource.Image = iamgeName;
                }

                resource.Creator = "admin";
                // 向数据库中插入数据
                string resId = _resourceDAL.AddResource(resource);

                return resId;
            }
            catch (Exception ex)
            {
                LogUtil.Log.Error("RecourceBLL::AddResource, Exception:", ex);
                return string.Empty;
            }
        }

        public bool UpdateResource(Resource resource)
        {
            return _resourceDAL.UpdateResource(resource);
        }

        public bool DeleteResource(Guid resID, string imageName)
        {
            bool result = _resourceDAL.DeleteResource(resID);
            if (result && !imageName.EndsWith(CurrentContext.Instance.DefaultResImageName))
            {
                new Thread(() =>
                {
                    try
                    {
                        string imagePath = GetResImagePath(resID, Path.GetFileName(imageName));
                        string imageDir = Path.GetDirectoryName(imagePath);

                        if (imageDir != null)
                        {
                            Directory.Delete(imageDir, true);
                        }
                    }
                    catch
                    {
                        // DO Nothing
                    }
                }).Start();
            }
            return result;
        }

        public bool EditResource(Resource resource)
        {
            throw new NotImplementedException();
        }

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

        public bool UpdateResourceImage(string resID, byte[] imageBytes, string ext)
        {
            string imageName = Guid.NewGuid().ToString() + ".jpg";
            //string imagePath = GetResImagePath(new Guid(resID), imageName);

            string imagePath = Path.Combine("GenImage",resID, imageName);

            string iamgeDir = Path.GetDirectoryName(imagePath);
            if (iamgeDir != null && !Directory.Exists(iamgeDir))
            {
                Directory.CreateDirectory(iamgeDir);
            }

            using (Image tempImage = ImageHelper.GenerateThumbnail(imageBytes, 300, 215, ThumbnailMode.WH))
            {
                tempImage.Save(imagePath);
            }

            return _resourceDAL.EditResource(resID, imageName);
        }

        private static void AddResourceImage(Resource resource)
        {
            if (resource == null)
            {
                return;
            }

            string imagePath = GetResImagePath(new Guid(resource.ResID), resource.Image);

            if (File.Exists(imagePath))
            {
                resource.Image = UrlConverter.GetHttpUrl(imagePath);
            }
            else
            {
                resource.Image = string.Format(string.Format("images/{0}", CurrentContext.Instance.DefaultResImageName));
            }
        }

        private static string GetResImagePath(Guid resId, string imageName)
        {
            return Path.Combine(CurrentContext.Instance.ResourceDir, resId.ToString(), imageName);
        }

        #region ResourceCategroy

        public List<ResourceCategroy> GetSubCategorys(string cateID)
        {
            return _resourceDAL.GetSubCategorys(cateID);
        }

        public List<ResourceCategroy> GetAllCategorys()
        {
            throw new NotImplementedException();
        }

        public string CreateCategory(ResourceCategroy cate, string parentCateID)
        {
            return _resourceDAL.CreateCategory(cate, parentCateID);
        }

        public bool DeleteCategory(string cateID)
        {
            return _resourceDAL.DeleteCategory(cateID);
        }

        #endregion
    }
}
