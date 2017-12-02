namespace Ahzyzyw.Model
{
    /// <summary>
    /// 数字资源查询参数
    /// </summary>
    public class DigitalResourceQueryOption : ResourceQueryOption
    {
        /// <summary>
        /// 功能分类ID
        /// </summary>
        public string FuncID { get; set; }

        /// <summary>
        /// 入药部位ID
        /// </summary>
        public string PartID { get; set; }
    }
}
