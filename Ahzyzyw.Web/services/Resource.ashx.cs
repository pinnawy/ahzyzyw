using System;
using System.Web;
using Ahzyzyw.BLL.Interface;
using ElpSimWan.Json;
using ElpSimWan.Utils;
using Library;
using System.IO;
using System.Drawing;
using Utils;

namespace Ahzyzyw.Web.Services
{
    /// <summary>
    /// Summary description for Resource
    /// </summary>
    public class Resource : IHttpHandler
    {
        private readonly IResourceBLL _resourceBLL = UnityContext.LoadBllModel<IResourceBLL>();
        private static readonly string POSTED_RES_IMAGE = "resImage"; //焦点资源上传时fileinput的name

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            try
            {
                if (context.Request.Files[POSTED_RES_IMAGE] != null)
                {
                    context.Response.Write(UploadResourceImage(context, POSTED_RES_IMAGE));
                }
                else
                {
                    var result = HttpProcessor.Process(_resourceBLL, context);
                    if (result is string)
                    {
                        context.Response.Write(result.ToString());
                    }
                    else
                    {
                        context.Response.Write(result.ToJSON());
                    }
                }
            }
            catch (Exception ex)
            {
                LogUtil.Log.Error("Resource Handler Exception:", ex);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private string UploadResourceImage(HttpContext context, string resImageKey)
        {
            HttpPostedFile postedImage = context.Request.Files[resImageKey];
            int imageContentLength = postedImage.ContentLength;

            //图片文件过大
            if (imageContentLength > 2 * 1024 * 1024)
                return "{success:false, msg:'图片不能大于2M' }";

            byte[] imageByteArr = new BinaryReader(postedImage.InputStream).ReadBytes(imageContentLength);
            try
            {
                Image.FromStream(new MemoryStream(imageByteArr));
            }
            catch
            {
                //图片文件错误
                return "{success:false, msg:'图片错误，请重新选择图片' }";
            }

            //图片尺寸不符合要求
            //if (image.Width > 500 || image.Height > 500)
            //    return "{success:false, msg:'焦点图片不能大于' }";

            string resIdStr = context.Request.Form["ResID"];
            string extension = Path.GetExtension(postedImage.FileName);


            // 上传新资源图片
            if (string.IsNullOrWhiteSpace(resIdStr))
            {
                string imagePath = _resourceBLL.SaveTempImage(imageByteArr, extension);
                if (!string.IsNullOrEmpty(imagePath))
                {
                    string imageUrl = UrlConverter.GetHttpUrl(imagePath);
                    return "{success:true, msg:'资源图片上传成功', image:'" + imageUrl + "' }";
                }

                return "{success:false, msg:'图片上传出错'}";
            }

            // 修改资源图片
            try
            {
                bool result = _resourceBLL.UpdateResourceImage(resIdStr, imageByteArr, extension);
                if (result)
                {
                    return "{success:true, msg:'资源图片修改成功' }";
                }

                return "{success:false, msg:'资源图片修改失败' }";
            }
            catch (Exception ex)
            {
                LogUtil.Log.Error("Resource::UploadResourceImage, Exception:", ex);
                return "{success:false, msg:'资源图片修改失败' }";
            }
        }
    }
}