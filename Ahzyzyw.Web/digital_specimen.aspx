<%@ Page Title="中药数字标本馆" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="digital_specimen.aspx.cs" Inherits="Ahzyzyw.Web.DigitalSpecimen" %>

<asp:Content ID="DigitalSpecimenHeader" ContentPlaceHolderID="HeaderPlaceHolder" runat="server">
    <script src="scripts/plugin/jquery.pager.js" type="text/javascript"></script>
    <script src="scripts/plugin/jquery.json-2.2.min.js" type="text/javascript"></script>
    <script src="scripts/common.js" type="text/javascript"></script>
    <script src="scripts/digital.js" type="text/javascript"></script>
    <link href="css/Pager.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        #itemDetail {display:none; width: 700px; }
        #itemContent {overflow-y: scroll;}
        
        #itemContent li h3{text-align:center;}
        #itemContent li div.img {text-align:center;}
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
    
    <script type="text/javascript">
        var resId = '<%=ResID%>';
    </script>
</asp:Content>

<asp:Content ID="DigitalSpecimenContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="clearfix">
        <div class="page-left" >
            <div  class="left-medicine">
                <h2><span>中药材分类</span></h2>

                <ul id="tabMenu">
                    <!--注意这里的for是下面panel的ID，必须要是func或是part开头，有很恶心的代码逻辑在js里面-->
                    <li><a for="funcMenuPanel" class="selected">按功效分类</a></li>
                    <li><a for="partMenuPanel">按入药部位分类</a></li>
                </ul>
                
              
                <div id="funcMenuPanel" class="ddsmoothmenu-v">
                    <ul id="funcMenu">
                        <li><a class='selected' href="javascript:void(0);" funcID=''>全部</a></li>
                        <li><a href="javascript:void(0);" funcID='01'>解表药</a>
                            <ul>
                                <li><a href="javascript:void(0);" funcID='0101'>发散风寒药</a></li>
                                <li><a href="javascript:void(0);" funcID='0102'>发散风热药</a></li>
                            </ul>
                        </li>
                        <li><a href="javascript:void(0);" funcID='02'>清热药</a>
                            <ul>
                                <li><a href="javascript:void(0);" funcID='0201'>清热泻火药</a></li>
                                <li><a href="javascript:void(0);" funcID='0202'>清热燥湿药</a></li>
                                <li><a href="javascript:void(0);" funcID='0203'>清热解毒药</a></li>
                                <li><a href="javascript:void(0);" funcID='0204'>清热凉血药</a></li>
                                <li><a href="javascript:void(0);" funcID='0205'>清虚热药</a></li>
                            </ul>
                        </li>
                         <li><a href="javascript:void(0);" funcID='03'>泻下药</a>
                            <ul>
                                <li><a href="javascript:void(0);" funcID='0301'>攻下药</a></li>
                                <li><a href="javascript:void(0);" funcID='0302'>润下药</a></li>
                                <li><a href="javascript:void(0);" funcID='0303'>峻下逐水药</a></li>
                            </ul>
                        </li>
                        <li><a href="javascript:void(0);" funcID='04'>祛风湿药</a>
                            <ul>
                                <li><a href="javascript:void(0);" funcID='0401'>祛风湿散寒药</a></li>
                                <li><a href="javascript:void(0);" funcID='0402'>祛风湿清热药</a></li>
                                <li><a href="javascript:void(0);" funcID='0403'>祛风湿强筋骨药</a></li>
                            </ul>
                        </li>

                        <li><a href="javascript:void(0);" funcID='05'>化湿药</a></li>
                        <li><a href="javascript:void(0);" funcID='06'>利水渗湿药</a>
                            <li><a href="javascript:void(0);" funcID='0601'>利水消肿药</a></li>
                            <li><a href="javascript:void(0);" funcID='0602'>利尿通淋药</a></li>
                            <li><a href="javascript:void(0);" funcID='0603'>利湿退黄药</a></li>

                        </li>

                        <li><a href="javascript:void(0);" funcID='07'>温里药</a></li>
                        <li><a href="javascript:void(0);" funcID='08'>理气药</a></li>
                        <li><a href="javascript:void(0);" funcID='09'>消食药</a></li>
                        <li><a href="javascript:void(0);" funcID='10'>驱虫药</a></li>
                        <li><a href="javascript:void(0);" funcID='11'>止血药</a>
                            <ul>
                                <li><a href="javascript:void(0);" funcID='1101'>凉血止血药</a></li>
                                <li><a href="javascript:void(0);" funcID='1102'>化瘀止血药</a></li>
                                <li><a href="javascript:void(0);" funcID='1103'>收敛止血药</a></li>
                                <li><a href="javascript:void(0);" funcID='1104'>温经止血药</a></li>
                            </ul>
                        </li>
                        <li><a href="javascript:void(0);" funcID='12'>活血化瘀药</a>
                            <ul>
                                <li><a href="javascript:void(0);" funcID='1201'>活血止痛药</a></li>
                                <li><a href="javascript:void(0);" funcID='1202'>活血调经药</a></li>
                                <li><a href="javascript:void(0);" funcID='1203'>活血疗伤药</a></li>
                            </ul>
                        </li>

                        <li><a href="javascript:void(0);" funcID='13'>化痰止咳平喘药</a>
                            <ul>
                                <li><a href="javascript:void(0);" funcID='1301'>化痰药</a></li>
                                <li><a href="javascript:void(0);" funcID='1302'>止咳平喘药</a></li>
                            </ul>
                        </li>
                        <li><a href="javascript:void(0);" funcID='14'>安神药</a></li>
                        <li><a href="javascript:void(0);" funcID='15'>平肝熄风药</a></li>
                        <li><a href="javascript:void(0);" funcID='16'>开窍药</a></li>

                        <li><a href="javascript:void(0);" funcID='17'>补虚药</a>
                            <ul>
                                <li><a href="javascript:void(0);" funcID='1701'>补气药</a></li>
                                <li><a href="javascript:void(0);" funcID='1702'>补养药</a></li>
                                <li><a href="javascript:void(0);" funcID='1703'>补血药</a></li>
                                <li><a href="javascript:void(0);" funcID='1704'>补阴药</a></li>
                            </ul>
                        </li>
                        <li><a href="javascript:void(0);" funcID='18'>收涩药</a>
                            <ul>
                                <li><a href="javascript:void(0);" funcID='1801'>敛肺涩肠药</a></li>
                                <li><a href="javascript:void(0);" funcID='1802'>固精缩尿止带药</a></li>
                            </ul>
                        </li>

                        <li><a href="javascript:void(0);" funcID='19'>解毒杀虫燥湿止痒药</a></li>
                    </ul>
                </div>

                <div id="partMenuPanel" class="ddsmoothmenu-v" style="display:none;">
                    <ul id="partMenu">
                        <li><a class='selected' href="javascript:void(0);" partID=''>全部</a></li>
                        
                        <li><a href="javascript:void(0);" partID='01'>根及根茎类药材</a>
                            <ul>
                                <li><a href="javascript:void(0);" partID='0101'>根类药材</a></li>
                                <li><a href="javascript:void(0);" partID='0102'>根茎类药材</a></li>
                            </ul>
                        </li>
                        <li><a href="javascript:void(0);" partID='02'>茎木类药材</a></li>
                        <li><a href="javascript:void(0);" partID='03'>皮类药材</a></li>
                        <li><a href="javascript:void(0);" partID='04'>叶类药材</a></li>
                        <li><a href="javascript:void(0);" partID='05'>花类药材</a></li>
                            <li><a href="javascript:void(0);" partID='06'>果实与种子类药材</a>
                            <ul>
                                <li><a href="javascript:void(0);" partID='0601'>果实类药材</a></li>
                                <li><a href="javascript:void(0);" partID='0602'>种子类药材</a></li>
                            </ul>
                        </li>
                        <li><a href="javascript:void(0);" partID='07'>全草类药材</a></li>
                        <li><a href="javascript:void(0);" partID='08'>其他类药材</a></li>
                        <li><a href="javascript:void(0);" partID='09'>动物类药材</a></li>
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
            <div class="site-nav"><span>当前位置 : </span><a href="index.aspx">首页</a> &gt;&gt; <a href="digital_specimen.aspx">中药数字标本馆</a></div>
            <div id="medicine_items">
                 <ul class="clearfix" id="resItems">

                </ul>
            </div>
            <div id="pager" style="float:right;padding-right:10px;"></div>
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
</asp:Content>
