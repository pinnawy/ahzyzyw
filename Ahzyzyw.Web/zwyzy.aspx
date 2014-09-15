<%@ Page Title="药苑医药资源" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="zwyzy.aspx.cs" Inherits="Ahzyzyw.Web.Service" %>

<asp:Content ID="GardenContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="clearfix">
        <div class="page-left">
            <div class="left-garden">
                <h2><span>中药材分类</span></h2>
                <div class="ddsmoothmenu-v">
                    <ul id="menu">
                        <li><a href="garden.aspx">药苑概况</a></li>
                        <li><a class="selected" href="#top">药苑医药资源</a></li>
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
            <div class="site-nav"><span>当前位置 : </span><a href="index.aspx">首页</a> &gt;&gt; <a href="garden.aspx">网上植物园</a></div>
            <div class="page-single">
                <div id="grrdenMapPanel" style="width: 460px; float: left; text-align: center;">
                    <fieldset style="border-color: #666666; border-width: 1px; border-style: Solid; margin: 20px 0px 0px 0px;">
                        <legend style="color: #333333; font-size: 1.8em; font-weight: bold;">药苑资源分布图
                        </legend>
                        <img alt="药苑资源分布图" title="药苑资源分布图" src="images/gardenmap.gif" usemap="#map" />
                        <map name="map" id="map">
                            <area shape="POLY" coords="17,31,88,28,88,96,16,100,17,31" href="#_1">
                            <area shape="POLY" coords="93,27,166,23,166,91,92,96" href="#_2">
                            <area shape="POLY" coords="169,22,168,91,217,89,212,80,212,69,217,59,226,53,237,51,245,51,243,17" href="#_3">
                            <area shape="POLY" coords="246,16,321,15,326,86,262,88,265,77,265,65,258,57,251,52,246,52" href="#_4">
                            <area shape="POLY" coords="326,15,401,11,407,82,329,85" href="#_5">
                            <area shape="POLY" coords="329,87,408,85,411,159,333,161" href="#_10">
                            <area shape="POLY" coords="249,97,260,89,326,88,329,161,271,162,249,144" href="#_9">
                            <area shape="POLY" coords="169,93,218,91,225,97,231,98,246,99,248,141,239,135,230,134,169,136" href="#_8">
                            <area shape="POLY" coords="99,98,166,94,167,137,113,139,113,131,116,123,115,115,111,108,105,102,99,101" href="#_7">
                            <area shape="POLY" coords="81,100,15,102,15,174,70,172,89,153,85,148,72,143,65,133,65,117,72,106" href="#_6">
                            <area shape="POLY" coords="333,163,335,222,340,231,340,240,414,238,412,161" href="#_11">
                            <area shape="POLY" coords="339,243,415,242,416,319,340,320" href="#_12">
                            <area shape="POLY" coords="341,324,416,323,418,400,340,401,339,359,342,354" href="#_13">
                            <area shape="POLY" coords="340,405,416,403,417,441,410,449,341,451" href="#_14">
                            <area shape="POLY" coords="153,352,192,352,205,381,143,380" href="#A1">
                            <area shape="POLY" coords="140,386,207,386,219,414,130,414" href="#A2">
                            <area shape="POLY" coords="127,420,223,420,235,448,116,447" href="#A3">
                            <area shape="POLY" coords="200,349,226,322,256,334,212,376" href="#B1">
                            <area shape="POLY" coords="215,382,261,336,292,347,228,411" href="#B2">
                            <area shape="POLY" coords="231,417,297,350,326,360,243,444" href="#B3">
                            <area shape="POLY" coords="230,313,259,324,257,265,228,276" href="#C1">
                            <area shape="POLY" coords="263,262,294,249,295,339,264,326" href="#C2">
                            <area shape="POLY" coords="301,340,331,352,328,234,298,246" href="#C3">
                            <area shape="POLY" coords="226,268,253,254,209,214,198,243" href="#D1">
                            <area shape="POLY" coords="261,253,289,241,223,180,211,208" href="#D2">
                            <area shape="POLY" coords="225,174,295,237,322,225,236,145" href="#D3">
                            <area shape="POLY" coords="216,172,123,175,111,148,227,144" href="#E3">
                            <area shape="POLY" coords="137,207,202,206,214,177,125,181" href="#E2">
                            <area shape="POLY" coords="139,212,201,211,189,240,150,239" href="#E1">
                            <area shape="POLY" coords="118,270,143,245,131,216,89,260" href="#F1">
                            <area shape="POLY" coords="84,257,128,211,116,184,56,247" href="#F2">
                            <area shape="POLY" coords="51,245,115,179,103,153,24,235" href="#F3">
                            <area shape="POLY" coords="115,315,114,278,86,268,87,326" href="#G1">
                            <area shape="POLY" coords="81,330,81,266,53,256,54,340" href="#G2">
                            <area shape="POLY" coords="49,343,22,354,22,243,49,253" href="#G3">
                            <area shape="POLY" coords="118,323,146,350,134,376,92,334" href="#H1">
                            <area shape="POLY" coords="86,338,131,382,121,411,58,349" href="#H2">
                            <area shape="POLY" coords="51,351,118,417,109,444,26,362" href="#H3">
                            <area shape="CIRCLE" coords="172,297,43" href="#I">
                        </map>
                    </fieldset>
                </div>
                <div id="garden_res" style="width: 200px; float: right; padding-top: 20px;">
                    <h3 id="I">一、水生区（水沟及太极）</h3>
                    <ol class="res">
                        <li>
                            <span>蒲黄</span>、<span>菱角</span>、<span><a resid="d32a5707-d945-4e7f-afa0-a09ec0a310ed">睡莲</a></span>、<span><a resid="84d9c08c-18d6-4639-81b3-4aacd55457b6">莲</a></span></li>
                    </ol>
                    <h3>二、八卦图</h3>
                    <h3 id="A1">AⅠ区：</h3>
                    <ol class="res">
                        <li>
                            <span>
                                <a resid="d82e21f2-119a-4f7e-b415-fc6278e41121">鸢尾</a>
                            </span>
                        </li>
                        <li>
                            <span>
                                <a resid="4160b325-562a-4135-bb18-cba32c8562bc">黄花鸢尾</a>
                            </span>、<span>白花鸢尾</span>、<span>光皮木瓜</span>、<span><a resid="312ab681-b53b-4527-8a9e-23cf2980653e">侧柏</a></span></li>
                        <li>
                            <span>
                                <a resid="20ffaa4e-9ca7-4460-ae24-3102efa989a9">射干</a>
                            </span>、<span><a resid="312ab681-b53b-4527-8a9e-23cf2980653e">侧柏</a></span>、<span>光皮木瓜</span></li>
                        <li>
                            <span>
                                <a resid="20ffaa4e-9ca7-4460-ae24-3102efa989a9">射干</a>
                            </span>
                        </li>
                    </ol>
                    <h3 id="A2">AⅡ区：</h3>
                    <ol class="res">
                        <li>
                            <span>党参</span>
                        </li>
                        <li>
                            <span>党参</span>、<span>光皮木瓜</span></li>
                        <li>
                            <span>
                                <a resid="d272ae72-67e7-4442-88d9-85812ee99fd2">皱皮木瓜</a>
                            </span>
                        </li>
                        <li>
                            <span>
                                <a resid="d272ae72-67e7-4442-88d9-85812ee99fd2">皱皮木瓜</a>
                            </span>
                        </li>
                        <li>
                            <span>荆芥</span>、<span>光皮木瓜</span></li>
                        <li>
                            <span>荆芥</span>
                        </li>
                    </ol>
                    <h3 id="a3">AⅢ区：</h3>
                    <ol class="res">
                        <li>
                            <span>景天三七</span>、<span><a resid="ca57fcea-c743-4e7a-8322-73d22b3434b5">樱桃</a></span></li>
                        <li>
                            <span>
                                <a resid="94de431e-c794-4724-9706-8b8dbb0c2f3a">玫瑰</a>
                            </span>
                        </li>
                        <li>
                            <span>
                                <a resid="6ec2b5d3-9b40-4687-a211-286de404d9f5">月季</a>
                            </span>、<span>梅（红梅）</span></li>
                        <li>
                            <span>
                                <a resid="6ec2b5d3-9b40-4687-a211-286de404d9f5">月季</a>
                            </span>
                        </li>
                        <li>
                            <span>
                                <a resid="6ec2b5d3-9b40-4687-a211-286de404d9f5">月季</a>
                            </span>
                        </li>
                        <li>
                            <span>
                                <a resid="6ec2b5d3-9b40-4687-a211-286de404d9f5">月季</a>
                            </span>、<span>梅（绿梅）</span></li>
                        <li>
                            <span>
                                <a resid="94de431e-c794-4724-9706-8b8dbb0c2f3a">玫瑰</a>
                            </span>、<span><a resid="ca57fcea-c743-4e7a-8322-73d22b3434b5">樱桃</a></span></li>
                    </ol>
                    <h3 id="B1">BⅠ区：</h3>
                    <ol class="res">
                        <li>
                            <span>狭叶十大功劳</span>、<span><a resid="b1b5d298-4f4c-4cf9-82aa-75deb6a86463">棣棠花</a></span>、<span><a resid="d95bf6cd-3d80-4845-9fb1-d51ab6dba5c2">南天竹</a></span>、<span>阔叶十大功劳</span>、<span>杜鹃</span>、<span><a resid="1e0d3620-e9a1-4d82-a98e-1fa00d5ce550">三白草</a></span>、<span><a resid="97c380c3-fe35-4c55-ad1e-928945250c5f">鱼腥草</a></span></li>
                        <li>
                            <span>狭叶十大功劳</span>、<span><a resid="b1b5d298-4f4c-4cf9-82aa-75deb6a86463">棣棠花</a></span>、<span><a resid="d95bf6cd-3d80-4845-9fb1-d51ab6dba5c2">南天竹</a></span>、<span>阔叶十大功劳</span></li>
                    </ol>
                    <h3 id="B2">BⅡ区：</h3>
                    <ol class="res">
                        <li>
                            <span>
                                <a resid="aa1756fa-fb0e-412e-b212-6630a404f412">金荞麦</a>
                            </span>、<span><a resid="e57c93e4-9b2d-47fb-8b34-b601f1b1af8b">石榴</a></span></li>
                        <li>
                            <span>金不换</span>、<span><a resid="102f18b6-444b-45f7-b45c-569c2a13b882">羊蹄</a></span>、<span><a resid="e772808b-85f9-42f8-9266-99e54872f653">橘</a></span>、<span>水大黄</span></li>
                        <li>
                            <span>
                                <a resid="aa1756fa-fb0e-412e-b212-6630a404f412">金荞麦</a>
                            </span>、<span><a resid="a7fcdc31-0378-46c6-8923-11b846edb38d">瞿麦</a></span>、<span>阔叶十大功劳</span>、<span><a resid="91224d1b-343b-45c4-aa7d-2f0712769225">拳参</a></span>、<span><a resid="97fb1336-f00b-492f-b1b6-8b3527afc5bf">酸模</a></span></li>
                        <li>
                            <span>阔叶十大功劳</span>
                        </li>
                        <li>
                            <span>
                                <a resid="e772808b-85f9-42f8-9266-99e54872f653">橘</a>
                            </span>、<span>寿星桃</span></li>
                    </ol>
                    <h3 id="B3">BⅢ区：</h3>
                    <ol class="res">
                        <li>
                            <span>
                                <a resid="e3fe3430-e7d7-4373-89ee-0129cb4b1f6a">黄芪</a>
                            </span>
                        </li>
                        <li>
                            <span>荆芥</span>、<span><a resid="1b9c587c-81c2-42d4-a4d9-01961741eed8">金钱松</a></span></li>
                        <li>
                            <span>
                                <a resid="ef190638-7f4c-46c7-8205-e88be01ee2ed">木荷</a>
                            </span>
                        </li>
                        <li>
                            <span>瓜蒌</span>
                        </li>
                        <li>
                            <span>
                                <a resid="06558549-9df1-4d8f-9cbf-bab064835bd7">红花</a>
                            </span>
                        </li>
                        <li>
                            <span>
                                <a resid="1033b6ba-4d25-4c0d-a0fb-de3598f08b6c">远志</a>
                            </span>
                        </li>
                        <li>
                            <span>
                                <a resid="0862ae80-f281-4279-8649-2fd9850841c9">含羞草</a>
                            </span>
                        </li>
                        <li>
                            <span>千金子</span>
                        </li>
                    </ol>
                    <h3 id="C1">CⅠ区：</h3>
                    <ol class="res">
                        <li>
                            <span>
                                <a resid="251e8eaa-4200-43ac-a3dd-0a24940c8efe">玄参</a>
                            </span>
                        </li>
                        <li>
                            <span>
                                <a resid="251e8eaa-4200-43ac-a3dd-0a24940c8efe">玄参</a>
                            </span>、<span>红枫</span></li>
                        <li>
                            <span>地黄</span>、<span>红枫</span></li>
                    </ol>
                    <h3 id="C2">CⅡ区：</h3>
                    <ol class="res">
                        <li>
                            <span>
                                <a resid="c5e4fb44-62a1-407d-9503-93e3296adec9">丹参</a>
                            </span>
                        </li>
                        <li>
                            <span>
                                <a resid="c5e4fb44-62a1-407d-9503-93e3296adec9">丹参</a>
                            </span>、<span>草石蚕</span>、<span>一种待定</span>、<span><a resid="c8938c7f-c6a5-4479-809a-24cf3d959394">紫参</a></span>、<span><a resid="ab54b56e-0ae7-4470-9ed3-6449d477a18e">乌头</a></span></li>
                        <li>
                            <span>
                                <a resid="93c6a845-20e0-452b-a1bc-06221205c4a9">风轮菜</a>
                            </span>、<span><a resid="c8938c7f-c6a5-4479-809a-24cf3d959394">紫参</a></span>、<span><a resid="a8d41d97-9e3e-43fa-af5a-8a05e0bd6544">连钱草</a></span>、<span><a resid="1e498884-9c61-4921-97fe-efcfa0c68c84">白毛夏枯草</a></span>、<span><a resid="af215c57-2773-4f17-845b-3ba26f500455">夏枯草</a></span></li>
                        <li>
                            <span>
                                <a resid="06992f0b-f60f-476e-b470-8bd1fc913e40">留兰香</a>
                            </span>、<span><a resid="95f9a69b-6651-45c5-8083-7028ec1d3e28">薄荷</a></span>、<span><a resid="5137e97b-4864-49f7-a002-4f5846ba4d6b">益母草</a></span>、<span><a resid="18ba6be8-7d4c-4b8e-a07c-2474719bccc0">牡蒿</a></span>、<span><a resid="77ffb1b6-3953-437d-943f-f63b55f86f50">香茶菜</a></span></li>
                        <li>
                            <span>
                                <a resid="55c0dd32-f896-40a4-b8f3-7fc608fd683c">黄芩</a>
                            </span>、<span>野花椒</span>、<span><a resid="1066f0a2-264d-4c55-b1ce-95e1a6aab1bf">半枝莲</a></span>、<span>断血流</span></li>
                        <li>
                            <span>地瓜儿苗</span>
                        </li>
                    </ol>
                    <h3 id="C3">CⅢ区：</h3>
                    <ol class="res">
                        <li>
                            <span>
                                <a resid="90df80a1-9c99-4858-866b-089175533b57">枸杞</a>
                            </span>、<span><a resid="1f6cddfb-874a-4f7e-94cb-77e9ba72fcdf">白英</a></span>、<span>洋金花</span></li>
                        <li>
                            <span>
                                <a resid="1b9c587c-81c2-42d4-a4d9-01961741eed8">金钱松</a>
                            </span>
                        </li>
                        <li>
                            <span>
                                <a resid="9e41f975-4959-4793-9abb-60a7c13cd807">天竺桂</a>
                            </span>
                        </li>
                        <li>
                            <span>
                                <a resid="c5e4fb44-62a1-407d-9503-93e3296adec9">丹参</a>
                            </span>、<span><a resid="1b9c587c-81c2-42d4-a4d9-01961741eed8">金钱松</a></span></li>
                        <li>
                            <span>
                                <a resid="c5e4fb44-62a1-407d-9503-93e3296adec9">丹参</a>
                            </span>
                        </li>
                        <li>
                            <span>
                                <a resid="c5e4fb44-62a1-407d-9503-93e3296adec9">丹参</a>
                            </span>、<span><a resid="9e41f975-4959-4793-9abb-60a7c13cd807">天竺桂</a></span></li>
                        <li>
                            <span>
                                <a resid="55c0dd32-f896-40a4-b8f3-7fc608fd683c">黄芩</a>
                            </span>、<span><a resid="1b9c587c-81c2-42d4-a4d9-01961741eed8">金钱松</a></span></li>
                        <li>
                            <span>荆芥</span>、<span><a resid="1b9c587c-81c2-42d4-a4d9-01961741eed8">金钱松</a></span></li>
                    </ol>
                    <h3 id="D1">DⅠ区：</h3>
                    <ol class="res">
                        <li>
                            <span>仙鹤草</span>、<span><a resid="06682ced-adfd-45d5-bcae-ea4ea438afdf">地榆</a></span>、<span><a resid="8f66757d-20cc-4414-a840-3345002bbf18">结香</a></span></li>
                        <li>
                            <span>仙鹤草</span>、<span>水杨梅（蔷薇科）</span>、<span><a resid="06682ced-adfd-45d5-bcae-ea4ea438afdf">地榆</a></span>、<span><a resid="170839bb-aeb6-4483-b167-391c20e76a01">金樱子</a></span>、<span><a resid="95f9a69b-6651-45c5-8083-7028ec1d3e28">薄荷</a></span></li>
                        <li>
                            <span>蛇含</span>、<span>芫花</span>、<span><a resid="4418bdbc-9eb8-415e-ab0f-64d0eb41d67d">蛇莓</a></span>、<span><a resid="8f66757d-20cc-4414-a840-3345002bbf18">结香</a></span>、<span><a resid="5084391d-37ae-4498-9c86-21d1b069901a">虎杖</a></span></li>
                        <li>
                            <span>
                                <a resid="608238aa-5874-4997-bd1c-2f18d38a9da4">翻白草</a>
                            </span>、<span><a resid="c5e4fb44-62a1-407d-9503-93e3296adec9">丹参</a></span>、<span>草莓</span>、<span><a resid="95f9a69b-6651-45c5-8083-7028ec1d3e28">薄荷</a></span></li>
                    </ol>
                    <h3 id="D2">DⅡ区：</h3>
                    <ol class="res">
                        <li>
                            <span>
                                <a resid="c68ef4e6-c34e-41d1-ae4c-aea052e2ece0">火棘</a>
                            </span>、<span><a resid="ab3ecbed-b444-4c56-9bc2-e976c5d47e46">郁李</a></span></li>
                        <li>
                            <span>
                                <a resid="170839bb-aeb6-4483-b167-391c20e76a01">金樱子</a>
                            </span>、<span><a resid="d751c68c-9498-491a-9afe-8183fe276638">山莓</a></span>、<span>木瓜（观赏）</span></li>
                        <li>
                            <span>
                                <a resid="ab3ecbed-b444-4c56-9bc2-e976c5d47e46">郁李</a>
                            </span>、<span>木瓜（观赏）</span></li>
                        <li>
                            <span>
                                <a resid="ab3ecbed-b444-4c56-9bc2-e976c5d47e46">郁李</a>
                            </span>、<span>木瓜（观赏）</span></li>
                        <li>
                            <span>木瓜（观赏）</span>
                        </li>
                        <li>
                            <span>
                                <a resid="c68ef4e6-c34e-41d1-ae4c-aea052e2ece0">火棘</a>
                            </span>
                        </li>
                    </ol>
                    <h3 id="D3">DⅢ区：</h3>
                    <ol class="res">
                        <li>
                            <span>短梗箭头唐松草</span>、<span><a resid="54eb0aaa-1893-41bd-8c88-cd5bd9d2bbda">毛茛</a></span></li>
                        <li>
                            <span>
                                <a resid="a2fe567d-b457-422c-bfe4-44425f591d08">白头翁</a>
                            </span>、<span><a resid="d65b5775-02b1-44ee-ba51-0b521ff464cf">枇杷</a></span>、<span><a resid="390e26b2-ff20-42fc-bfe9-4a5e0d7194d1">山木通</a></span></li>
                        <li>
                            <span>杨子毛茛</span>、<span>猫爪草</span>、<span>豹皮樟</span></li>
                        <li>
                            <span>寿星桃</span>、<span><a resid="a651871e-2ee8-4b92-bde8-ac1129a2567d">刺果毛茛</a></span></li>
                        <li>
                            <span>寿星桃</span>、<span><a resid="a651871e-2ee8-4b92-bde8-ac1129a2567d">刺果毛茛</a></span></li>
                        <li>
                            <span>
                                <a resid="6cd562a9-1430-46e6-9fdc-0df7e52016e4">茜草</a>
                            </span>、<span>小叶栀子</span>、<span>豹皮樟</span></li>
                        <li>
                            <span>
                                <a resid="a7fcdc31-0378-46c6-8923-11b846edb38d">瞿麦</a>
                            </span>、<span>寿星桃</span>、<span><a resid="4f5d97ba-0081-4f51-94e6-56846a442fab">麦蓝菜</a></span></li>
                        <li>
                            <span>
                                <a resid="f91e061c-ea46-49d4-89eb-cd966e0e9260">沙参</a>
                            </span>
                        </li>
                    </ol>
                    <h3 id="E1">EⅠ区：</h3>
                    <ol class="res">
                        <li>
                            <span>紫菀</span>、<span>续断</span>、<span>虎皮楠</span></li>
                        <li>
                            <span>
                                <a resid="1b6c3ae5-115a-4a07-9cc4-f652cc903c60">金鸡菊</a>
                            </span>、<span><a resid="fdcd98da-525c-4a3e-81f6-e736fc60a404">佩兰</a></span></li>
                        <li>
                            <span>法国蒲公英</span>、<span><a resid="17873063-0939-47bf-96fb-576ad8c35082">一枝黄花</a></span>、<span>三脉叶马兰</span></li>
                        <li>
                            <span>风斗菜</span>、<span>虎皮楠</span></li>
                    </ol>
                    <h3 id="E2">EⅡ区：</h3>
                    <ol class="res">
                        <li>
                            <span>
                                <a resid="6a623c47-402a-4eb9-975f-225d6199e527">白术</a>
                            </span>、<span><a resid="95f9a69b-6651-45c5-8083-7028ec1d3e28">薄荷</a></span></li>
                        <li>
                            <span>
                                <a resid="6a623c47-402a-4eb9-975f-225d6199e527">白术</a>
                            </span>、<span>美国红栌</span>、<span><a resid="94508975-1aa4-4b4c-84d4-8ce7b0545d4e">千里光</a></span></li>
                        <li>
                            <span>美国红栌</span>
                        </li>
                        <li>
                            <span>美国红栌</span>
                        </li>
                        <li>
                            <span>美国红栌</span>、<span><a resid="06558549-9df1-4d8f-9cbf-bab064835bd7">红花</a></span></li>
                        <li>
                            <span>蓍草</span>、<span><a resid="06558549-9df1-4d8f-9cbf-bab064835bd7">红花</a></span>、<span><a resid="57acf432-1ad4-41aa-a017-425f247770f8">阴地蒿</a></span></li>
                    </ol>
                    <h3 id="E3">EⅢ区：</h3>
                    <ol class="res">
                        <li>
                            <span>
                                <a resid="8ee4c4f1-eac6-4a1a-955c-5245831a79b1">水飞蓟</a>
                            </span>、<span>续断</span>、<span><a resid="05187ac8-8b2f-4cb1-a09e-2fe6856d5936">垂盆草</a></span>、<span>大蓟</span>、<span>黄花败酱</span>、<span><a resid="b9a511c1-a11b-49fd-854b-6c050c757120">野茉莉</a></span></li>
                        <li>
                            <span>
                                <a resid="8ee4c4f1-eac6-4a1a-955c-5245831a79b1">水飞蓟</a>
                            </span>
                        </li>
                        <li>
                            <span>
                                <a resid="b9a511c1-a11b-49fd-854b-6c050c757120">野茉莉</a>
                            </span>
                        </li>
                        <li>
                            <span>
                                <a resid="b9a511c1-a11b-49fd-854b-6c050c757120">野茉莉</a>
                            </span>
                        </li>
                        <li>
                            <span>
                                <a resid="b9a511c1-a11b-49fd-854b-6c050c757120">野茉莉</a>
                            </span>
                        </li>
                        <li>
                            <span>
                                <a resid="b9a511c1-a11b-49fd-854b-6c050c757120">野茉莉</a>
                            </span>
                        </li>
                        <li>
                            <span>
                                <a resid="b9a511c1-a11b-49fd-854b-6c050c757120">野茉莉</a>
                            </span>、<span><a resid="18ba6be8-7d4c-4b8e-a07c-2474719bccc0">牡蒿</a></span></li>
                    </ol>
                    <h3 id="F1">FⅠ区：</h3>
                    <ol class="res">
                        <li>
                            <span>
                                <a resid="2c8a9e6d-714f-44db-a00e-08a05d54a04d">紫藤</a>
                            </span>、<span><a resid="616dbb64-dcf7-420e-b503-9fcad1d9c823">圆柏</a></span>、<span><a resid="390e26b2-ff20-42fc-bfe9-4a5e0d7194d1">山木通</a></span></li>
                    </ol>
                    <h3 id="F2">FⅡ区：</h3>
                    <ol class="res">
                        <li>
                            <span>
                                <a resid="0caf71e9-5f4e-4453-831c-f6d0961cda8a">杠板归</a>
                            </span>
                        </li>
                        <li>
                            <span>八仙花</span>
                        </li>
                        <li>
                            <span>红楝子</span>、<span>白芷</span></li>
                        <li>
                            <span>红楝子</span>、<span><a resid="a3a70532-f936-4912-9ea5-6b39bafb906d">柴胡</a></span></li>
                        <li>
                            <span>
                                <a resid="f671d5f6-37a5-4e94-8867-6a2d309c5083">防风</a>
                            </span>、<span>紫花前胡</span>、<span><a resid="538687ce-a383-42b9-9d1b-6dfe3f96c236">白花前胡</a></span>、<span>八仙花</span></li>
                        <li>
                            <span>白芷</span>
                        </li>
                    </ol>
                    <h3 id="F3">FⅢ区：</h3>
                    <ol class="res">
                        <li>
                            <span>灰灰菜</span>、<span><a resid="d513f51b-acfa-40ad-a8fb-e4b64b5e6f4b">宝盖草</a></span>、<span><a resid="6531e2c8-e129-4c95-a2fd-1823ebedb55f">荭蓼</a></span></li>
                        <li>
                            <span>辣蓼</span>、<span><a resid="6531e2c8-e129-4c95-a2fd-1823ebedb55f">荭蓼</a></span></li>
                        <li>
                            <span>皂角</span>
                        </li>
                        <li>
                            <span>皂角</span>
                        </li>
                        <li>
                            <span>板兰根</span>
                        </li>
                        <li>
                            <span>板兰根</span>
                        </li>
                        <li>
                            <span>板兰根</span>、<span>皂角</span>、<span><a resid="ef1b7278-438c-4255-9e5a-383ab2fcedd9">辣根</a></span></li>
                    </ol>
                    <h3 id="G1">GⅠ区：</h3>
                    <ol class="res">
                        <li>
                            <span>凌宵</span>、<span><a resid="616dbb64-dcf7-420e-b503-9fcad1d9c823">圆柏</a></span>、<span>米口袋</span>、<span>红花忍冬</span>、<span>金银花</span></li>
                    </ol>
                    <h3 id="G2">GⅡ区：</h3>
                    <ol class="res">
                        <li>
                            <span>黄花败酱</span>、<span><a resid="ce1a56c6-5e7e-43cb-bc38-af9158470107">白蔹</a></span></li>
                        <li>
                            <span>盘柱南五味</span>、<span>三叶木通</span>、<span>五叶木通</span>、<span><a resid="c78a9250-bef9-4186-8a59-3a0f29db0fc7">石楠</a></span></li>
                        <li>
                            <span>
                                <a resid="2dbe20d1-16e2-4d2d-9ea7-0e2840351c8a">威灵仙</a>
                            </span>、<span><a resid="ce1a56c6-5e7e-43cb-bc38-af9158470107">白蔹</a></span>、<span>豹皮樟</span></li>
                        <li>
                            <span>决明子</span>、<span>豹皮樟</span></li>
                        <li>
                            <span>决明子</span>、<span><a resid="c78a9250-bef9-4186-8a59-3a0f29db0fc7">石楠</a></span></li>
                        <li>
                            <span>
                                <a resid="27d078ed-b1c7-4cf4-9aa7-35f725580281">锦鸡儿</a>
                            </span>、<span><a resid="53d1d2b9-7b93-4e85-8123-b141b9f07a46">苦参</a></span></li>
                    </ol>
                    <h3 id="G3">GⅢ区：</h3>
                    <ol class="res">
                        <li>
                            <span>木耳菜</span>、<span><a resid="95f9a69b-6651-45c5-8083-7028ec1d3e28">薄荷</a></span></li>
                        <li>
                            <span>地丁</span>、<span>山栀子</span></li>
                        <li>
                            <span>
                                <a resid="9e41f975-4959-4793-9abb-60a7c13cd807">天竺桂</a>
                            </span>
                        </li>
                        <li>
                            <span>山栀子</span>
                        </li>
                        <li>
                            <span>山栀子</span>
                        </li>
                        <li>
                            <span>
                                <a resid="53d1d2b9-7b93-4e85-8123-b141b9f07a46">苦参</a>
                            </span>、<span><a resid="9e41f975-4959-4793-9abb-60a7c13cd807">天竺桂</a></span></li>
                        <li>
                            <span>
                                <a resid="53d1d2b9-7b93-4e85-8123-b141b9f07a46">苦参</a>
                            </span>、<span><a resid="a62d2420-714b-40d4-b157-a999f9e8ba70">桔梗</a></span>、<span>山栀子</span></li>
                        <li>
                            <span>接骨草</span>
                        </li>
                    </ol>
                    <h3 id="H1">HⅠ区：</h3>
                    <ol class="res">
                        <li>
                            <span>
                                <a resid="1eafc77a-5639-4293-b121-caa45c574d50">石蒜</a>
                            </span>
                        </li>
                        <li>
                            <span>香港四照花</span>、<span><a resid="29c131a7-1e22-495c-bc64-cebddd3b14d9">黄花菜</a></span>、<span><a resid="35f2647d-1651-448a-879f-baf5134a4250">萱草</a></span>、<span><a resid="009cd9a7-cde5-4f28-bbaa-2db808d2bc69">水仙</a></span>、<span><a resid="1eafc77a-5639-4293-b121-caa45c574d50">石蒜</a></span></li>
                        <li>
                            <span>阔叶麦冬</span>、<span>狭叶麦冬</span>、<span><a resid="49138b1b-d93f-4a91-bb7a-2da2317dc0b0">麦冬</a></span>、<span><a resid="009cd9a7-cde5-4f28-bbaa-2db808d2bc69">水仙</a></span>、<span><a resid="d1c20523-9bdb-46e0-b5ba-af2ed0c1f49a">万年青</a></span></li>
                        <li>
                            <span>
                                <a resid="9e0b9030-6eb1-4e73-b16e-767e12e890ac">吉祥草</a>
                            </span>
                        </li>
                    </ol>
                    <h3 id="H2">HⅡ区：</h3>
                    <ol class="res">
                        <li>
                            <span>浙贝</span>
                        </li>
                        <li>
                            <span>红叶桃</span>、<span><a resid="31fd5cab-851c-4649-a437-a347e33822ac">松叶百合</a></span></li>
                        <li>
                            <span>
                                <a resid="31fd5cab-851c-4649-a437-a347e33822ac">松叶百合</a>
                            </span>、<span>美国红栌</span></li>
                        <li>
                            <span>
                                <a resid="31fd5cab-851c-4649-a437-a347e33822ac">松叶百合</a>
                            </span>、<span>美国红栌</span></li>
                        <li>
                            <span>
                                <a resid="31fd5cab-851c-4649-a437-a347e33822ac">松叶百合</a>
                            </span>、<span><a resid="e07d091c-75fa-4d0d-b497-879eb3709655">枣</a></span></li>
                        <li>
                            <span>
                                <a resid="31fd5cab-851c-4649-a437-a347e33822ac">松叶百合</a>
                            </span>
                        </li>
                    </ol>
                    <h3 id="H3">HⅢ区：</h3>
                    <ol class="res">
                        <li>
                            <span>
                                <a resid="287d7546-e061-418a-8cfc-6bb9d43466fc">长春花</a>
                            </span>、<span>光皮木瓜</span></li>
                        <li></li>
                        <li>
                            <span>
                                <a resid="ef190638-7f4c-46c7-8205-e88be01ee2ed">木荷</a>
                            </span>
                        </li>
                        <li></li>
                        <li>
                            <span>光皮木瓜</span>
                        </li>
                        <li>
                            <span>
                                <a resid="ef190638-7f4c-46c7-8205-e88be01ee2ed">木荷</a>
                            </span>
                        </li>
                        <li>
                            <span>光皮木瓜</span>
                        </li>
                        <li>
                            <span>
                                <a resid="96c32daa-1b13-459a-812b-87420645f159">红旱莲</a>
                            </span>、<span><a resid="5f81033a-44ee-435a-a4d2-b30f0c35eb43">元宝草</a></span>、<span><a resid="7e3787fc-c3c3-4f9b-90e4-efc655fd2d78">珍珠菜</a></span></li>
                    </ol>
                    <h3>三、八卦外围</h3>
                    <h3 id="_1">一区：</h3>
                    <ol class="res">
                        <li>
                            <span>
                                <a resid="dcb5af0a-79af-4cbb-89aa-abc0775ecc0a">黄檗</a>
                            </span>、<span><a resid="4a062553-951b-410c-81f8-6e4bf91e3292">竹柏</a></span>、<span><a resid="09c1d4a2-ca94-42e0-bb54-e819d8f9f451">芭蕉</a></span></li>
                        <li>
                            <span>
                                <a resid="dcb5af0a-79af-4cbb-89aa-abc0775ecc0a">黄檗</a>
                            </span>、<span><a resid="29c6fdee-1961-42a8-8dd9-782b47e3f6ec">厚朴</a></span></li>
                        <li>
                            <span>
                                <a resid="8d2d66ae-3d89-465b-b292-3fdc058c3a03">天目木姜子</a>
                            </span>、<span><a resid="4c98e51d-0608-464c-87b5-cb613bb0f0d6">七叶树</a></span></li>
                        <li>
                            <span>
                                <a resid="cca87f5f-65f1-41ae-8d23-a7a4c2fd3247">灯台树</a>
                            </span>、<span><a resid="3867a7b5-3d80-4011-8b31-f4b85b2b056d">山茱萸</a></span></li>
                        <li>
                            <span>
                                <a resid="e55c2976-5b28-4de1-b2e3-8ec569f211cd">苍术</a>
                            </span>、<span><a resid="6a623c47-402a-4eb9-975f-225d6199e527">白术</a></span>、<span><a resid="3867a7b5-3d80-4011-8b31-f4b85b2b056d">山茱萸</a></span>、<span><a resid="a62d2420-714b-40d4-b157-a999f9e8ba70">桔梗</a></span></li>
                        <li>
                            <span>紫花前胡</span>、<span>四照花</span>、<span><a resid="3867a7b5-3d80-4011-8b31-f4b85b2b056d">山茱萸</a></span>、<span><a resid="620ef4e9-eaab-4c46-aa0d-4fae4fc7da18">桃</a></span>、<span><a resid="251e8eaa-4200-43ac-a3dd-0a24940c8efe">玄参</a></span></li>
                        <li>
                            <span>
                                <a resid="c5e4fb44-62a1-407d-9503-93e3296adec9">丹参</a>
                            </span>、<span>续断</span>、<span><a resid="c8938c7f-c6a5-4479-809a-24cf3d959394">紫参</a></span></li>
                    </ol>
                    <h3 id="_2">二区：</h3>
                    <ol class="res">
                        <li>
                            <span>
                                <a resid="8d2d66ae-3d89-465b-b292-3fdc058c3a03">天目木姜子</a>
                            </span>、<span><a resid="3fce6ecf-99fb-4b47-9a34-48499f2bf6a7">千屈菜</a></span></li>
                        <li>
                            <span>山核桃</span>、<span>樟树</span></li>
                        <li>
                            <span>山核桃</span>、<span>樟树</span></li>
                        <li>
                            <span>
                                <a resid="02419c4b-e4f6-4cc0-83f3-00d8e5660974">板栗</a>
                            </span>、<span><a resid="b9b983d5-0cb6-489b-871f-bc6528e3c191">梓树</a></span></li>
                        <li>
                            <span>牡丹</span>
                        </li>
                        <li>
                            <span>牡丹</span>
                        </li>
                        <li>
                            <span>
                                <a resid="23a9eead-859d-4326-8183-c41a1b8d3a37">芍药</a>
                            </span>
                        </li>
                    </ol>
                    <h3 id="_3">三区：</h3>
                    <ol class="res">
                        <li>
                            <span>
                                <a resid="a8f6a4ba-6835-4134-b4a4-6c56f5594606">火炭母</a>
                            </span>、<span>仙鹤草</span>、<span><a resid="936b3ba0-0e34-40d3-96c1-f718bd27badc">败酱</a></span>、<span><a resid="5084391d-37ae-4498-9c86-21d1b069901a">虎杖</a></span>、
                            <span>白芷</span>、<span>三叶木通</span>、<span>五叶木通</span>、<span><a resid="55c0dd32-f896-40a4-b8f3-7fc608fd683c">黄芩</a></span>
                            、<span><a resid="4de527a0-b3bf-4d37-8a6b-f4bf60657137">牛蒡</a></span>、<span><a resid="d82e21f2-119a-4f7e-b415-fc6278e41121">鸢尾</a></span></li>
                        <li>
                            <span>
                                <a resid="49138b1b-d93f-4a91-bb7a-2da2317dc0b0">麦冬</a>
                            </span>、<span><a resid="dabb2608-0225-4059-b7dc-dc42e9cb6911">臭牡丹</a></span></li>
                        <li>
                            <span>
                                <a resid="d1c20523-9bdb-46e0-b5ba-af2ed0c1f49a">万年青</a>
                            </span>、<span>阔叶麦冬</span>、<span><a resid="49138b1b-d93f-4a91-bb7a-2da2317dc0b0">麦冬</a></span>、<span><a resid="05317f22-177f-4f26-9e3a-6ab43ae11dc7">茅莓</a></span>、<span><a resid="9e0b9030-6eb1-4e73-b16e-767e12e890ac">吉祥草</a></span></li>
                        <li>
                            <span>苦丁茶</span>、<span>大别山五针松</span>、<span><a resid="99389006-4e62-4a42-8097-73635311b37f">乌药</a></span>、<span><a resid="e491d294-b0f6-485b-b736-4510c3091ff3">卫矛</a></span>、
                              <span>大蓟</span>、<span><a resid="06682ced-adfd-45d5-bcae-ea4ea438afdf">地榆</a></span>、<span><a resid="a17a5331-aaa9-47fc-88d7-b579a8fcdf36">刺柏</a></span>、<span><a resid="44455e66-9057-4c19-af95-503921e3470d">檵木</a></span></li>
                        <li>
                            <span>
                                <a resid="4de527a0-b3bf-4d37-8a6b-f4bf60657137">牛蒡</a>
                            </span>、<span>节骨木</span>、<span><a resid="ab54b56e-0ae7-4470-9ed3-6449d477a18e">乌头</a></span>、<span>兰草</span>、<span><a resid="6a623c47-402a-4eb9-975f-225d6199e527">白术</a></span>、<span>狭叶十大功劳</span></li>
                        <li>
                            <span>
                                <a resid="e10edfb9-6e65-4a99-8f95-9951afb2785c">吴茱萸</a>
                            </span>、<span>漏斗花</span>、<span><a resid="d06e0459-685b-40e4-9de5-ef7de9693b08">兔儿伞</a></span>、<span><a resid="54279e67-70fb-4080-b2a0-5f22478a28f7">紫萁</a></span>、<span>续断</span>、<span>玉簪</span>、<span><a resid="ebdd3f1b-d721-4de0-a153-de012287ee76">胡颓子</a></span>、<span><a resid="5084391d-37ae-4498-9c86-21d1b069901a">虎杖</a></span></li>
                        <li>
                            <span>
                                <a resid="e57c93e4-9b2d-47fb-8b34-b601f1b1af8b">石榴</a>
                            </span>、<span><a resid="1f06ea33-904c-49f0-a0e0-c3f45daf1e14">木半夏</a></span></li>
                        <li>
                            <span>小叶女贞</span>、<span><a resid="c68ef4e6-c34e-41d1-ae4c-aea052e2ece0">火棘</a></span>、<span>大叶柴胡</span>、<span>木瓜（观赏）</span></li>
                    </ol>
                    <h3 id="_4">四区：</h3>
                    <ol class="res">
                        <li>
                            <span>蕉芋</span>、<span><a resid="19db0e0f-d623-4ed5-97d5-a0405c14c23c">桂花</a></span></li>
                        <li>
                            <span>月桂</span>
                        </li>
                        <li>
                            <span>
                                <a resid="fd58883d-8cf8-4afb-8645-fc5e732e9800">红豆杉</a>
                            </span>、<span><a resid="19db0e0f-d623-4ed5-97d5-a0405c14c23c">桂花</a></span></li>
                        <li>
                            <span>
                                <a resid="32f73107-a3ea-42e9-97c0-0c12763e54fb">无患子</a>
                            </span>
                        </li>
                        <li>
                            <span>
                                <a resid="32f73107-a3ea-42e9-97c0-0c12763e54fb">无患子</a>
                            </span>
                        </li>
                        <li>
                            <span>
                                <a resid="e10edfb9-6e65-4a99-8f95-9951afb2785c">吴茱萸</a>
                            </span>、<span><a resid="a72627eb-54e0-4750-bbed-56231537a151">无花果</a></span>、<span><a resid="dabb2608-0225-4059-b7dc-dc42e9cb6911">臭牡丹</a></span>、<span>臭梧桐</span>、<span>凌宵</span></li>
                        <li>
                            <span>
                                <a resid="836c16dd-a503-4cf9-bfb1-3c50acdad5b9">合欢</a>
                            </span>、<span><a resid="67c11fcd-2301-4f9f-81d2-bb86ce307f72">楤木</a></span></li>
                    </ol>
                    <h3 id="_5">五区：</h3>
                    <ol class="res">
                        <li>
                            <span>
                                <a resid="32f73107-a3ea-42e9-97c0-0c12763e54fb">无患子</a>
                            </span>、<span><a resid="b0ffd763-fd74-40f8-b72e-d550d25ba340">罗汉松</a></span></li>
                        <li>
                            <span>大叶榉</span>、<span><a resid="8f66757d-20cc-4414-a840-3345002bbf18">结香</a></span>、<span><a resid="b0ffd763-fd74-40f8-b72e-d550d25ba340">罗汉松</a></span>、<span><a resid="e772808b-85f9-42f8-9266-99e54872f653">橘</a></span></li>
                        <li>
                            <span>山栀子</span>、<span>大叶榉</span>、<span><a resid="c78a9250-bef9-4186-8a59-3a0f29db0fc7">石楠</a></span>、<span><a resid="8f66757d-20cc-4414-a840-3345002bbf18">结香</a></span>、<span><a resid="32f73107-a3ea-42e9-97c0-0c12763e54fb">无患子</a></span>、<span><a resid="772def1e-e26b-4215-a9c5-8c2e6ab3f3c2">紫薇</a></span>、<span>臭大青</span></li>
                        <li>
                            <span>
                                <a resid="09c1d4a2-ca94-42e0-bb54-e819d8f9f451">芭蕉</a>
                            </span>、<span>红枫</span>、<span><a resid="8f66757d-20cc-4414-a840-3345002bbf18">结香</a></span>、<span>大叶榉</span>、<span>金丝桃</span>、<span><a resid="3ba67b81-bb39-4168-ae49-9b6ff872ad25">金丝梅</a></span>、<span>山桐子</span>、<span>六月雪</span></li>
                        <li>
                            <span>
                                <a resid="c78a9250-bef9-4186-8a59-3a0f29db0fc7">石楠</a>
                            </span>、<span>大叶榉</span>、<span>山桐子</span>、<span>金丝桃</span>、<span>樟树</span></li>
                        <li>
                            <span>国槐</span>
                        </li>
                        <li>
                            <span>
                                <a resid="19db0e0f-d623-4ed5-97d5-a0405c14c23c">桂花</a>
                            </span>
                        </li>
                    </ol>
                    <h3 id="_6">六区：</h3>
                    <ol class="res">
                        <li>
                            <span>青枫</span>、<span>枸骨</span></li>
                        <li>
                            <span>枸骨</span>、<span><a resid="3994e84c-ffc0-4038-be67-19653f7bc4ff">锦葵</a></span></li>
                        <li>
                            <span>枸骨</span>、<span>臭大青</span></li>
                        <li>
                            <span>
                                <a resid="df7d71ef-27e6-47d9-81cb-3fc48a1fed6c">枫香</a>
                            </span>、<span>臭大青</span>、<span><a resid="620ef4e9-eaab-4c46-aa0d-4fae4fc7da18">桃</a></span>、<span>枸骨</span>、<span><a resid="e6b4e074-a88a-41e5-a5a8-c626bcbc17dd">马棘</a></span></li>
                    </ol>
                    <h3 id="_7">七区：</h3>
                    <ol class="res">
                        <li>
                            <span>
                                <a resid="531784bb-6b31-4249-800e-af3116f893d5">八角金盘</a>
                            </span>
                        </li>
                        <li>
                            <span>红毛五加</span>、<span>金银木</span></li>
                        <li>
                            <span>细柱五加</span>、<span><a resid="ce955866-3961-4818-9792-db900f73db6f">连翘</a></span></li>
                        <li>
                            <span>三叶五加</span>、<span><a resid="ce955866-3961-4818-9792-db900f73db6f">连翘</a></span></li>
                    </ol>
                    <h3 id="_8">八区：</h3>
                    <ol class="res">
                        <li>
                            <span>菊花</span>、<span><a resid="ce955866-3961-4818-9792-db900f73db6f">连翘</a></span></li>
                        <li>
                            <span>菊花</span>、<span>徽菊</span>、<span>贡菊</span>、<span><a resid="ce955866-3961-4818-9792-db900f73db6f">连翘</a></span></li>
                        <li>
                            <span>菊花</span>、<span>徽菊</span>、<span><a resid="ce955866-3961-4818-9792-db900f73db6f">连翘</a></span></li>
                        <li>
                            <span>菊花</span>、<span>亳菊</span>、<span>迎春花</span></li>
                        <li>
                            <span>滁菊</span>、<span>松果菊</span>、<span><a resid="25f15843-24b4-4c88-bce6-cc9a3d4fa5ae">金光菊</a></span>、<span>刘寄奴</span>、<span>珍珠梅</span>、<span>三脉叶马兰</span></li>
                    </ol>
                    <h3 id="_9">九区：</h3>
                    <ol class="res">
                        <li>
                            <span>
                                <a resid="1b8a55b3-4afa-4664-96ab-251285f2a352">白及</a>
                            </span>、<span>月桂</span></li>
                        <li>
                            <span>
                                <a resid="8909470c-0bf5-4ae0-83b2-aa2252c41ca3">紫楠</a>
                            </span>、<span>大叶榉</span>、<span><a resid="1b8a55b3-4afa-4664-96ab-251285f2a352">白及</a></span>、<span>边翘</span></li>
                        <li>
                            <span>华东楠</span>、<span><a resid="1b8a55b3-4afa-4664-96ab-251285f2a352">白及</a></span>、<span>大叶榉</span>、<span><a resid="a72627eb-54e0-4750-bbed-56231537a151">无花果</a></span>、<span>边翘</span></li>
                        <li>
                            <span>
                                <a resid="1b8a55b3-4afa-4664-96ab-251285f2a352">白及</a>
                            </span>、<span><a resid="67c11fcd-2301-4f9f-81d2-bb86ce307f72">楤木</a></span>、<span>边翘</span></li>
                        <li>
                            <span>
                                <a resid="dad88e4f-3e9d-4878-bae8-59f0b0c157b9">蜡梅</a>
                            </span>
                        </li>
                    </ol>
                    <h3 id="_10">十区：</h3>
                    <ol class="res">
                        <li>
                            <span>龙爪槐</span>、<span><a resid="dad88e4f-3e9d-4878-bae8-59f0b0c157b9">蜡梅</a></span>、<span><a resid="7b2f88c0-4421-42a3-87e4-6b19992282b4">金钟花</a></span></li>
                        <li>
                            <span>
                                <a resid="973e540e-3c5a-4d41-86ac-1dafb2390330">杏</a>
                            </span>、<span><a resid="7b2f88c0-4421-42a3-87e4-6b19992282b4">金钟花</a></span></li>
                        <li>
                            <span>
                                <a resid="973e540e-3c5a-4d41-86ac-1dafb2390330">杏</a>
                            </span>、<span><a resid="e07d091c-75fa-4d0d-b497-879eb3709655">枣</a></span>、<span><a resid="7b2f88c0-4421-42a3-87e4-6b19992282b4">金钟花</a></span></li>
                        <li>
                            <span>
                                <a resid="973e540e-3c5a-4d41-86ac-1dafb2390330">杏</a>
                            </span>、<span><a resid="32f73107-a3ea-42e9-97c0-0c12763e54fb">无患子</a></span>、<span><a resid="7b2f88c0-4421-42a3-87e4-6b19992282b4">金钟花</a></span></li>
                        <li>
                            <span>
                                <a resid="973e540e-3c5a-4d41-86ac-1dafb2390330">杏</a>
                            </span>、<span><a resid="32f73107-a3ea-42e9-97c0-0c12763e54fb">无患子</a></span>、<span><a resid="7b2f88c0-4421-42a3-87e4-6b19992282b4">金钟花</a></span></li>
                        <li>
                            <span>
                                <a resid="19db0e0f-d623-4ed5-97d5-a0405c14c23c">桂花</a>
                            </span>、<span><a resid="7b2f88c0-4421-42a3-87e4-6b19992282b4">金钟花</a></span></li>
                    </ol>
                    <h3 id="_11">十一区：</h3>
                    <ol class="res">
                        <li>
                            <span>樱花</span>、<span><a resid="ccf4c5fd-e534-47a8-8c2d-14a3bc567959">柽柳</a></span>、<span><a resid="cd29d44e-7221-4d26-aa73-271386753714">知母</a></span>、<span><a resid="5bbff5f7-ce1e-49c5-9ac7-d503b7841146">甘草</a></span>、<span><a resid="a62d2420-714b-40d4-b157-a999f9e8ba70">桔梗</a></span>、<span>龙爪槐</span></li>
                        <li>
                            <span>
                                <a resid="772def1e-e26b-4215-a9c5-8c2e6ab3f3c2">紫薇</a>
                            </span>、<span>茶梅</span></li>
                        <li>
                            <span>
                                <a resid="772def1e-e26b-4215-a9c5-8c2e6ab3f3c2">紫薇</a>
                            </span>、<span><a resid="973e540e-3c5a-4d41-86ac-1dafb2390330">杏</a></span></li>
                        <li>
                            <span>
                                <a resid="772def1e-e26b-4215-a9c5-8c2e6ab3f3c2">紫薇</a>
                            </span>、<span><a resid="973e540e-3c5a-4d41-86ac-1dafb2390330">杏</a></span></li>
                        <li>
                            <span>深山含笑</span>
                        </li>
                        <li>
                            <span>
                                <a resid="19db0e0f-d623-4ed5-97d5-a0405c14c23c">桂花</a>
                            </span>、<span><a resid="772def1e-e26b-4215-a9c5-8c2e6ab3f3c2">紫薇</a></span></li>
                    </ol>
                    <h3 id="_12">十二区：</h3>
                    <ol class="res">
                        <li>
                            <span>青枫</span>、<span>日本樱花</span></li>
                        <li>
                            <span>红枫</span>
                        </li>
                        <li>
                            <span>红枫</span>
                        </li>
                        <li>
                            <span>红枫</span>
                        </li>
                        <li>
                            <span>昌花槭</span>、<span>深山含笑</span></li>
                        <li>
                            <span>
                                <a resid="19db0e0f-d623-4ed5-97d5-a0405c14c23c">桂花</a>
                            </span>、<span>流苏</span>、<span>红枫</span></li>
                    </ol>
                    <h3 id="_13">十三区：</h3>
                    <ol class="res">
                        <li>
                            <span>
                                <a resid="a8b87d3f-ec07-41ec-91dd-52bf2f3a253a">贯众</a>
                            </span>、<span>井栏边草</span>、<span><a resid="17f5de1b-7259-4b6b-84ce-cf625389d410">狗脊蕨</a></span>、<span><a resid="94a2b737-50d0-422b-a659-4daa4cb56351">半夏</a></span>、
                            <span><a resid="e63a7510-f0dd-452e-89a3-f797335cba9c">蓬蘽</a></span>、<span>中华槭</span>、<span><a resid="9b297136-2b6d-4b3a-a6de-e261e49808d6">冬青</a></span>、<span><a resid="5910b793-38f0-4172-8de9-f146b032b98d">醉鱼草</a></span>、
                            <span><a resid="99389006-4e62-4a42-8097-73635311b37f">乌药</a></span>、<span>杜鹃</span>、<span><a resid="6b36f57d-e566-443c-896c-bedcd7923ec6">细叶香桂</a></span>、<span><a resid="a5e1ed5a-731a-4a01-a887-cd44e5c5c784">圆锥绣球</a></span></li>
                        <li>
                            <span>
                                <a resid="17f5de1b-7259-4b6b-84ce-cf625389d410">狗脊蕨</a>
                            </span>、<span><a resid="f91e061c-ea46-49d4-89eb-cd966e0e9260">沙参</a></span>、<span><a resid="8d6cd8b9-f68b-4d49-acbf-0b2f13667796">明党参</a></span>、<span><a resid="424d486a-693b-4070-8978-9aeec6e9fda3">八角枫</a></span>、<span><a resid="e6b4e074-a88a-41e5-a5a8-c626bcbc17dd">马棘</a></span></li>
                        <li>
                            <span>
                                <a resid="17f5de1b-7259-4b6b-84ce-cf625389d410">狗脊蕨</a>
                            </span>、<span>京大戟</span>、<span><a resid="a1851cf1-eea2-4158-ad03-ddc9693639f8">多花黄精</a></span>、<span><a resid="e2a97a81-4c02-4800-8f21-3685bc6e46a1">景天</a></span>、
                            <span><a resid="6cd562a9-1430-46e6-9fdc-0df7e52016e4">茜草</a></span>、<span>一种待定</span>、<span><a resid="e6b4e074-a88a-41e5-a5a8-c626bcbc17dd">马棘</a></span></li>
                        <li>
                            <span>
                                <a resid="17f5de1b-7259-4b6b-84ce-cf625389d410">狗脊蕨</a>
                            </span>、<span><a resid="ab54b56e-0ae7-4470-9ed3-6449d477a18e">乌头</a></span>、<span>草乌</span>、<span><a resid="c8031c13-a07f-4881-96de-877fca2db64b">宝铎草</a></span>、
                            <span>细辛</span>、<span>重楼</span>、<span><a resid="aa1756fa-fb0e-412e-b212-6630a404f412">金荞麦</a></span>、<span>三角槭</span>、
                            <span><a resid="90df80a1-9c99-4858-866b-089175533b57">枸杞</a></span></li>
                        <li>
                            <span>
                                <a resid="ab54b56e-0ae7-4470-9ed3-6449d477a18e">乌头</a>
                            </span>、<span>雀梅</span>、<span>创花树</span>、<span>红花檵木</span>、
                            <span>昌花槭</span></li>
                        <li>
                            <span>
                                <a resid="19db0e0f-d623-4ed5-97d5-a0405c14c23c">桂花</a>
                            </span>、<span><a resid="ccf4c5fd-e534-47a8-8c2d-14a3bc567959">柽柳</a></span>、<span>小叶女贞</span>、<span><a resid="65346d2b-f2e7-4831-8ca3-1e878468de75">葡萄</a></span></li>
                    </ol>
                    <h3>三角Ⅰ区：</h3>
                    <ol class="res">
                        <li>
                            <span>秋葵</span>、<span><a resid="a52bd5ae-42a0-4ea3-9993-a07e79f9caf8">蜀葵</a></span>、<span>丁香</span></li>
                        <li>
                            <span>丁香</span>
                        </li>
                        <li>
                            <span>丁香</span>、<span><a resid="bf8f4f92-05df-41e0-b800-900da9fa79de">夏天无</a></span>、<span><a resid="54ebaa91-86fe-4d14-adf0-d082f56320ad">博落回</a></span></li>
                    </ol>
                    <h3>三角Ⅱ区：</h3>
                    <ol class="res">
                        <li>
                            <span>牡丹</span>
                        </li>
                    </ol>
                    <h3>三角Ⅲ区：</h3>
                    <ol class="res">
                        <li>
                            <span>
                                <a resid="23a9eead-859d-4326-8183-c41a1b8d3a37">芍药</a>
                            </span>、<span>红瑞木</span>、<span>茶梅</span>、<span><a resid="94de431e-c794-4724-9706-8b8dbb0c2f3a">玫瑰</a></span>、<span><a resid="6ec2b5d3-9b40-4687-a211-286de404d9f5">月季</a></span>、<span><a resid="9e41f975-4959-4793-9abb-60a7c13cd807">天竺桂</a></span>、<span><a resid="620ef4e9-eaab-4c46-aa0d-4fae4fc7da18">桃</a></span></li>
                    </ol>
                    <h3>铁塔Ⅰ区：</h3>
                    <ol class="res">
                        <li>
                            <span>
                                <a resid="87de5698-9212-410e-b663-cf1a5dd09b65">美人蕉</a>
                            </span>、<span>狭叶十大功劳</span></li>
                    </ol>
                    <h3>铁塔Ⅱ区：</h3>
                    <ol class="res">
                        <li>
                            <span>
                                <a resid="87de5698-9212-410e-b663-cf1a5dd09b65">美人蕉</a>
                            </span>、<span><a resid="2d55c2c9-c60c-4273-bf48-c1065a9bcb53">乌桕</a></span></li>
                    </ol>
                    <h3>花窗区：</h3>
                    <ol class="res">
                        <li>
                            <span>
                                <a resid="09c1d4a2-ca94-42e0-bb54-e819d8f9f451">芭蕉</a>
                            </span>、<span><a resid="8a30610a-8a34-4c1c-9246-97c5d37c146c">日本小檗</a></span>、<span><a resid="1f06ea33-904c-49f0-a0e0-c3f45daf1e14">木半夏</a></span>、<span>金边麦冬</span>、
                            <span>枸骨</span>、<span>梅（红梅）</span>、<span>金银花</span>、<span><a resid="e57c93e4-9b2d-47fb-8b34-b601f1b1af8b">石榴</a></span>、
                            <span><a resid="20a98f15-f20e-4427-9e51-9b5a8a802739">葱莲</a></span>、<span><a resid="7b2f88c0-4421-42a3-87e4-6b19992282b4">金钟花</a></span></li>
                    </ol>
                    <h3>西边区：</h3>
                    <ol class="res">
                        <li>
                            <span>日本樱花</span>、<span>杜鹃</span>、<span><a resid="d65b5775-02b1-44ee-ba51-0b521ff464cf">枇杷</a></span>、<span><a resid="98b2cb2b-94a0-4158-9aed-fc71d0a856a0">红花木莲</a></span>、
                            <span>光皮木瓜</span>、<span><a resid="dad88e4f-3e9d-4878-bae8-59f0b0c157b9">蜡梅</a></span>、<span><a resid="88fef1ec-ce8e-43a5-95b6-789be64e231a">乳源木莲</a></span>、<span>海棠（二种）</span>、
                            <span>香港四照花</span>、<span><a resid="c78a9250-bef9-4186-8a59-3a0f29db0fc7">石楠</a></span>、<span>梅(红梅)</span>、<span>辛夷</span>、
                             <span><a resid="e2d30586-91f5-4d74-a676-c065b409a134">紫玉兰</a></span>、<span>五叶木通</span>、<span><a resid="88310998-138b-4fc5-bf4f-3f00295c97a5">何首乌</a></span>、<span>葫芦种一种</span>、
                             <span><a resid="c32dd45e-1c12-48e2-b8e7-225c1d332263">地不容</a></span>、<span>乐昌含笑</span>、<span>黄山含笑</span>、<span>深山含笑</span>、
                            <span>箭麻</span>、<span>竹叶椒</span></li>
                    </ol>
                    <h3>北边区：</h3>
                    <ol class="res">
                        <li>
                            <span>
                                <a resid="8a30610a-8a34-4c1c-9246-97c5d37c146c">日本小檗</a>
                            </span>、<span><a resid="19db0e0f-d623-4ed5-97d5-a0405c14c23c">桂花</a></span>、<span><a resid="49138b1b-d93f-4a91-bb7a-2da2317dc0b0">麦冬</a></span>、<span>山茶</span>、
                            <span>茶树</span>、<span><a resid="8f66757d-20cc-4414-a840-3345002bbf18">结香</a></span>、<span>山栀子</span>、<span><a resid="597827eb-afc7-4902-a391-798895863624">云实</a></span></li>
                    </ol>
                    <h3>东边区：</h3>
                    <ol class="res">
                        <li>
                            <span><a resid="8853646b-d4dc-4470-988f-d5855da43312">构树</a></span>、<span><a resid="fcaefb26-9010-4ad4-a278-6a51d081df4d">棕竹</a></span>、<span><a resid="f5b3b4ac-cb7f-4a25-bd9a-e54a91fc1b61">通脱木</a></span>、<span><a resid="8397990c-f402-4add-8069-c0784cee2f84">虎耳草</a></span>、
                            <span><a resid="bc4dd78c-097b-49e5-9624-4c0686c82e76">过路黄</a></span>、<span><a resid="05187ac8-8b2f-4cb1-a09e-2fe6856d5936">垂盆草</a></span>、<span><a resid="92902bda-fe65-4882-be3b-cbd3e5cccec6">紫竹</a></span>、<span><a resid="e151619d-6fa0-4a55-a021-8a0fc0edea90">毛竹</a></span>、
                            <span>白花地丁</span>、<span>碎米机</span>、<span><a resid="620ef4e9-eaab-4c46-aa0d-4fae4fc7da18">桃</a></span>、<span><a resid="4c98e51d-0608-464c-87b5-cb613bb0f0d6">七叶树</a></span>、
                            <span>青桐</span>、<span><a resid="d4711699-021a-4bf1-806d-5033d4100d5c">木芙蓉</a></span>、<span><a resid="312ab681-b53b-4527-8a9e-23cf2980653e">侧柏</a></span>、<span><a resid="ea578c3b-7ce1-413f-abf5-d37b882a274a">夹竹桃</a></span>、
                            <span><a resid="616dbb64-dcf7-420e-b503-9fcad1d9c823">圆柏</a></span>、<span>光皮桦</span>、<span><a resid="772def1e-e26b-4215-a9c5-8c2e6ab3f3c2">紫薇</a></span>、<span><a resid="2d55c2c9-c60c-4273-bf48-c1065a9bcb53">乌桕</a></span>、
                            <span><a resid="98b2cb2b-94a0-4158-9aed-fc71d0a856a0">红花木莲</a></span>、<span><a resid="1b9c587c-81c2-42d4-a4d9-01961741eed8">金钱松</a></span>、<span><a resid="cca87f5f-65f1-41ae-8d23-a7a4c2fd3247">灯台树</a></span>、<span><a resid="033acd45-ce6d-4298-a8cf-1209f8f12ba3">紫荆</a></span>、
                            <span><a resid="f3c23427-d151-482a-b333-69e6012371f2">木槿</a></span>、<span>山杜英</span>、<span><a resid="d9d7fa28-acb7-4cef-ae1a-1ea5d9a2a4dc">油桐</a></span>、<span><a resid="17d75759-f4fc-41af-90f8-49034c2ecd7e">杜仲</a></span>、
                            <span>楝</span>、<span><a resid="836c16dd-a503-4cf9-bfb1-3c50acdad5b9">合欢</a></span>、<span><a resid="e10edfb9-6e65-4a99-8f95-9951afb2785c">吴茱萸</a></span>、<span><a resid="973e540e-3c5a-4d41-86ac-1dafb2390330">杏</a></span>、
                            <span>水杉</span>、<span><a resid="ca53d2fc-4ca7-444d-9eb0-adb581bf2dde">马尾松</a></span>、<span><a resid="11c79954-e555-43fb-8a9a-b6f304a428ed">李</a></span>、<span><a resid="ca57fcea-c743-4e7a-8322-73d22b3434b5">樱桃</a></span>、
                            <span>南酸枣</span>、<span>梨</span>、<span><a resid="8a617985-9368-4a00-b557-0de4643c9383">槐</a></span>、<span>楝</span>、
                            <span><a resid="b1e651ae-88e1-4e68-ab18-644efc6e4436">香椿</a></span>、<span>红叶李</span>、<span><a resid="620ef4e9-eaab-4c46-aa0d-4fae4fc7da18">桃</a></span>、<span>柿树</span>、
                            <span>甜槠</span>、<span>小叶女贞</span>、<span><a resid="c35e6483-1181-4edc-8936-4bc30b586af4">女贞</a></span>、<span>苦李子</span>、
                            <span>绵槠</span>、<span><a resid="5e519e34-793d-482d-96e1-cc9f18f69c67">杉木</a></span>、<span><a resid="49b7e6f5-97fb-4454-a6ae-0abf491a8b05">山麻杆</a></span>、<span><a resid="24450627-85a8-4f0f-93ec-5ce79818fd25">桑</a></span>、
                            <span><a resid="2a69c8e0-a7c8-43af-a140-679e77f0ba4a">枫杨</a></span>、<span>毛樱桃</span>、<span><a resid="fa2ee980-1fa7-4e65-8d2d-7e4040a77172">刺槐</a></span>、<span>青冈</span>、
                            <span><a resid="2daaed84-1596-4311-a284-25ae18587fe6">枸橘</a></span>、<span>外松</span>、<span><a resid="f05ffcd7-0d6b-41cb-96f4-6e6b6bfed56b">盐肤木</a></span>、<span><a resid="09c1d4a2-ca94-42e0-bb54-e819d8f9f451">芭蕉</a></span>、
                            <span><a resid="8a30610a-8a34-4c1c-9246-97c5d37c146c">日本小檗</a></span>、<span>栀子花</span>、<span><a resid="d65b5775-02b1-44ee-ba51-0b521ff464cf">枇杷</a></span>、<span>白杜</span>、
                            <span><a resid="5084391d-37ae-4498-9c86-21d1b069901a">虎杖</a></span>、<span><a resid="52737baa-6b00-4e00-85be-8ffd841f2946">苎麻</a></span>、<span>淫羊藿</span></li>
                    </ol>
                </div>
            </div>
        </div>
    </div>

    <div id="itemDetail">
        <div style="text-align: right; cursor: default;"><a style="font-size: 16px; padding-right: 10px;" onclick="$.unblockUI()">X</a></div>
        <div id="itemContent" style="text-align: left; padding: 3px;">
        </div>
        <div style="padding-top: 5px;">
            <a style="cursor: default;" onclick="$.unblockUI()">关闭</a>
        </div>
    </div>

    <script type="text/javascript">

        window.onscroll = function () {
            var top = $(document).scrollTop();
            if (top > 350) {
                $("#grrdenMapPanel").css("margin-top", ($(document).scrollTop() - 350) + 'px');
            } else {
                $("#grrdenMapPanel").css("margin-top", '0px');
            }
        };

        $("#garden_res a").click(function () {
            var resId = $(this).attr('resId');
            $.post("Services/Resource.ashx?", { action: 'GetResource', resID: resId, timestamp: new Date().getTime() }, function (data) {
                var resItem = eval('(' + data + ')');
                var resDetail = getResItemHTML(resItem);
                showMedicineDetail(resDetail);
            });

            // window.location.href = "medicine.aspx?resId=" + );
        });

        function showMedicineDetail(e) {
            var detailContent;
            if (typeof e === "string") {
                detailContent = e;
            } else {
                var img = e.data.img;
                detailContent = $(img).parent().parent().parent().clone();
            }

            var itemPanel = $("#itemDetail");
            itemPanel.find("#itemContent").html(detailContent);

            $.blockUI({
                message: itemPanel,
                css: {
                    top: ($(window).height() - itemPanel.height()) / 2 - 50 + 'px',
                    left: ($(window).width() - itemPanel.width()) / 2 + 'px',
                    width: '600px',
                    fadeIn: 700,
                    fadeOut: 700,
                    cursor: 'normal'
                },
                overlayCSS: {
                    cursor: 'normal'
                }
            });

            $('.blockOverlay').click($.unblockUI);
        }
        
        function getResItemHTML(resItem) {

            var resItemTemplate = '<li> \
                            <h3 class="title ellipsis" title="{CnName}{EnName}（{Family}{Genus}）">{CnName}{EnName}（{Family}{Genus}）</h3> \
                            <div class="img">\
                                <a title="{CnName}"><img width=300 height=215 src="{Image}" alt="{CnName}" /></a> \
                            </div>\
                            <p><span>【别名】</span>{OtherName}</p>\
                            <p>{Description}</p> \
                        </li>';
            
            return resItemTemplate
                          .replace(new RegExp("{CnName}", "g"), resItem.CnName)
                          .replace(new RegExp("{EnName}", "g"), resItem.EnName)
                          .replace(new RegExp("{Family}", "g"), resItem.Family)
                          .replace(new RegExp("{Genus}", "g"), resItem.Genus)
                          .replace("{Description}", resItem.Description)
                          .replace("{OtherName}", resItem.OtherName || "无")
                          .replace("{Image}", resItem.Image);
        }
    </script>

</asp:Content>
