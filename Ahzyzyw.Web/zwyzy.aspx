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
                        <li><span>蒲黄</span>、<span>菱角</span>、<span>睡莲</span>、<span>莲</span></li>
                    </ol>


                    <h3>二、八卦图</h3>
                    <h3 id="A1">AⅠ区：</h3>
                    <ol class="res">
                        <li><span>鸢尾</span></li>
                        <li>
                            <span>黄花鸢尾</span>、<span>白花鸢尾</span>、<span>光皮木瓜</span>、<span>侧柏</span>
                        </li>
                        <li>
                            <span>射干</span>、<span>侧柏</span>、<span>光皮木瓜</span>
                        </li>
                        <li>
                            <span>射干</span>
                        </li>
                    </ol>

                    <h3 id="A2">AⅡ区：</h3>
                    <ol class="res">
                        <li><span>党参</span></li>
                        <li><span>党参</span>、<span>光皮木瓜</span></li>
                        <li><span>皱皮木瓜</span></li>
                        <li><span>皱皮木瓜</span></li>
                        <li><span>荆芥</span>、<span>光皮木瓜</span></li>
                        <li><span>荆芥</span></li>
                    </ol>

                    <h3 id="a3">AⅢ区：</h3>
                    <ol class="res">
                        <li><span>景天三七</span>、<span>樱桃</span></li>
                        <li><span>玫瑰</span></li>
                        <li><span>月季</span>、<span>梅（红梅）</span></li>
                        <li><span>月季</span></li>
                        <li><span>月季</span></li>
                        <li><span>月季</span>、<span>梅（绿梅）</span></li>
                        <li><span>玫瑰</span>、<span>樱桃</span></li>
                    </ol>

                    <h3 id="B1">BⅠ区：</h3>
                    <ol class="res">
                        <li><span>狭叶十大功劳</span>、<span>棣棠花</span>、<span>南天竹</span>、<span>阔叶十大功劳</span>、<span>杜鹃</span>、<span>三白草</span>、<span>鱼腥草</span></li>
                        <li><span>狭叶十大功劳</span>、<span>棣棠花</span>、<span>南天竹</span>、<span>阔叶十大功劳</span></li>
                    </ol>

                    <h3 id="B2">BⅡ区：</h3>
                    <ol class="res">
                        <li><span>金荞麦</span>、<span>石榴</span></li>
                        <li><span>金不换</span>、<span>羊蹄</span>、<span>橘</span>、<span>水大黄</span></li>
                        <li><span>金荞麦</span>、<span>瞿麦</span>、<span>阔叶十大功劳</span>、<span>拳参</span>、<span>酸模</span></li>
                        <li><span>阔叶十大功劳</span></li>
                        <li><span>橘</span>、<span>寿星桃</span></li>
                    </ol>

                    <h3 id="B3">BⅢ区：</h3>
                    <ol class="res">
                        <li><span>黄芪</span></li>
                        <li><span>荆芥</span>、<span>金钱松</span></li>
                        <li><span>木荷</span></li>
                        <li><span>瓜蒌</span></li>
                        <li><span>红花</span></li>
                        <li><span>远志</span></li>
                        <li><span>含羞草</span></li>
                        <li><span>千金子</span></li>
                    </ol>

                    <h3 id="C1">CⅠ区：</h3>
                    <ol class="res">
                        <li><span>玄参</span></li>
                        <li><span>玄参</span>、<span>红枫</span></li>
                        <li><span>地黄</span>、<span>红枫</span></li>
                    </ol>

                    <h3 id="C2">CⅡ区：</h3>
                    <ol class="res">
                        <li><span>丹参</span></li>
                        <li><span>丹参</span>、<span>草石蚕</span>、<span>一种待定</span>、<span>紫参</span>、<span>乌头</span></li>
                        <li><span>风轮菜</span>、<span>紫参</span>、<span>连钱草</span>、<span>白毛夏枯草</span>、<span>夏枯草</span></li>
                        <li><span>留兰香</span>、<span>薄荷</span>、<span>益母草</span>、<span>牡蒿</span>、<span>香茶菜</span></li>
                        <li><span>黄芩</span>、<span>野花椒</span>、<span>半枝莲</span>、<span>断血流</span></li>
                        <li><span>地瓜儿苗</span></li>
                    </ol>

                    <h3 id="C3">CⅢ区：</h3>
                    <ol class="res">
                        <li><span>枸杞</span>、<span>白英</span>、<span>洋金花</span></li>
                        <li><span>金钱松</span></li>
                        <li><span>天竺桂</span></li>
                        <li><span>丹参</span>、<span>金钱松</span></li>
                        <li><span>丹参</span></li>
                        <li><span>丹参</span>、<span>天竺桂</span></li>
                        <li><span>黄芩</span>、<span>金钱松</span></li>
                        <li><span>荆芥</span>、<span>金钱松</span></li>
                    </ol>

                    <h3 id="D1">DⅠ区：</h3>
                    <ol class="res">
                        <li><span>仙鹤草</span>、<span>地榆</span>、<span>结香</span></li>
                        <li><span>仙鹤草</span>、<span>水杨梅（蔷薇科）</span>、<span>地榆</span>、<span>金樱子</span>、<span>薄荷</span></li>
                        <li><span>蛇含</span>、<span>芫花</span>、<span>蛇莓</span>、<span>结香</span>、<span>虎杖</span></li>
                        <li><span>翻白草</span>、<span>丹参</span>、<span>草莓</span>、<span>薄荷</span></li>
                    </ol>

                    <h3 id="D2">DⅡ区：</h3>
                    1.火棘、郁李<br />
                    2.金樱子、山莓、木瓜（观赏）<br />
                    3.郁李、木瓜（观赏）<br />
                    4.郁李、木瓜（观赏）<br />
                    5.木瓜（观赏）<br />
                    6.火棘<br />
                    <br />

                    <h3 id="D3">DⅢ区：</h3>
                    1.短梗箭头唐松草、毛茛<br />
                    2.白头翁、枇杷、山木通<br />
                    3.杨子毛茛、猫爪草、豹皮樟<br />
                    4.寿星桃、刺果毛茛<br />
                    5.寿星桃、刺果毛茛<br />
                    6.茜草、小叶栀子、豹皮樟<br />
                    7.瞿麦、寿星桃、麦蓝菜<br />
                    8.沙参<br />
                    <br />

                    <h3 id="E1">EⅠ区：</h3>
                    1.紫菀、续断、一种待定、虎皮楠<br />
                    2.金鸡菊、佩兰<br />
                    3.法国蒲公英、一枝黄花、三脉叶马兰<br />
                    4.风斗菜、虎皮楠<br />
                    <br />


                    <h3 id="E2">EⅡ区：</h3>
                    1.白术、薄荷<br />
                    2.白术、美国红栌、千里光<br />
                    3.美国红栌<br />
                    4.美国红栌<br />
                    5.美国红栌、红花<br />
                    6.蓍草、红花、阴地蒿<br />
                    <br />

                    <h3 id="E3">EⅢ区：</h3>
                    1.水飞蓟、续断、垂盆草、大蓟、黄花败酱、野茉莉<br />
                    2.水飞蓟<br />
                    3.野茉莉<br />
                    4.野茉莉<br />
                    5.野茉莉<br />
                    6.野茉莉<br />
                    7.野茉莉、二种待定、牡蒿、十字花科一种待定<br />
                    <br />

                    <h3 id="F1">FⅠ区：</h3>
                    1.紫藤、圆柏、山木通<br />
                    <br />

                    <h3 id="F2">FⅡ区：</h3>
                    1.杠板归<br />
                    2.八仙花<br />
                    3.红楝子、白芷<br />
                    4.伞形科二种、红楝子、柴胡<br />
                    5.防风、紫花前胡、白花前胡、八仙花<br />
                    6.白芷<br />
                    <br />

                    <h3 id="F3">FⅢ区：</h3>
                    1.灰灰菜、宝盖草、荭蓼<br />
                    2.辣蓼、荭蓼<br />
                    3.皂角<br />
                    4.皂角<br />
                    5.板兰根<br />
                    6.板兰根<br />
                    7.板兰根、皂角、辣根<br />
                    <br />

                    <h3 id="G1">GⅠ区：</h3>
                    1.凌宵、圆柏、米口袋、红花忍冬、金银花<br />
                    <br />

                    <h3 id="G2">GⅡ区：</h3>
                    1.黄花败酱、白蔹<br />
                    2.盘柱南五味、三叶木通、五叶木通、石楠<br />
                    3.威灵仙、白蔹、豹皮樟<br />
                    4.决明子、豹皮樟<br />
                    5.决明子、石楠<br />
                    6.锦鸡儿、苦参<br />
                    <br />

                    <h3 id="G3">GⅢ区：</h3>
                    1.木耳菜、薄荷<br />
                    2.地丁、山栀子、一种待定<br />
                    3.天竺桂<br />
                    4.山栀子<br />
                    5.山栀子<br />
                    6.苦参、天竺桂<br />
                    7.苦参、桔梗、山栀子<br />
                    8.接骨草<br />
                    <br />

                    <h3 id="H1">HⅠ区：</h3>
                    1.石蒜（二种）<br />
                    2.香港四照花、黄花菜、萱草、水仙、石蒜<br />
                    3.阔叶麦冬、狭叶麦冬、麦冬、水仙、万年青<br />
                    4.吉祥草<br />
                    <br />

                    <h3 id="H2">HⅡ区：</h3>
                    1.浙贝<br />
                    2.红叶桃、松叶百合<br />
                    3.松叶百合、美国红栌<br />
                    4.松叶百合、美国红栌<br />
                    5.松叶百合、枣<br />
                    6.松叶百合<br />
                    <br />

                    <h3 id="H3">HⅢ区：</h3>
                    1.长春花、光皮木瓜<br />
                    2.<br />
                    3.木荷<br />
                    4.<br />
                    5.光皮木瓜<br />
                    6.木荷<br />
                    7.光皮木瓜<br />
                    8.红旱莲、元宝草、珍珠菜、一种待定<br />
                    <br />

                    <h3>三、八卦外围</h3>
                    <h3 id="_1">一区：</h3>
                    1.黄檗、竹柏、芭蕉<br />
                    2.黄檗、厚朴<br />
                    3.天目木姜子、七叶树<br />
                    4.灯台树、山茱萸<br />
                    5.苍术、白术、木兰科一种、山茱萸、桔梗<br />
                    6.紫花前胡、四照花、山茱萸、桃、玄参<br />
                    7.丹参、续断、紫参<br />
                    <br />

                    <h3 id="_2">二区：</h3>
                    1.天目木姜子、千屈菜<br />
                    2.山核桃、樟树<br />
                    3.山核桃、樟树<br />
                    4.板栗、梓树<br />
                    5.牡丹<br />
                    6.牡丹<br />
                    7.芍药<br />
                    <br />

                    <h3 id="_3">三区：</h3>
                    1.火炭母、仙鹤草、败酱、虎杖、白芷、三叶木通、五叶木通、黄芩、牛蒡、鸢尾<br />
                    2.麦冬、臭牡丹<br />
                    3.万年青、阔叶麦冬、麦冬、茅莓、吉祥草<br />
                    4.苦丁茶、大别山五针松、乌药、卫矛、大蓟、地榆、刺柏、檵木<br />
                    5.牛蒡、节骨木、乌头、兰草、白术、狭叶十大功劳<br />
                    6.吴茱萸、漏斗花、兔儿伞、紫萁、续断、玉簪、胡颓子、虎杖<br />
                    7.石榴（二种）、木半夏<br />
                    8.小叶女贞、火棘、大叶柴胡、木瓜（观赏）<br />
                    <br />

                    <h3 id="_4">四区：</h3>
                    1.蕉芋、桂花<br />
                    2.月桂<br />
                    3.红豆杉、木兰科一种（八角茴香）、桂花<br />
                    4.无患子<br />
                    5.无患子<br />
                    6.吴茱萸、无花果、臭牡丹、臭梧桐、凌宵<br />
                    7.合欢、楤木<br />
                    <br />

                    <h3 id="_5">五区：</h3>
                    1.无患子、罗汉松<br />
                    2.大叶榉、结香、罗汉松、橘<br />
                    3.山栀子、大叶榉、石楠、结香、无患子、紫薇、臭大青<br />
                    4.芭蕉、红枫、结香、大叶榉、金丝桃、金丝梅、山桐子、六月雪<br />
                    5.石楠、大叶榉、山桐子、金丝桃、樟树<br />
                    6.国槐<br />
                    7.桂花<br />
                    <br />

                    <h3 id="_6">六区：</h3>
                    1.青枫、枸骨<br />
                    2.枸骨、锦葵<br />
                    3.枸骨、臭大青<br />
                    4.二种待定、枫香、臭大青、桃、枸骨、马棘<br />
                    <br />

                    <h3 id="_7">七区：</h3>
                    1.一种待定、八角金盘<br />
                    2.红毛五加、一种待定、金银木<br />
                    3.细柱五加、连翘<br />
                    4.三叶五加、连翘<br />
                    <br />

                    <h3 id="_8">八区：</h3>
                    1.菊花（一种）、连翘<br />
                    2.菊花（一种）、徽菊、贡菊、连翘<br />
                    3.菊花（一种）、徽菊、连翘<br />
                    4.菊花（二种）、亳菊、迎春花<br />
                    5.滁菊、松果菊、金光菊、刘寄奴、珍珠梅、三脉叶马兰<br />
                    <br />

                    <h3 id="_9">九区：</h3>
                    1.白及、月桂<br />
                    2.紫楠、大叶榉、白及、边翘<br />
                    3.华东楠、白及、大叶榉、无花果、边翘<br />
                    4.白及、楤木、边翘<br />
                    5.蜡梅<br />
                    <br />

                    <h3 id="_10">十区：</h3>
                    1.龙爪槐、蜡梅、金钟花<br />
                    2.杏、金钟花<br />
                    3.杏、一种待定、枣、金钟花<br />
                    4.杏、无患子、一种待定、金钟花<br />
                    5.杏、无患子、一种待定、金钟花<br />
                    6.桂花、金钟花<br />
                    <br />

                    <h3 id="_11">十一区：</h3>
                    1.樱花、柽柳、知母、甘草、桔梗、龙爪槐<br />
                    2.紫薇、茶梅<br />
                    3.紫薇、杏<br />
                    4.紫薇、杏<br />
                    5.深山含笑<br />
                    6.桂花、紫薇<br />
                    <br />

                    <h3 id="_12">十二区：</h3>
                    1.一种待定、青枫、日本樱花<br />
                    2.红枫<br />
                    3.红枫<br />
                    4.红枫<br />
                    5.昌花槭、深山含笑<br />
                    6.桂花、流苏、红枫<br />
                    <br />

                    <h3 id="_13">十三区：</h3>
                    1.贯众、井栏边草、狗脊蕨、半夏、蓬蘽、中华槭、冬青、醉鱼草、乌药、杜鹃、细叶香桂、圆锥绣球<br />
                    2.狗脊蕨、沙参、明党参、二种待定、八角枫、马棘<br />
                    3.狗脊蕨、京大戟、多花黄精、景天、茜草、一种待定、马棘<br />
                    4.狗脊蕨、乌头、草乌、宝铎草、细辛、重楼、金荞麦、三角槭、一种待定、枸杞<br />
                    5.乌头、雀梅、创花树、红花檵木、昌花槭<br />
                    6.桂花、柽柳、小叶女贞、葡萄<br />
                    <br />

                    <h3>三角Ⅰ区：</h3>
                    1.秋葵、蜀葵、丁香<br />
                    2.丁香<br />
                    3.丁香、夏天无、博落回<br />
                    <br />

                    <h3>三角Ⅱ区：</h3>
                    1.牡丹<br />
                    <br />

                    <h3>三角Ⅲ区：</h3>
                    1.芍药（二种）、红瑞木、茶梅、玫瑰、月季、天竺桂、桃<br />
                    <br />

                    <h3>铁塔Ⅰ区：</h3>
                    1.美人蕉、狭叶十大功劳<br />
                    <br />

                    <h3>铁塔Ⅱ区：</h3>
                    1.美人蕉、乌桕<br />
                    <br />

                    <h3>花窗区：</h3>
                    1.芭蕉、日本小檗、木半夏、金边麦冬、枸骨、梅（红梅）、金银花、石榴、葱莲、金钟花<br />
                    <br />

                    <h3>西边区：</h3>
                    1.日本樱花、杜鹃、枇杷、红花木莲、光皮木瓜、蜡梅、乳源木莲、海棠（二种）、香港四照花、石楠、梅（红梅）、辛夷、白玉兰、紫玉兰、五叶木通、何首乌、葫芦种一种、地不容、乐昌含笑、黄山含笑、深山含笑、箭麻、竹叶椒<br />
                    <br />

                    <h3>北边区：</h3>
                    1.日本小檗、桂花、麦冬、山茶、茶树、结香、山栀子、云实<br />
                    <br />

                    <h3>东边区：</h3>
                    1.构树、棕竹、通脱木、虎耳草、过路黄、垂盆草、紫竹、毛竹、白花地丁、碎米机、桃、七叶树、青桐、木芙蓉、侧柏、夹竹桃、圆柏、光皮桦、紫薇、乌桕、红花木莲、一种待定、金钱松、灯台树、紫荆、木槿、山杜英、油桐、杜仲、楝、合欢、吴茱萸、一种待定、杏、水杉、马尾松、李、樱桃、南酸枣、梨、槐、楝、香椿、红叶李、桃、柿树、甜槠、小叶女贞、女贞、苦李子、绵槠、杉木、山麻杆、桑、枫杨、毛樱桃、刺槐、青冈、枸橘、外松、盐肤木、芭蕉、日本小檗、栀子花、枇杷、白杜、虎杖、苎麻、淫羊藿<br />

                </div>
            </div>
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
        }
    </script>

</asp:Content>
