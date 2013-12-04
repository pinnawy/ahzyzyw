using System;

namespace Ahzyzyw.Model
{
    /// <summary>
    /// 药品实体类
    /// </summary>
    [Serializable]
    public class Resource
    {
        /// <summary>
        /// 资源ID
        /// </summary>
        public string ResID
        {
            get;
            set;
        }

        /// <summary>
        /// 中文名称
        /// </summary>
        public string CnName
        {
            get;
            set;
        }

        /// <summary>
        /// 英文名称
        /// </summary>
        public string EnName
        {
            get;
            set;
        }

        /// <summary>
        /// 别名
        /// </summary>
        public string OtherName
        {
            get;
            set;
        }

        /// <summary>
        /// 资源分类编号
        /// </summary>
        public string CategroyID
        {
            get;
            set;
        }

        /// <summary>
        /// 科
        /// </summary>
        public string Family
        {
            get;
            set;
        }

        /// <summary>
        /// 属
        /// </summary>
        public string Genus
        {
            get;
            set;
        }

        /// <summary>
        /// 资源描述
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// 资源状态
        /// </summary>
        public ResourceState State
        {
            get;
            set;
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime
        {
            get;
            set;
        }

        /// <summary>
        /// 资源创建人
        /// </summary>
        public string Creator
        {
            get;
            set;
        }

        /// <summary>
        /// 资源位置
        /// </summary>
        public string Location
        {
            get;
            set;
        }

        /// <summary>
        /// 资源图片
        /// </summary>
        public string Image
        {
            get;
            set;
        }
    }
}
