<%@ Page Title="芜湖药用植物资源" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="medicine.aspx.cs" Inherits="Ahzyzyw.Web.Medicine" %>

<asp:Content ID="MedicineHeader" ContentPlaceHolderID="HeaderPlaceHolder" runat="server">
    <script src="scripts/plugin/jquery.pager.js" type="text/javascript"></script>
    <script src="scripts/plugin/jquery.json-2.2.min.js" type="text/javascript"></script>
    <script src="scripts/common.js" type="text/javascript"></script>
    <script src="scripts/Medicine.js" type="text/javascript"></script>
    <link href="css/Pager.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        #itemDetail {display:none; width:600px;}
        #itemContent li h3{text-align:center;}
        #itemContent li div.img {text-align:center;}
        #itemContent li p span{font-weight:bold;}
    </style>
</asp:Content>

<asp:Content ID="MedicineContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="clearfix">
        <div class="page-left" >
            <div  class="left-medicine">
                <h2><span>中药材分类</span></h2>
                <div class="ddsmoothmenu-v">
                    <ul id="menu">
                        <li><a class='selected' href="javascript:void(0);" cateID=''>全部</a></li>
                        <li><a href="javascript:void(0);" cateID='01'>药用蕨类植物</a></li>
                        <li><a href="javascript:void(0);" cateID='02'>药用裸子植物</a></li>
                        <li><a href="javascript:void(0);" cateID='03'>药用被子植物</a>
                            <ul>
                                <li><a href="javascript:void(0);" cateID='0301'>单子叶植物</a></li>
                                <li><a href="javascript:void(0);" cateID='0302'>双子叶植物</a></li>
                            </ul>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="res-search">
                <h2>
                    <span>资源搜索</span></h2>
                <p>
                    <span>按资源名称搜索：</span>
                </p>
                <p>
                    <input name="searchtext" type="text" id="query" />
                </p>
                <p>
                    <input name="searchbutton" id="searchbutton"/>
                </p>
            </div>
        </div>

        <div class="page-right">
            <div class="site-nav"><span>当前位置 : </span><a href="index.aspx">首页</a> &gt;&gt; <a href="Medicine.aspx">芜湖药用植物资源</a></div>
            <div id="medicine_items">
                 <ul class="clearfix" id="resItems">

                </ul>
            </div>
            <div id="pager" style="float:right;padding-right:10px;"></div>
        </div>
    </div>

     <div id="itemDetail">
        <div style="text-align:right;"><a style="font-size:16;padding-right:10px;" onclick="$.unblockUI()">X</a></div>
        <div id="itemContent"  style="text-align:left;padding:3px;">
        </div>
        <div style="padding-top: 5px;">
            <a onclick="$.unblockUI()">关闭</a>
        </div>
     </div>
</asp:Content>
