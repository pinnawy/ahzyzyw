/// <reference path="jquery/jquery-1.7.js" />
/// <reference path="common.js" />

// 资源页面全局变量
var Medicine = {
    // 当前页码
    PageNumber: 1,

    // 每页显示资源数
    PageSize: 8,

    // 植物资源模板
    ResItemTemplate: '<li> \
                            <h3 class="title ellipsis" title="{Title}">{CnName}</h3> \
                            <div class="img">\
                                <a title="{Title}"><img width=300 height=215 src="{Image}" alt="{Title}" /></a> \
                            </div>\
                            <p>【常用别名】{OtherName}</p>\
                            <p>{Description}</p> \
                        </li>',
    // 当前显示的tab页
    CurrentTab: "func"
};

// 加载分页控件
$(document).ready(function () {
    initMenu("funcMenu");
});

function getQueryResID() {
    /// <summary>获取资源ID参数值</summary>
    /// <return>资源ID，没有资源ID时为undefined</return>

    var idIdx = window.location.href.indexOf("res");
    if (idIdx > 0) {
        var resID = window.location.href.substring(idIdx + 4);
        return resID;
    }
}

function getSingleResource(resID) {
    /// <summary>获取单个资源详情</summary>
    /// <param name='resID'>资源ID</param>

    $.post("services/DigitalResource.ashx?", { action: 'GetResource', resID: resID, timestamp: new Date().getTime() }, function (data) {
        resItem = eval('(' + data + ')');

        var itemArr = [];
        var resDom = $(getResItemHTML(resItem, ""));
        (function () {
            resDom.on("click", { item: resItem }, showMedicineDetail);
        })();
        itemArr.push(resDom);

        var itemPanel = $("#resItems").empty();
        $.each(itemArr, function () {
            itemPanel.append(this);
        })

        resDom.click();
    });
}

function drawTraceMap(dataUrl) {
    /// <summary>加载路径地图</summary>
    /// <param name='dataUrl'>路径数据url</param>


    // 请求资源列表数据
    $.getJSON("resource/trace/" + dataUrl, function (data) {
        drawMap(data);
    });
}

function initPager(pageNumber, pageCount) {
    /// <summary>初始化分页控件</summary>
    /// <param name='pageNum'>当前页码</param>
    /// <param name='pageCount'>总页数</param>

    Medicine.PageNumber = pageNumber;
    $("#pager").pager({
        pagenumber: pageNumber,
        pagecount: pageCount,
        buttonClickCallback: getResourceList
    });
}

function getResItemHTML(resItem, keyword) {
    /// <summary>获取资源条目的HTML字符串</summary>
    keyword = unescape(keyword);
    var renderHtml = Medicine.ResItemTemplate
                  .replace(new RegExp("{CnName}", "g"), resItem.CnName)
                  .replace("{Description}", resItem.Description)
                  .replace("{OtherName}", resItem.OtherName || "无")

    if (keyword != '') {
        var reg = new RegExp(keyword, "gm");
        renderHtml = renderHtml.replace(reg, '<span style="color:red;">' + keyword + '</span>');
    }

    renderHtml = renderHtml.replace("{Image}", resItem.Image);
    renderHtml = renderHtml.replace(new RegExp("{Title}", "g"), resItem.CnName);

    return renderHtml
}

function initMenu(menuId) {
    /// <summary>初始化目录</summary>

    $('#' + menuId + ' ul').hide();
    $('#' + menuId + ' li a').click(
    function () {
        $('#' + menuId + ' li a').removeAttr('class');
        $(this).attr('class', 'selected');

        var traceDataUrl = $(this).attr("data");
        drawTraceMap(traceDataUrl)

        var checkElement = $(this).next();
        if ((checkElement.is('ul')) && (checkElement.is(':visible'))) {
            return false;
        }
        if ((checkElement.is('ul')) && (!checkElement.is(':visible'))) {
            $('#' + menuId + ' ul:visible').slideUp('normal');
            checkElement.slideDown('normal');
            return false;
        }
        return true;
    });

    $('#' + menuId + '>li>ul>li>a').first().click();

}

function getImagePanel(imgUrlArr, legend) {
    /// <summary>获取图片容器HTML</summary>

    if (imgUrlArr.length < 1)

        return "";

    var imgPanel = $('<div class="img"> \
         <h3>{Legend}</h3> \
         </div>'.replace(/{Legend}/gi, legend));

    var img = '<a title="{Title}"><img width=500 height=375 src="{Image}" alt="{Title}" /></br><span>{Title}</span></a>';
    $(imgUrlArr).each(function () {
        var imgUrl = this;
        var ret = /http.*[\d\.]+([^\d].*).jpg/gi.exec(imgUrl);

        if (ret == null) {
            console && console.warn(imgUrl);
        } else {
            var imageHtml = img.replace(/{Image}/gm, imgUrl).replace(/{Title}/gm, (ret && ret.length > 1 ? ret[1] : imgUrl))
            imgPanel.append(imageHtml);
        }
    }); 

    return imgPanel;
}

