using System;
using System.Collections.Generic;
using Ahzyzyw.Model;

namespace Ahzyzyw.DAL.Interface
{
    public interface IResourceDAL
    {
        /// <summary>
        /// 获取资源列表
        /// </summary>
        /// <param name="option">资源查询参数</param>
        /// <param name="recordCount">资源总数</param>
        /// <returns>资源列表</returns>
        List<Resource> GetResourceList(ResourceQueryOption option, out int recordCount);

        /// <summary>
        /// 获取资源详细信息
        /// </summary>
        /// <param name="resID">资源ID</param>
        /// <returns>对应资源信息</returns>
        Resource GetResource(string resID);

        /// <summary>
        /// 按资源名称获取资源列表
        /// </summary>
        /// <param name="resCnName">资源中文名称</param>
        /// <returns>资源列表</returns>
        List<Resource> GetResourceByName(string resCnName); 

        /// <summary>
        /// 添加资源
        /// </summary>
        /// <param name="resource">资源实体对象</param>
        /// <returns>新增资源ID</returns>
        string AddResource(Resource resource);

        /// <summary>
        /// 更新资源
        /// </summary>
        /// <param name="resource">资源实体对象</param>
        /// <returns></returns>
        bool UpdateResource(Resource resource);

        /// <summary>
        /// 删除资源
        /// </summary>
        /// <param name="resID">资源ID</param>
        /// <returns>删除资源结果</returns>
        bool DeleteResource(Guid resID);

        /// <summary>
        /// 编辑资源
        /// </summary>
        /// <param name="resId">资源ID</param>
        /// <param name="imageName">图片名称</param>
        /// <returns>编辑结果</returns>
        bool EditResource(string resId, string imageName);

        /// <summary>
        /// 获取资源分类子类别
        /// </summary>
        /// <param name="cateID">分类ID（1级分类穿空即可）</param>
        /// <returns>对应分类的子类别</returns>
        List<ResourceCategroy> GetSubCategorys(string cateID);

        /// <summary>
        /// 创建资源分类
        /// </summary>
        /// <param name="cate">资源分类对象</param>
        /// <param name="parentCateID">父类别ID</param>
        /// <returns>新建资源分类ID</returns>
        string CreateCategory(ResourceCategroy cate, string parentCateID);

        /// <summary>
        /// 删除资源分类
        /// </summary>
        /// <param name="cateID">资源分类ID</param>
        /// <returns>删除结果</returns>
        bool DeleteCategory(string cateID);
    }
}
