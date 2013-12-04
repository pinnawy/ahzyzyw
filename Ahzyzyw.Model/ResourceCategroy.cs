using System;
using System.Collections.Generic;

namespace Ahzyzyw.Model
{
    /// <summary>
    /// 资源分类
    /// </summary>
    public class ResourceCategroy
    {
        public ResourceCategroy()
        {
            SubCategorys = new List<ResourceCategroy>();
        }

        /// <summary>
        /// 资源分类编号
        /// 编号规则详见数据库设计文档
        /// </summary>
        public string CategroyID { get; set; }

        /// <summary>
        /// 中文名称
        /// </summary>
        public string CnTitle { get; set; }

        /// <summary>
        /// 英文名称
        /// </summary>
        public string EnTitle { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 子分类
        /// </summary>
        public List<ResourceCategroy> SubCategorys { get; set; }

        /// <summary>
        /// 是否有子分类
        /// </summary>
        public bool HasSubCategory { get; set; }
    }
}
