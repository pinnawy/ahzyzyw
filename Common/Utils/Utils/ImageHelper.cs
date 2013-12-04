using System;
using System.Drawing;
using System.IO;

namespace Utils
{
    public class ImageHelper
    {
        ///<summary> 
        /// 生成缩略图 
        /// </summary> 
        /// <param name="srcImageBytes">源图字节数组</param> 
        /// <param name="width">缩略图宽度</param> 
        /// <param name="height">缩略图高度</param> 
        /// <param name="mode">生成缩略图的方式</param>     
        public static Image GenerateThumbnail(byte[] srcImageBytes, int width, int height, ThumbnailMode mode)
        {
            using (Stream srcImageStream = new MemoryStream(srcImageBytes))
            {
                Image originalImage = Image.FromStream(srcImageStream);
                return GenerateImage(width, height, mode, originalImage);
            }
        }

        ///<summary> 
        /// 生成缩略图 
        /// </summary> 
        /// <param name="srcImagePath">源图路径</param> 
        /// <param name="width">缩略图宽度</param> 
        /// <param name="height">缩略图高度</param> 
        /// <param name="mode">生成缩略图的方式</param>     
        public static Image GenerateThumbnail(string srcImagePath, int width, int height, ThumbnailMode mode)
        {
            Image originalImage = Image.FromFile(srcImagePath);

            return GenerateImage(width, height, mode, originalImage);
        }

        /// <summary>
        /// 生成图片
        /// </summary>
        /// <param name="width">图片宽度</param>
        /// <param name="height">图片高度</param>
        /// <param name="mode">生成模式</param>
        /// <param name="originalImage">原始图片</param>
        /// <returns>生成后的图片</returns>
        private static Image GenerateImage(int width, int height, ThumbnailMode mode, Image originalImage)
        {
            int toWidth = width;
            int toHeight = height;

            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;

            switch (mode)
            {
                case ThumbnailMode.WH:
                    break;
                case ThumbnailMode.W:
                    toHeight = originalImage.Height * width / originalImage.Width;
                    break;
                case ThumbnailMode.H:
                    toWidth = originalImage.Width * height / originalImage.Height;
                    break;
                case ThumbnailMode.Cut:
                    if (originalImage.Width / (double)originalImage.Height > toWidth / (double)toHeight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * toWidth / toHeight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / toWidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }

            //新建一个bmp图片 
            Image thumbnail = new Bitmap(toWidth, toHeight);

            //新建一个画板 
            Graphics g = Graphics.FromImage(thumbnail);

            //设置高质量插值法 
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;

            //设置高质量,低速度呈现平滑程度 
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;

            //清空画布并以透明背景色填充 
            g.Clear(Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分 
            g.DrawImage(originalImage, new Rectangle(0, 0, toWidth, toHeight), new Rectangle(x, y, ow, oh), GraphicsUnit.Pixel);
            try
            {
                return thumbnail;

                //以jpg格式保存缩略图 
                //bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                originalImage.Dispose();
                // thumbnail.Dispose();
                g.Dispose();
            }
        }
    }

    /// <summary>
    /// 缩略图模式
    /// </summary>
    public enum ThumbnailMode : byte
    {
        /// <summary>
        /// 指定高宽缩放（可能变形)
        /// </summary>
        WH,

        /// <summary>
        /// 指定宽，高按比例  
        /// </summary>
        W,

        /// <summary>
        /// 指定高，宽按比例 
        /// </summary>
        H,

        /// <summary>
        /// 指定高宽裁减（不变形）
        /// </summary>
        Cut
    }
}
