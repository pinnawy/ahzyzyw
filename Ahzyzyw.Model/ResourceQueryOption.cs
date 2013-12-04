namespace Ahzyzyw.Model
{
    /// <summary>
    /// 资源查询参数
    /// </summary>
    public class ResourceQueryOption : QueryOptionBase
    {
        public ResourceQueryOption()
        {
            QueryKeyWord = string.Empty;
            CategroyID = string.Empty;
            State = ResourceState.None;
        }

        /// <summary>
        /// 查询关键字
        /// </summary>
        public string QueryKeyWord { get; set; }

        /// <summary>
        /// 分类编号
        /// </summary>
        public string CategroyID { get; set; }

        /// <summary>
        /// 资源状态
        /// </summary>
        public ResourceState State { get; set; }
    }
}
