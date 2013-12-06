<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="ahres.aspx.cs" Inherits="Ahzyzyw.Web.AhRes" %>
<asp:Content ContentPlaceHolderID="HeaderPlaceHolder" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
<div class="clearfix">
        <div class="page-left" >
            <div  class="left-garden">
                <h2><span>安徽药用资源概况</span></h2>
                <div class="ddsmoothmenu-v">
                    <ul id="menu">
                        <li><a class="selected" href="#top">安徽药用资源概况</a></li>
                    </ul>
                </div>
            </div>
            <div class="left-search">
                <h2>
                    <span>站内搜索</span></h2>
                <form method="post" id="sitesearch" name="sitesearch" action="">
                <p>
                    <select name="searchid" id="searchid">
                        <option value="2">产品展示</option>
                        <option value="3">新闻中心</option>
                        <option value="4">招聘信息</option>
                    </select>
                </p>
                <p>
                    <input name="searchtext" type="text" id="searchtext" />
                    <input name="searchsubmit" type="hidden" value="1" />
                </p>
                <p>
                    <input name="searchbutton" type="submit" id="searchbutton" value="" />
                </p>
                </form>
            </div>
        </div>

        <div class="page-right">
            <div class="site-nav"><span>当前位置 : </span><a href="index.aspx">首页</a> &gt;&gt; <a href="ahres.aspx">安徽药用资源概况</a></div>
            <div class="page-single">
            <div style="width:460px; float: left; text-align:center;">
                <fieldset style="border-color:#666666;border-width:1px;border-style:Solid; margin:20px 0px 0px 0px;">
                    <legend style="color:#333333;font-size:1.8em;font-weight:bold;">
                        安徽药用资源概况
                    </legend>
                    <img alt="药苑资源分布图" title="药苑资源分布图" src="images/ah.png" usemap="#map" />
                    <map name="map" id="map">
                        <area  alt="A1" shape="poly" href="#A1" title="A1" coords="154,351,192,351,205,380,140,380">
                    </map>
                </fieldset>
            </div>
            <div style="width: 300px;float:right;">
                安徽省药用资源概况
            </div>
            </div>
        </div>
    </div>
</asp:Content>
