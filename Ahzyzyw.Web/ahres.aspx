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
            <div style="width:410px; float: left; text-align:center;">
                <fieldset style="border-color:#ccc;border-width:1px;border-style:Solid; margin:5px 0px 0px 0px;">
                    <legend style="color:#333333;margin-left:20px; font-size:1.5em;font-weight:bold;">
                        安徽药用资源概况
                    </legend>
                    <img alt="安徽药材资源分布图" title="安徽药材资源分布图" width="400" height="524" src="images/ah.gif" usemap="#ahmap" />
                    <map name="ahmap" id="ahmap">
                        <area shape="poly" coords="162,68,156,55,156,39,143,41,142,36,132,28,130,4,147,0,160,0,169,16,198,26,206,57,248,68,255,95,290,96,271,139,247,142,237,134,225,133,216,122,199,125,192,124,192,138,174,140,187,125,186,120,180,113,180,101,187,76,183,67,190,56,177,58,172,67" href="javascript:void(0);" alt="宿州" />
                        <area shape="poly" coords="143,85,164,68,173,67,178,58,189,58,183,71,186,75,179,100,180,112,186,123,174,140,169,123,165,118,150,117,150,100" href="javascript:void(0);" alt="淮北" />
                        <area shape="poly" coords="144,82,128,87,114,57,92,49,72,63,77,101,86,111,94,114,102,128,96,142,97,148,110,154,114,163,124,171,123,176,134,177,134,161,156,171,168,165,167,151,174,139,168,120,150,118,150,101,143,85" href="javascript:void(0);" alt="亳州" />
                        <area shape="poly" coords="76,100,54,102,53,127,46,141,32,146,13,136,15,151,12,160,37,172,34,201,43,200,48,211,59,205,66,221,82,215,91,216,99,198,109,203,117,216,127,211,137,219,153,206,139,195,139,184,135,176,125,176,119,165,112,163,110,155,95,145,100,125,93,113,85,112" href="javascript:void(0);" alt="阜阳" />
                        <area shape="poly" coords="135,162,134,175,139,183,139,196,153,207,165,199,172,207,184,188,171,172,156,171" href="javascript:void(0);" alt="淮南" />
                        <area shape="poly" coords="158,171,169,163,167,150,175,138,193,138,194,124,217,122,225,133,248,141,269,141,270,152,284,149,261,171,249,164,238,173,226,170,225,176,213,186,204,183,198,195,183,189,171,172" href="javascript:void(0);" alt="蚌埠" />
                        <area shape="poly" coords="285,149,292,189,300,198,322,196,332,175,350,176,358,192,368,196,366,220,353,235,330,217,312,217,321,227,320,255,301,262,259,282,242,266,250,255,246,240,216,240,209,236,214,229,212,218,199,219,197,193,204,182,216,186,224,177,226,171,234,175,243,174,249,164,259,171,265,170" href="javascript:void(0);" alt="滁州" />
                        <area shape="poly" coords="184,190,198,195,198,219,211,219,215,230,209,234,216,241,246,241,249,254,242,268,229,273,218,293,194,310,158,306,154,274,171,263,180,263,179,245,184,227,172,220,171,205" href="javascript:void(0);" alt="合肥" />
                        <area shape="poly" coords="91,213,99,197,116,213,126,211,136,219,164,198,172,204,173,220,184,227,180,246,179,261,155,272,158,305,187,309,162,346,155,345,145,353,131,352,133,340,117,341,110,348,99,343,89,353,66,336,55,338,41,313,56,282,88,275,92,257" href="javascript:void(0);" alt="六安" />
                        <area shape="poly" coords="187,311,209,303,233,271,245,266,258,281,302,262,293,277,302,288,289,301,290,319,282,325,283,337,270,339,257,347,253,355,242,356,239,350,235,350,230,371,213,361,191,360,180,349,174,329" href="javascript:void(0);" alt="巢湖" />
                        <area shape="poly" coords="301,291,332,308,327,339,314,339,302,337,290,318,288,300" href="javascript:void(0);" alt="马鞍山" />
                        <area shape="poly" coords="318,340,318,350,301,365,301,373,293,373,293,391,281,384,278,385,273,393,262,397,259,388,250,381,265,378,265,369,254,353,258,345,265,345,271,339,285,337,283,323,291,317,303,338" href="javascript:void(0);" alt="芜湖" />
                        <area shape="poly" coords="254,355,241,356,237,351,230,367,228,380,234,381,236,388,250,380,265,378,265,368" href="javascript:void(0);" alt="铜陵" />
                        <area shape="poly" coords="230,373,213,362,190,358,180,350,174,328,162,346,152,345,147,353,131,353,133,341,116,341,110,347,99,345,88,351,96,359,77,365,76,374,67,381,78,401,77,429,89,436,93,473,112,478,117,470,136,458,137,447,147,451,159,435,160,416,167,410,190,410,193,402,193,393,211,392,229,379" href="javascript:void(0);" alt="安庆" />
                        <area shape="poly" coords="228,380,237,388,249,382,259,387,261,395,248,406,247,413,245,427,237,433,239,442,220,444,205,450,199,456,189,455,181,469,174,492,160,495,150,505,141,499,132,492,145,472,153,473,146,450,159,435,160,416,167,410,191,409,194,394,210,392" href="javascript:void(0);" alt="池州" />
                        <area shape="poly" coords="249,412,249,405,259,397,278,392,280,384,294,394,294,372,303,372,303,363,320,345,347,346,355,340,375,345,373,356,392,360,374,413,359,414,369,419,366,430,373,429,366,440,356,440,350,448,323,440,326,457,313,455,296,469,289,467,290,455,273,450,273,433,276,426,262,419,259,414" href="javascript:void(0);" alt="宣城" />
                        <area shape="poly" coords="248,413,245,427,238,433,239,443,207,449,198,456,186,456,181,472,184,482,198,479,198,494,213,507,243,515,249,509,254,523,274,523,297,507,316,499,314,485,325,484,324,477,331,464,325,456,312,455,296,470,289,467,289,456,274,451,273,432,276,427,262,419,259,415" href="javascript:void(0);" alt="黄山" />
                    </map>
                </fieldset>
            </div>
            <div style="width: 270px;float:right; padding:5px 10px 5px 5px;">
                <p id="cityResDes">安徽省药用资源概况</p>
            </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        $("#ahmap area").each(function () {
            $(this).attr("title", $(this).attr("alt"));
        });
        
        $("#ahmap area").click(function () {
            $("#cityResDes").text('暂无' + $(this).attr("alt") + "资源信息");
        });
    </script>
</asp:Content>
