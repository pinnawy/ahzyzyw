<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Ahzyzyw.Web.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="ad_list">
        <div>
            <h3>在线留言</h3>
            <p>如果您对我们的产品<br />有兴趣请联系我们</p>
        </div>
        <div>
            <h3>
                联系我们</h3>
            <p>
                电话：0553-58888888<br />
                传真：0553-58888888</p>
        </div>
        <div>
            <h3>
                销售网络</h3>
            <p>
                上海、北京、广州、<br />
                福建、香港</p>
        </div>
        <div class="index_search">
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
                <input name="searchbutton" type="submit" id="searchbutton" value="" />
            </p>
            </form>
        </div>

    </div>

    <div class="clearfix">
    <div class="index-left">
      <div class="index-newproducts">
        <h2><span>推荐中药展示</span><a href="medicine.aspx"><img src="images/more.gif" alt="中医药资源" /></a></h2>
        <div class="websroll">
          <div id="LeftArr1" class="ScorllLeft1"></div>
          <div id="RightArr1" class="ScorllRight1"></div>
          <ul id="ScrollBox" class="clearfix">
            <li><a href="medicine.aspx" title="井口边草"><img src="resource/medicine/01.png" alt="井口边草" /><span>井口边草</span></a></li>
            <li><a href="medicine.aspx" title="银  杏"><img src="resource/medicine/02.png" alt="银  杏"  /><span>银  杏</span></a></li>
            <li><a href="medicine.aspx" title="马尾松"><img src="resource/medicine/03.png" alt="马尾松" /><span>马尾松</span></a></li>
            <li><a href="medicine.aspx" title="侧  柏"><img src="resource/medicine/04.png" alt="侧  柏"  /><span>侧  柏</span></a></li>
            <li><a href="medicine.aspx" title="粗  榧"><img src="resource/medicine/05.png" alt="粗  榧"  /><span>粗  榧</span></a></li>
            <li><a href="medicine.aspx" title="红豆杉"><img src="resource/medicine/06.png" alt="红豆杉" /><span>红豆杉</span></a></li>
            <li><a href="medicine.aspx" title="枫  杨"><img src="resource/medicine/07.png" alt="枫  杨" /><span>枫  杨</span></a></li>
            <li><a href="medicine.aspx" title="板  栗"><img src="resource/medicine/08.png" alt="板  栗"  /><span>板  栗</span></a></li>
            <li><a href="medicine.aspx" title="异叶天南星"><img src="resource/medicine/09.png" alt="异叶天南星" /><span>异叶天南星</span></a></li>
          </ul>
          <script language="javascript" type="text/javascript">
<!--              //--><![CDATA[//><!--
              var scrollPic_01 = new ScrollPic();
              scrollPic_01.scrollContId = "ScrollBox"; //内容容器ID
              scrollPic_01.arrLeftId = "LeftArr1"; //左箭头ID
              scrollPic_01.arrRightId = "RightArr1"; //右箭头ID
              scrollPic_01.frameWidth = 630; //显示框宽度
              scrollPic_01.pageWidth = 210; //翻页宽度
              scrollPic_01.speed = 10; //移动速度(单位毫秒，越小越快)
              scrollPic_01.space = 10; //每次移动像素(单位px，越大越快)
              scrollPic_01.autoPlay = true; //自动播放
              scrollPic_01.autoPlayTime = 3; //自动播放间隔时间(秒)
              scrollPic_01.initialize(); //初始化
              //--><!]]>
</script> 

 
        </div>
      </div>
      <div class="index-news">
        <h2><span>新闻中心</span><a href="news.html"><img src="images/more.gif" alt="新闻中心" /></a></h2>
        <ul>
          <li class="clearfix"><a href="news.html" title="未来几年北美聚酯纤维需求快速增长"><img src="images/index_NewsPic.jpg" alt="未来几年北美聚酯纤维需求快速增长" width="110" height="80" /></a>
            <h3><a href="news.html" title="未来几年北美聚酯纤维需求快速增长">未来几年北美聚酯纤维需求快...</a></h3>
            <p>　　据英国PCI二甲苯和聚酯公司高级咨询师MichaelBermish日前表示，受包括服装、...<a href="news.html" title="未来几年北美聚酯纤维需求快速增长">[详细]</a></p>
          </li>
          <li><a href="news.html" title="江苏化工企业接受环境风险全面排查"><span>2011/6/11</span>-　江苏化工企业接受环境风险全面排查</a></li>
          <li><a href="news.html" title="资源税飙升稀土价格面临再次上涨"><span>2011/6/11</span>-　资源税飙升稀土价格面临再次上涨</a></li>
          <li><a href="news.html" title="煤炭煤化工机会凸显"><span>2011/6/10</span>-　煤炭煤化工机会凸显</a></li>
          <li><a href="news.html" title="德国巴斯夫三峡库区化工项目开建在即"><span>2011/6/10</span>-　德国巴斯夫三峡库区化工项目开建在即</a></li>
        </ul>
      </div>
      <div class="index-about">
        <h2><span>关于我们</span><a href="single.html"><img src="images/more.gif" alt="关于我们" /></a></h2>
        <p><img src="images/index_AboutPic.jpg" alt="关于我们" width="145" height="181" /><a href="single.html" title="关于我们">　　上海网聚实业发展有限公司是以无机化工、有机化工、精细化工、香精香料、食品添加剂、医药原料及中间体等经营、销售为一体的高科技化工企业。公司位于上海市商业中心,交通十分便捷。<br />
          ...</a></p>
      </div>
      <div class="index-products">
        <h2><span>中药材展示</span><a href="medicine.aspx"><img src="images/more.gif" alt="产品展示" /></a></h2>
        <ul class="clearfix">
            <li><a href="medicine.aspx" title="侧  柏"><img src="resource/medicine/04.png" alt="侧  柏"  /><span>侧  柏</span></a></li>
            <li><a href="medicine.aspx" title="粗  榧"><img src="resource/medicine/05.png" alt="粗  榧"  /><span>粗  榧</span></a></li>
            <li><a href="medicine.aspx" title="红豆杉"><img src="resource/medicine/06.png" alt="红豆杉" /><span>红豆杉</span></a></li>
            <li><a href="medicine.aspx" title="枫  杨"><img src="resource/medicine/07.png" alt="枫  杨" /><span>枫  杨</span></a></li>
            <li><a href="medicine.aspx" title="板  栗"><img src="resource/medicine/08.png" alt="板  栗"  /><span>板  栗</span></a></li>
            <li><a href="medicine.aspx" title="异叶天南星"><img src="resource/medicine/09.png" alt="异叶天南星" /><span>异叶天南星</span></a></li>
        </ul>
      </div>
    </div>
    <div class="index-right">
      <div class="index-contact">
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
