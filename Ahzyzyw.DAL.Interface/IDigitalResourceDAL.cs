using System;
using System.Collections.Generic;
using Ahzyzyw.Model;

namespace Ahzyzyw.DAL.Interface
{
    public interface IDigitalResourceDAL
    {
        /// <summary>
        /// 获取数字资源列表
        /// </summary>
        /// <param name="option">资源查询参数</param>
        /// <param name="recordCount">资源总数</param>
        /// <returns>数字资源列表</returns>
        List<DigitalResource> GetDigitalResourceList(DigitalResourceQueryOption option, out int recordCount);

        /// <summary>
        /// 获取资源详细信息
        /// </summary>
        /// <param name="resID">资源ID</param>
        /// <returns>对应资源信息</returns>
        DigitalResource GetDigitalResource(string resID);


        /// <summary>
        /// 添加数字资源
        /// </summary>
        /// <param name="resource">数字资源实体对象</param>
        /// <returns>新增资源ID</returns>
        string AddDigitalResource(DigitalResource resource);
    }
}
