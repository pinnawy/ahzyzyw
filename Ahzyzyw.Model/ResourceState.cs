using System;

namespace Ahzyzyw.Model
{
    /// <summary>
    /// 药用资源状态
    /// </summary>
    [Flags]
    public enum ResourceState
    {
        /// <summary>
        /// 无状态
        /// </summary>
        None = 0x00,

        /// <summary>
        /// 推荐资源
        /// </summary>
        Recommend = 0x01,

        /// <summary>
        /// 属于药苑资源
        /// </summary>
        InGarden = 0x02
    }
}
