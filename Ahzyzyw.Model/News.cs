using System;

namespace Ahzyzyw.Model
{
    /// <summary>
    /// 新闻实体类
    /// </summary>
    [Serializable]
    public class News
    {
        /// <summary>
        /// 新闻ID
        /// </summary>
        public string NewsId { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime PublishTime { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 新闻内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 文章地址
        /// </summary>
        public string PaperUrl { get; set; }
    }
}
