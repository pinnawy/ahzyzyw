using System;
using System.Collections.Generic;
using System.Web.UI;
using Ahzyzyw.BLL.Interface;
using Ahzyzyw.Model;
using Library;

namespace Ahzyzyw.Web
{
    public partial class Index : Page
    {
        private INewsBLL _newsBll = UnityContext.LoadBllModel<INewsBLL>();

        protected List<News> NewsList { get; set; }

        protected News FirstNews { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            int recordCount;
            var newsList = _newsBll.GetNewsList(new NewsQueryOption { PageNumber = 1, PageSize = 4, SortName = "PublishTime" }, out recordCount);

            if (newsList.Count > 0)
            {
                FirstNews = _newsBll.GetNews(newsList[0].NewsId);
            }

            if (newsList.Count > 1)
            {
                NewsList = newsList.GetRange(1, newsList.Count -1);
            }
        }
    }
}