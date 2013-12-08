using System;
using Ahzyzyw.BLL.Interface;
using Ahzyzyw.Model;
using Library;

namespace Ahzyzyw.Web
{
    public partial class newsdetail : System.Web.UI.Page
    {
        protected News CurrentNews { get; set; }

        private INewsBLL _newsBll = UnityContext.LoadBllModel<INewsBLL>();

        protected void Page_Load(object sender, EventArgs e)
        {
            string newsid = Request.Params["newsId"];
            
            CurrentNews = _newsBll.GetNews(newsid);

            if (CurrentNews.Content != null)
            {
                CurrentNews.Content = CurrentNews.Content.Replace("\n", "</br>");
            }
        }
    }
}