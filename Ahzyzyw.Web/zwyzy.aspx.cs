﻿using System;

namespace Ahzyzyw.Web
{
    public partial class Zwyzy : System.Web.UI.Page
    {
        protected string ResID { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ResID = Request.Params["resId"];
        }
    }
}