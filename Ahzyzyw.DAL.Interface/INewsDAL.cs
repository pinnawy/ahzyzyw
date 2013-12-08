using Ahzyzyw.Model;
using System.Collections.Generic;

namespace Ahzyzyw.DAL.Interface
{
    public interface INewsDAL
    {
        /// <summary>
        /// 添加新闻
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        string AddNews(News news);

        /// <summary>
        /// 获取新闻
        /// </summary>
        /// <param name="newsId"></param>
        /// <returns></returns>
        News GetNews(string newsId);

        /// <summary>
        /// 删除新闻
        /// </summary>
        /// <param name="newsId"></param>
        /// <returns></returns>
        bool DeleteNews(int newsId);

        /// <summary>
        /// 获取新闻列表
        /// </summary>
        /// <param name="option"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        List<News> GetNewsList(NewsQueryOption option, out int recordCount);
    }
}
