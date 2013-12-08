<%@ Page Title="新闻中心" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="news.aspx.cs" Inherits="Ahzyzyw.Web.news" %>

<asp:Content ID="NewsHeader" ContentPlaceHolderID="HeaderPlaceHolder" runat="server">
    <script src="scripts/plugin/jquery.pager.js" type="text/javascript"></script>
    <script src="scripts/plugin/jquery.json-2.2.min.js" type="text/javascript"></script>
    <script src="scripts/common.js" type="text/javascript"></script>
    <script src="scripts/news.js" type="text/javascript"></script>
    <link href="css/Pager.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        #itemDetail {
            display: none;
            width: 600px;
        }

        #itemContent li h3 {
            text-align: center;
        }

        #itemContent li div.img {
            text-align: center;
        }

        #itemContent li p span {
            font-weight: bold;
        }
    </style>
</asp:Content>

<asp:Content ID="NewsContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="clearfix">
        <div class="page-right" style="min-height: 400px;">
            <div class="site-nav"><span>当前位置 : </span><a href="index.aspx">首页</a> &gt;&gt; <a href="news.aspx" title="新闻中心">新闻中心</a></div>
            <div class="page-news">
                <div style="height: 400px;">
                    <table border="0" align="center">
                        <tr>
                            <th class="news-time">日期</th>
                            <th class="news-title">新闻标题</th>
                        </tr>
                    </table>
                    <table id="news_items" border="0" align="center">
                    </table>
                </div>
                <div id="pager" style="float: right; padding-right: 10px;"></div>
            </div>
        </div>
        <div class="page-left">
            <div class="left-search">
                <h2>
                    <span>新闻搜索</span></h2>
                <p>
                    <span>按新闻标题搜索：</span>
                </p>
                <p>
                    <input name="searchtext" type="text" id="query" />
                </p>
                <p>
                    <input name="searchbutton" id="searchbutton" />
                </p>
            </div>
            <div class="left-contact">
                <h2><span>联系我们</span></h2>
                <p><span>地址: </span>安徽省芜湖市乌霞山西路18号</p>
                <p><span>邮编: </span>241002</p>
                <p><span>联系人: </span>汪先生</p>
                <p><span>QQ: </span>59858705</p>
                <p><span>邮箱: </span>59858705@qq.com</p>
            </div>
        </div>
    </div>

</asp:Content>
