<%@ Page Title="新闻中心" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="newsdetail.aspx.cs" Inherits="Ahzyzyw.Web.newsdetail" %>

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
        <div class="page-right">
            <div class="site-nav"><span>当前位置 : </span><a href="index.aspx">首页</a> &gt;&gt; <a href="news.aspx" title="新闻中心">新闻中心</a></div>
            <div class="page-news" >
                <div style="border: 1px solid gray;">
                    <% if (CurrentNews == null)
                   { %>
                    <span>未找到相关新闻</span>
                <% }
                   else
                   {
                %>
                <div style="height: 37px;">
                    <div style="width: 37px; height: 37px; float: left; background: url('/images/neiye_left.png')">&nbsp;</div>
                    <div style="width: 37px; height: 37px; float: right; background: url('/images/neiye_right.png')">&nbsp;</div>
                </div>

                <div style="padding: 20px 20px 50px 10px;">
                    <h2 style="text-align: center"><%=CurrentNews.Title %></h2>
                    <div style="text-align: center;padding:15px 0px 30px 0px; ">发布时间：<%=CurrentNews.PublishTime.ToString("yyyy/MM/dd") %>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="javascript:window.print()" class="print">[ 打印本文 ]</a></div>
                    <div>
                        <%=CurrentNews.Content %>
                    </div>
                </div>


                <% } %>

                </div>
            </div>
        </div>
        <div class="page-left">
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
