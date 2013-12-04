namespace Ahzyzyw.Model
{
    /// <summary>
    /// 查询参数
    /// </summary>
    public class QueryOptionBase
    {
        public QueryOptionBase()
        {
            PageNumber = 1;
            PageSize = 10;
            SortName = string.Empty;
            SortDir = SortDir.DESC;
        }

        /// <summary>
        /// 页码
        /// </summary>
        public int PageNumber
        {
            get; 
            set; 
        }

        /// <summary>
        /// 每页显示记录数
        /// </summary>
        public int PageSize
        {
            get; 
            set;
        }

        /// <summary>
        /// 排序方向
        /// </summary>
        public SortDir SortDir
        {
            get;
            set; 
        }

        /// <summary>
        /// 排序字段
        /// </summary>
        public string SortName
        {
            get;
            set;
        }
    }

    /// <summary>
    /// 排序方向
    /// </summary>
    public enum SortDir
    {
        /// <summary>
        /// 升序
        /// </summary>
        ASC,

        /// <summary>
        /// 降序
        /// </summary>
        DESC
    }
}
