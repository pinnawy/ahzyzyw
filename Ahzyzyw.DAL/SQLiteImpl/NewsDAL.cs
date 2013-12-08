using System;
using System.Collections.Generic;
using System.Diagnostics;
using Ahzyzyw.DAL.Interface;
using Ahzyzyw.Model;
using Everest.Library.ExtensionMethod;

namespace Ahzyzyw.DAL.SQLiteImpl
{
    public class NewsDAL : DALBase, INewsDAL
    {
        private const string TABLE_NAME = "News";

        public string AddNews(News news)
        {
            news.CreateTime = DateTime.Now;

            var sql = string.Format(@"INSERT INTO {0} (ID, PublishTime, CreateTime, Title, Content)
                                      VALUES('{1}',{2},{3},'{4}','{5}')"
                                     , TABLE_NAME, news.NewsId, news.PublishTime.ToString("yyyy-MM-dd HH:mm:ss"),  news.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"), news.Title, news.Content);
            Debug.WriteLine(sql);

            int rows = SQLiteHelper.ExecuteNonQuery(sql);

            return rows == 1 ? news.NewsId : string.Empty;
        }

        public News GetNews(string newsId)
        {
            var sql = string.Format("SELECT * FROM {0} WHERE UPPER(HEX([ID]))='{1}'", TABLE_NAME, ConvertGuid(newsId));
            Debug.WriteLine(sql);
            var reader = SQLiteHelper.ExecuteReader(sql);
            return reader.ToNews();
        }

        public bool DeleteNews(int newsId)
        {
            throw new NotImplementedException();
        }

        public List<News> GetNewsList(NewsQueryOption option, out int recordCount)
        {
            var sql = string.Format("SELECT [Title],[ID],[PublishTime],[CreateTime] FROM {0}", TABLE_NAME);

            if (!option.SortName.IsIgnoreQueryCondition())
            {
                sql = string.Format("{0} ORDER BY [{1}] {2}", sql, option.SortName, option.SortDir);
            }
            else
            {
                sql = string.Format("{0} ORDER BY [PublishTime] DESC", sql);
            }

            Debug.WriteLine(sql);
            var reader = SQLiteHelper.ExecuteReaderPager(out recordCount, option.PageNumber, option.PageSize, sql);
            return reader.ToNewsList();
        }
    }
}
