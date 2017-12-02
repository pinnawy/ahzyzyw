using System;
using System.Collections.Generic;
using Ahzyzyw.Model;

namespace Ahzyzyw.BLL.Interface
{
    public interface IDigitalResourceBLL
    {
        /// <summary>
        /// 获取数字资源列表
        /// </summary>
        /// <param name="option">资源查询参数</param>
        /// <param name="recordCount">资源总数</param>
        /// <returns>数字资源列表</returns>
        List<DigitalResource> GetDigitalResourceList(DigitalResourceQueryOption option, out int recordCount);
    }
}
