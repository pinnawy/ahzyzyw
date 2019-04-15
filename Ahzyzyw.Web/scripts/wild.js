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

function drawTraceMap(dataUrl) {
    /// <summary>加载路径地图</summary>
    /// <param name='dataUrl'>路径数据url</param>


    // 请求资源列表数据
    $.getJSON("resource/trace/" + dataUrl, function (data) {
        drawMap(data);
    });
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

function showMedicineDetail(desc, img, w, h) {


    var title = desc.substr(0, desc.indexOf("</br>"));
    desc = desc.replace(title, "");

    // block detail
    var itemPanel = $("#itemDetail");
    var itemContentPanel = itemPanel.find("#itemContent").css({
        maxHeight: $(window).height() - 100 + 'px',
    });
    itemContentPanel.html('<h2>' + title + '</h2><div style="padding:5px; text-align: center;"><img src="' + img + '"/></div>' + desc);
    var img = itemPanel.find('img');

    var size = {};
    if (isMobile()) {
        itemPanel.css("width", "100%");
        size = {
            top: 0,
            left: 0,
            font: 30
        }
    } else {
        itemPanel.css("width", "800px");


        size = {
            top: 30,
            left: ($(window).width() - itemPanel.width()) / 2,
            width: itemPanel.width(),
            font: 16
        }
    }

    var imgW = itemPanel.width() - 40;
    var imgH = imgW / w * h;
    img.css({ width: imgW + "px", height: imgH + "px" });

    $.blockUI({
        message: itemPanel,
        css: {
            top: size.top + 'px',
            left: size.left + 'px',
            width: !size.width ? "100%" : size.width + 'px',
            fadeIn: 700,
            fadeOut: 700,
            fontSize: size.font + 'px',
            cursor: 'normal'
        },
        overlayCSS: {
            cursor: 'normal'
        }
    });

    $('.blockOverlay').click($.unblockUI);
}



function ComplexCustomOverlay(point, time, icon, image, imageW, imageH, desc) {
    this._point = point;
    this._time = time;
    this._icon = icon;
    this._image = image;
    this._imageW = imageW;
    this._imageH = imageH;
    this._desc = desc;

}
ComplexCustomOverlay.prototype = new BMap.Overlay();
ComplexCustomOverlay.prototype.initialize = function (map) {
    this._map = map;
    var div = this._div = document.createElement("div");
    div.style.position = "absolute";
    div.style.zIndex = BMap.Overlay.getZIndex(this._point.lat);


    //div.style.height = "18px";
    //div.style.padding = "2px";
    //div.style.lineHeight = "18px";
    //div.style.whiteSpace = "nowrap";
    //div.style.MozUserSelect = "none";
    //div.style.fontSize = "12px"
    //div.style.color = "#1181d1";
    //var span = this._span = document.createElement("span");
    //span.style.backgroundColor = "#eee";


    //span.style.fontWeight = "bold";
    //span.style.display = "block";
    //span.style.marginLeft = "-25px";
    //span.style.position = "relative";
    //span.style.left = "-15px";
    //span.style.top = "40px";
    //span.style.zIndex = "10";

    //div.appendChild(span);
    //span.appendChild(document.createTextNode(this._time));
    var that = this;

    var icon_image = document.createElement("img");

    icon_image.style.position = "relative";
    icon_image.style.width = "32px";
    icon_image.style.height = "32px";
    icon_image.style.cursor = "default";
    icon_image.style.top = "-16px";
    //icon_image.src = that._icon;
    icon_image.src = "images/pin.png";
    div.appendChild(icon_image);

    icon_image.onmouseover = function () {
        this.style.width = "36px";
        this.style.height = "36px";
        //this.style.left = "-6px";
        //this.style.top = "-6px";
    }

    icon_image.onmouseout = function () {
        this.style.width = "32px";
        this.style.height = "32px"
        //this.style.left = "0px";
        //this.style.top = "0px";
    }

    icon_image.onclick = function () {
        showMedicineDetail(that._desc, that._image, that._imageW, that._imageH);
    }

    icon_image.ontouchend = function () {
        showMedicineDetail(that._desc, that._image, that._imageW, that._imageH);
    }


    map.getPanes().labelPane.appendChild(div);

    return div;
}

ComplexCustomOverlay.prototype.draw = function () {
    var map = this._map;
    var pixel = map.pointToOverlayPixel(this._point);
    this._div.style.left = pixel.x + "px";
    this._div.style.top = pixel.y + "px";
}


function drawMap(traceData) {
    /// <summary>绘制路径地图</summary>


    var map;

    if (isMobile()) {
        var detailPanel = $("#itemDetail").clone();
        $("body").find("div").remove();
        $("body").css({ height: $(window).height() });
        $("body").append('<div id="fullMap" style="width: 100%; height:100%;"/>').append(detailPanel);
        map = new BMap.Map("fullMap");
    } else {
        $("#map").empty();
        map = new BMap.Map("map");
    }

    window.map = map;

    var points = traceData["points"];
    var center = getCenterPoint(points);

    //var point = new BMap.Point(center.lon, center.lat);
    var point = new BMap.Point(118.01480865, 30.81830597);

    // 地图类型
    map.addControl(new BMap.MapTypeControl({
        mapTypes: [
			BMAP_SATELLITE_MAP,
            BMAP_NORMAL_MAP,
            BMAP_HYBRID_MAP
        ]
    }));

    map.addControl(new BMap.NavigationControl());               // 添加平移缩放控件
    //     map.addControl(new BMap.ScaleControl());                    // 添加比例尺控件
    //     map.addControl(new BMap.OverviewMapControl());              //添加缩略地图控件
    //     map.enableScrollWheelZoom();                            //启用滚轮放大缩小
    //     map.addControl(new BMap.MapTypeControl());          //添加地图类型控件
    //     map.disable3DBuilding();
    map.centerAndZoom(point, 15);
    //map.setMapStyle({style:'dark'});

    // var marker = new BMap.Marker(point);  // 创建标注
    // map.addOverlay(marker);               // 将标注添加到地图中

    //  marker.setAnimation(BMAP_ANIMATION_BOUNCE); //跳动的动画

    // 绘制图片点
    var images = traceData["images"];
    var imgBDps = traceData["imgBDps"];
    if (imgBDps) {
        drawImagePoints(imgBDps, images, map);
    } else {
        var imgPois = [];
        for (var i = 0; i < images.length; i++) {
            var img = images[i];
            var coodrInfo = img["coord"].split(",");
            imgPois.push(new BMap.Point(coodrInfo[0], coodrInfo[1]));
        }
        var imgConvPois = [];
        convertPoints(imgPois, imgConvPois, 0, function (imgConvPois) {
            drawImagePoints(imgConvPois, images, map);
        })
    }

    var pois = [];
    for (var i = 0; i < points.length; i++) {
        var coodrInfo = points[i].split(",");
        pois.push(new BMap.Point(coodrInfo[0], coodrInfo[1]));
    }

    // 绘制采药路径
    var traceBDps = traceData["traceBDps"];

    traceBDps = null;
    if (traceBDps) {

        var polyline = new BMap.Polyline(pois, { strokeColor: "blue", strokeWeight: 2, strokeOpacity: 0.5 });
        map.addOverlay(polyline);

    } else {
       
        var convPois = [];
        convertPoints(pois, convPois, 0, function (convPois) {

            var tbdps = traceData["traceBDps"];
            for (var i = 0; i < convPois.length; i++) {
                console.log((convPois[i].lng === tbdps[i].lng) && (convPois[i].lat === tbdps[i].lat));
            }

            console.dir(convPois)
            var polyline = new BMap.Polyline(convPois, { strokeColor: "blue", strokeWeight: 2, strokeOpacity: 0.5 });
            map.addOverlay(polyline);
        })
    }
}

var CONVERT_MAX_COUNT = 10;

function convertPoints(points, convPois, currIdx, callback) {
    var pois = [];
    var convertor = new BMap.Convertor();
    for (var i = currIdx; i < points.length; i++) {
        pois.push(points[i]);

        if ((i + 1) % CONVERT_MAX_COUNT == 0 || i == (points.length - 1)) {
            convertor.translate(pois, 1, 5, function (data) {
                //console && console.dir(data);
                if (data.status === 0) {
                    convPois = convPois.concat(data["points"]);

                    if (convPois.length == points.length) {
                        callback && callback.call(this, convPois);
                    } else {
                        convertPoints(points, convPois, i + 1, callback);
                    }

                }
            });

            break;
        }
    }
}

function drawImagePoints(imgBDps, images, map) {
    /// <summary>绘制图片点</summary>
    /// <param name='imgBDps'>图片BD坐标点列表</param>
    /// <param name='images'>原始图片信息列表</param>
    /// <param name='map'>地图对象</param>

    for (var i = 0; i < imgBDps.length; i++) {
        var img = images[i];
        var desc = img["desc"];
        if (desc) {
            desc = desc.replace(/【/ig, '</br>【');
            var myCompOverlay = new ComplexCustomOverlay(imgBDps[i], img["name"], "resource/trace/trace1/" + img["icon"], "resource/trace/trace1/" + img["src"], img["w"], img["h"], desc);
            map.addOverlay(myCompOverlay);
        }
    }

}


function getCenterPoint(points) {
    /// <summary>获取路径中心点坐标</summary>

    var cood = points[0].split(",");

    var n = cood[1],
        s = cood[1],
        w = cood[0],
        e = cood[0];

    for (var i = 1; i < points.length; i++) {
        cood = points[i].split(",");
        if (cood[0] < w) {
            w = cood[0];
        }

        if (cood[0] > e) {
            e = cood[0];
        }

        if (cood[1] > n) {
            n = cood[1];
        }

        if (cood[1] < s) {
            s = cood[1]
        }
    }

    return { lon: w + (e - w) / 2, lat: s + (n - s) / 2 }
}