using System;
using System.Collections.Generic;
using Ahzyzyw.BLL.Interface;
using Ahzyzyw.DAL.Interface;
using Ahzyzyw.Model;
using ElpSimWan.Utils;
using Library;

namespace Ahzyzyw.BLL
{
    public class NewsBLL : INewsBLL
    {
        private readonly INewsDAL _newsDAL = UnityContext.LoadDalModel<INewsDAL>();

        public string AddNews(News news)
        {
            try
            {
                news.NewsId = Guid.NewGuid().ToString();
                return _newsDAL.AddNews(news);
            }
            catch (Exception ex)
            {
                LogUtil.Log.Error("NewsBLL::AddNews exception", ex);
                return string.Empty;
            }
        }

        public News GetNews(string newsId)
        {
            return _newsDAL.GetNews(newsId);
        }

        public bool DeleteNews(int newsId)
        {
            throw new NotImplementedException();
        }

        public List<News> GetNewsList(NewsQueryOption option, out int recordCount)
        {
            return _newsDAL.GetNewsList(option, out recordCount);
        }
    }
}