function showMedicineDetail(desc, img) {
    

    var title = desc.substr(0, desc.indexOf("</br>"));
    desc = desc.replace(title, "");

    // block detail
    var itemPanel = $("#itemDetail");
    var itemContentPanel = itemPanel.find("#itemContent").css({
        maxHeight: $(window).height() - 150 + 'px',
    });
    itemContentPanel.html('<h2>' + title + '</h2>' + desc + '<img src="' + img + '"/>');

    var top = ($(window).height() - itemPanel.height()) / 2 - 50;
    $.blockUI({
        message: itemPanel,
        css: {
            top: (top < 0 ? 30 : top) + 'px',
            left: ($(window).width() - itemPanel.width()) / 2 + 'px',
            width: '700px',
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




var large_image = document.createElement("img");
      
large_image.style.position = "absolute";
large_image.style.width = "800px";
large_image.style.height = "600px";
large_image.src = "no";
large_image.style.display = "none";
large_image.style.left = "50px";
large_image.style.top = "50px";
large_image.onclick = function(){
    large_image.style.display = "none";
	
	  
}
window.document.body.appendChild(large_image);
	  


function ComplexCustomOverlay(point, time, icon, image, desc){
    this._point = point;
    this._time = time;
    this._icon = icon;
    this._image = image;
    this._desc = desc;
	  
}
ComplexCustomOverlay.prototype = new BMap.Overlay();
ComplexCustomOverlay.prototype.initialize = function(map){
    this._map = map;
    var div = this._div = document.createElement("div");
    div.style.position = "absolute";
    div.style.zIndex = BMap.Overlay.getZIndex(this._point.lat);
    div.style.backgroundColor = "#EE5D5B";
    div.style.border = "1px solid #BC3B3A";
    div.style.color = "white";
    div.style.height = "18px";
    div.style.padding = "2px";
    div.style.lineHeight = "18px";
    div.style.whiteSpace = "nowrap";
    div.style.MozUserSelect = "none";
    div.style.fontSize = "12px"
    var span = this._span = document.createElement("span");
    span.style.display = "block";
    div.appendChild(span);
    span.appendChild(document.createTextNode(this._time));      
    var that = this;

    var icon_image = document.createElement("img");
      
    icon_image.style.position = "absolute";
    icon_image.style.width = "80px";
    icon_image.style.height = "60px";
    icon_image.src = that._icon;
    div.appendChild(icon_image);
     
    div.onmouseover = function(){
        this.style.backgroundColor = "#6BADCA";
        //this.style.borderColor = "#0000ff";
    }

    div.onmouseout = function(){
        this.style.backgroundColor = "#EE5D5B";
        // this.style.borderColor = "#BC3B3A";
    }
	  
	  
    icon_image.onclick = function(){
		
        showMedicineDetail(that._desc, that._image);
		
        //large_image.style.display="block";
        //large_image.src = that._image;
    }
    map.getPanes().labelPane.appendChild(div);
      
    return div;
}
	
ComplexCustomOverlay.prototype.draw = function(){
    var map = this._map;
    var pixel = map.pointToOverlayPixel(this._point);
    this._div.style.left = pixel.x + "px";
    this._div.style.top  = pixel.y - 30 + "px";
}
  

function drawMap(traceData) {

    $("#map").empty();

    var map = new BMap.Map("map");
    window.map = map;
    var point = new BMap.Point(118.01480865,30.81830597);
	 
    // 地图类型
    map.addControl(new BMap.MapTypeControl({
        mapTypes:[
			BMAP_SATELLITE_MAP,
            BMAP_NORMAL_MAP,
            BMAP_HYBRID_MAP
        ]}));	

    map.addControl(new BMap.NavigationControl());               // 添加平移缩放控件
    //     map.addControl(new BMap.ScaleControl());                    // 添加比例尺控件
    //     map.addControl(new BMap.OverviewMapControl());              //添加缩略地图控件
    //     map.enableScrollWheelZoom();                            //启用滚轮放大缩小
    //     map.addControl(new BMap.MapTypeControl());          //添加地图类型控件
    //     map.disable3DBuilding();
    map.centerAndZoom(point, 15);
    //map.setMapStyle({style:'dark'});

    //     var marker = new BMap.Marker(point);  // 创建标注
    //    map.addOverlay(marker);               // 将标注添加到地图中
	 
    //  marker.setAnimation(BMAP_ANIMATION_BOUNCE); //跳动的动画


    var images = traceData["images"];
    for (var i = 0; i < images.length; i++) {
        var img= images[i];
        var coodrInfo = img["coord"].split(",");
        var desc = img["desc"];
        if (desc) {
            desc = desc.replace(/【/ig, '</br>【');
            var myCompOverlay = new ComplexCustomOverlay(new BMap.Point(coodrInfo[0], coodrInfo[1]), img["name"], "resource/trace/trace1/" + img["icon"], "resource/trace/trace1/" + img["src"], desc);
            map.addOverlay(myCompOverlay);
        }
    }


    var pois = [];
    var points = traceData["points"];
    for (var i = 0; i < points.length; i++) {
        var coodrInfo = points[i].split(",");
        pois.push(new BMap.Point(coodrInfo[0],coodrInfo[1]));
    }


    var polyline =new BMap.Polyline(pois,{strokeColor:"blue", strokeWeight:2, strokeOpacity:0.5});

    map.addOverlay(polyline); 
	
	
	
}
 

