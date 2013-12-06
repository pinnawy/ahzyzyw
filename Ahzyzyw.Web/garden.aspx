<%@ Page Title="药苑概况" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="colleage.aspx.cs" Inherits="Ahzyzyw.Web.Service" %>
<asp:Content ID="GardenContent" ContentPlaceHolderID="MainContent" runat="server">

<div class="clearfix">
        <div class="page-left" >
            <div  class="left-garden">
                <h2><span>中药材分类</span></h2>
                <div class="ddsmoothmenu-v">
                    <ul id="menu">
                        <li><a class="selected" href="#top">药苑概况</a></li>
                        <li><a href="zwyzy.aspx">药苑医药资源</a></li>
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
            <div class="site-nav"><span>当前位置 : </span><a href="index.aspx">首页</a> &gt;&gt; <a href="#">网上植物园</a></div>
            <div class="page-single">
                <h1>药苑简介</h1>
                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;本药苑始建于2006年，占地13亩，共投入资金130余万元。整个药苑的设计造型是仿太极八卦图，寓意中医药历史源远流长。为了丰富园区八卦景观和适应中草药生长，在八卦之内还建有凉亭、长廊（藤本植物区）和环卦水渠（水生植物区）；在八卦之外，还设立了荫棚（阴生植物区）和暖房（喜温植物区），这些巧妙设计，不仅为栽培不同种类的药用植物提供了生存和发展的条件，同时也为参观和学习者提供了优美和温馨的环境。
                <img style="float:left;margin:10px;" alt="药苑西南透视效果图" title="药苑西南透视效果图" src="images/garden.jpg" width="284" height="189" />
                <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;药苑是展示鲜活药用植物的室外课堂，是进行教学实习、科学研究、物种驯化、新品种培育、以及宣传生物多样性和保护植物的基地。由于其地点设在校园内，对帮助和提高在校学生学习《药用植物识别技术》、《中药鉴定技术》、《实用中药》的理论知识，提高鉴别药用植物的实践能力作用重大。同时，通过情景教学，实践训练，对激发学生学习中医药知识的热情，培养学生珍惜植物、保护环境、热爱科学的意识具有重要意义。
                <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;目前，药苑从全国各地引种各类药用植物634种，其中草本植物436种，木本植物198种，全国统编《中药学》教材收载种类达70%。
                <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;为了配合老师实践教学、方便学生自学和普及科学知识，我们给园内的每种药用植物都挂上了写有植物名称、药用部位、功效的标识牌，由于有了标识牌，也大大方便了社会公众来园参观学习中草药知识。
                <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;为了彰显安徽中药资源大省特色，本药苑还特别建立了安徽道地药材和珍稀濒危植物资源圃，如铜陵牡丹圃、亳州芍药圃，宣城木瓜圃，黄山贡菊圃，大别山安徽贝母、白及圃；珍稀濒危植物有金钱松、连香树、黄山木兰、天竺桂、天目木姜子、黄檗等，这些植物的引种与栽培对保护中药种质资源和传递道地药材知识，发展道地药材生产具有积极的意义。
            </div>
        </div>
    </div>
</asp:Content>
