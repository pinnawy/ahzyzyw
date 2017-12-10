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

    initMenuTab();
    initMenu("funcMenu");
    initMenu("partMenu");
    getResourceList(1);

    $('#searchbutton').click(function () {
        Medicine.PageNumber = 1;
        getResourceList(Medicine.PageNumber);
    });

    $('#query').keydown(function (e) {
        if (e.keyCode === 13) {
            var queryKeyWord = escape($.trim($('#query').val()));
            if (queryKeyWord.length !== 0) {
                Medicine.PageNumber = 1;
            }
            getResourceList(Medicine.PageNumber);
        }
    });
});

function getResourceList(pageNumber) {
    /// <summary>获取资源列表</summary>
    /// <param name='pageIndex'>页码</param>
    /// <param name='pageSize'>每页显示记录数</param>
    /// <param name='sortName'>排序名称</param>
    /// <param name='sortDir'>排序方向</param>
    /// <param name='queryKeyWord'>查询关键字(按资源名称查询)</param>

    var queryKeyWord = escape($.trim($('#query').val()));
    var funcID = $('#funcMenu li a[class=selected]').attr('funcID');
    var partID = $('#partMenu li a[class=selected]').attr('partID');
    // 查询参数
    var option = {
        PageNumber: pageNumber,
        PageSize: Medicine.PageSize,
        QueryKeyWord: queryKeyWord,
        PartID: Medicine.CurrentTab.startsWith("part") ? partID : "",
        FuncID: Medicine.CurrentTab.startsWith("func") ? funcID : ""
    };

    // 请求资源列表数据
    $.post("services/DigitalResource.ashx?", { action: 'GetDigitalResourceList', option: $.toJSON(option), recordCount: 0, timestamp: new Date().getTime() }, function (data) {
        data = eval('(' + data + ')');
        var itemArr = [];
        for (var index = 0; index < data.rows.length; index++) {
            var resItem = data.rows[index];
            var resDom = $(getResItemHTML(resItem, queryKeyWord));
            (function () {
                resDom.on("click", { item: resItem }, showMedicineDetail);
            })();
            itemArr.push(resDom);
        }
        var itemPanel = $("#resItems").empty();
        $.each(itemArr, function () {
            itemPanel.append(this);
        })

        if (data.total == 0) {
            $("#pager").hide();
            $("#resItems").append($("<p>该分类暂无资源</p>").css({ margin: '10px', 'font-size': '16px', 'font-family': '楷体' }));
        } else {
            $("#pager").show();
            // 重新加载分页控件
            initPager(pageNumber, parseInt(data.total / Medicine.PageSize + 1));
        }

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

function initMenuTab() {
    /// <summary>初始化目录TAB</summary>
    $("#tabMenu li a").click(function () {

        $("#tabMenu li a").removeAttr("class");
        $(this).attr('class', 'selected');

        var showPanelId = $(this).attr("for");
        Medicine.CurrentTab = showPanelId;
        $("#tabMenu li a").each(function () {
            var panelId = $(this).attr("for");
            panelId == showPanelId ? $("#" + panelId).show() : $("#" + panelId).hide();
        })

        getResourceList(1);

    });
}

function initMenu(menuId) {
    /// <summary>初始化目录</summary>

    $('#' + menuId + ' ul').hide();
    $('#' + menuId + ' li a').click(
    function () {
        $('#' + menuId + ' li a').removeAttr('class');
        $(this).attr('class', 'selected');

        getResourceList(1);

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

        if (ret == null) console && console.warn(imgUrl);

        var imageHtml = img.replace(/{Image}/gm, imgUrl)
            .replace(/{Title}/gm, (ret && ret.length > 1 ? ret[1] : imgUrl))
        imgPanel.append(imageHtml);
    });
    

    return imgPanel;
}

function showMedicineDetail(e) {
    var detailContent;
    if (typeof e === "string") {
        detailContent = e;
    } else {
        detailContent = $(this).clone();
    }

    var resItem = e.data.item;
    var medicen = detailContent.find("div.img").remove();

    // append images
    detailContent.append(getImagePanel(resItem.PlantImageList, "基原图"));
    detailContent.append(getImagePanel([resItem.Image], "药材图"));
    detailContent.append(getImagePanel(resItem.FakePicList, "伪品图片"));


    // block detail
    var itemPanel = $("#itemDetail");
    var itemContentPanel = itemPanel.find("#itemContent").css({
        maxHeight: $(window).height() - 150 + 'px',
    });
    itemContentPanel.html(detailContent);

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

