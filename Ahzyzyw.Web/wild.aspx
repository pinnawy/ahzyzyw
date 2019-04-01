<%@ Page Title="中药数字标本馆" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="wild.aspx.cs" Inherits="Ahzyzyw.Web.DigitalSpecimen" %>

<asp:Content ID="DigitalSpecimenHeader" ContentPlaceHolderID="HeaderPlaceHolder" runat="server">
    <script src="scripts/plugin/jquery.pager.js" type="text/javascript"></script>
    <script src="scripts/plugin/jquery.json-2.2.min.js" type="text/javascript"></script>
    <script src="scripts/common.js" type="text/javascript"></script>
    
    <link href="css/Pager.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        #itemDetail {display:none; width: 700px; }
        #itemContent {overflow-y: scroll;}
        #itemContent div.img { margin-top: 10px;}
        #itemContent div.img a{display:inline-block; margin-top:5px; padding:5px;  background: white; border:  1px solid #e5e5e5;}
        #itemContent div.img a span{ color: black; font-size: 14px; cursor: default;}
        
        #itemContent li h3{text-align:center;}
        #itemContent li p span{font-weight:bold;}

        #tabMenu {
            display: block;
            height:35px;
            margin-left:15px;
        }

        #tabMenu li a {
            display: block;
            float: left;
            margin: 2px;
            font-weight: bold;
            padding: 4px 15px 4px 3px;
            cursor: pointer;
        }

        #tabMenu li a:visited{color:#FFF}
        #tabMenu li a:hover{color:#FFF; background:url(../images/leftmenu-hover.gif) no-repeat right top;}
        #tabMenu li a.selected{color:#FFF; background:url(../images/leftmenu.gif) no-repeat right top;}
    </style>
    
   
</asp:Content>

<asp:Content ID="DigitalSpecimenContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="clearfix">
        <div class="page-left" style="width:185px;" >
            <div  class="left-medicine">
                <h2 style="background:url(images/left-wild.png) no-repeat"><span>野外采药路径</span></h2>          
              
                <div id="funcMenuPanel" class="ddsmoothmenu-v">
                    <ul id="funcMenu">
                       
                        <li><a href="javascript:void(0);" data="trace1/trace1.json">丫山采药</a>
                            <ul>
                                <li><a href="javascript:void(0);" data="trace1/trace1.json">路径1</a></li>
                                <li><a href="javascript:void(0);" data="dasd2.json">路径2</a></li>
                                <li><a href="javascript:void(0);" data="dasd3.json">路径3</a></li>
                            </ul>
                        </li>
                        <li><a href="javascript:void(0);" data="dasd3.json">繁昌采药</a>
                            <ul>
                                <li><a href="javascript:void(0);" data="dasd3.json">路径1</a></li>
                            </ul>
                        </li>
                        
                    </ul>
                </div>

                
            </div>
           
        </div>

        <div class="page-right" style="width:815px;">
            <div class="site-nav"><span>当前位置 : </span><a href="index.aspx">首页</a> &gt;&gt; <a href="wild.aspx">野外采药</a></div>
            <div id="medicine_items" style="width:800px; height:1000px;">
                 <ul class="clearfix" id="map" style="height:100%;">

                </ul>
            </div>
        </div>
    </div>

     <div id="itemDetail">
        <div style="text-align:right;cursor: default;"><a style="font-size:16px;padding-right:10px;" onclick="$.unblockUI()">X</a></div>
        <div id="itemContent"  style="text-align:left;padding:3px;">
        </div>
        <div style="padding-top: 5px;">
            <a style="cursor:default;" onclick="$.unblockUI()">关闭</a>
        </div>
     </div>

     <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=E3970eb85deba960bb2ac127ddcd38a3"></script>
     <script src="scripts/wild.js" type="text/javascript"></script>
</asp:Content>
