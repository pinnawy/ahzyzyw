using System;
using Ahzyzyw.Common;

namespace Ahzyzyw.Web
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        /// <summary>
        /// 网站URL根目录
        /// </summary>
        public string WebRoot
        {
            get { return CurrentContext.Instance.WebUrlRoot; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}
