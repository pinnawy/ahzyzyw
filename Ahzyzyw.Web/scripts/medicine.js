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
                            <h3 class="title ellipsis" title="{Title}">{CnName}{EnName}（{Family}{Genus}）</h3> \
                            <div class="img">\
                                <a title="{Title}"><img width=300 height=215 src="{Image}" alt="{Title}" /></a> \
                            </div>\
                            <p><span>【别名】</span>{OtherName}</p>\
                            <p>{Description}</p> \
                        </li>'
};

// 加载分页控件
$(document).ready(function () {

    initMenu();


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

    if (resId) {
        getSingleResource(resId);
    } else {
        getResourceList(1);
    }
});


function getSingleResource(resID) {
    /// <summary>获取单个资源详情</summary>
    /// <param name='resID'>资源ID</param>

    $.post("services/Resource.ashx?", { action: 'GetResource', resID: resID, timestamp: new Date().getTime() }, function (data) {
        resItem = eval('(' + data + ')');

        var itemPanel = $("#resItems").empty();
        if (!resItem) {
            itemPanel.append("没有找到对应资源...");
        } else {

            var itemArr = [];
            var resDom = $(getResItemHTML(resItem, ""));
            (function () {
                var img = resDom.find("img");
                img.on("click", { img: img }, showMedicineDetail);
            })();
            itemArr.push(resDom);
            itemPanel.append(resDom);
            resDom.find("img").click();
        }
    });
}


function getResourceList(pageNumber) {
    /// <summary>获取资源列表</summary>
    /// <param name='pageIndex'>页码</param>
    /// <param name='pageSize'>每页显示记录数</param>
    /// <param name='sortName'>排序名称</param>
    /// <param name='sortDir'>排序方向</param>
    /// <param name='queryKeyWord'>查询关键字(按资源名称查询)</param>
    /// <param name='CategoryID'>资源分类</param>

    var queryKeyWord = escape($.trim($('#query').val()));
    var CategoryID = $('#menu li a[class=selected]').attr('cateID');
    // 查询参数
    var option = {
        PageNumber: pageNumber,
        PageSize: Medicine.PageSize,
        QueryKeyWord: queryKeyWord,
        CategoryID: CategoryID
    };

    // 请求资源列表数据
    $.post("Services/Resource.ashx?", { action: 'GetResourceList', option: $.toJSON(option), recordCount: 0, timestamp: new Date().getTime() }, function (data) {
        data = eval('(' + data + ')');
        var itemArr = [];
        for (var index = 0; index < data.rows.length; index++) {
            var resItem = data.rows[index];
            itemArr.push(getResItemHTML(resItem, queryKeyWord));
        }

        items = $(itemArr.join(''));
        items.find("img").each(function () {
            $(this).on("click", { img: this }, showMedicineDetail);
        });
        $("#resItems").empty();
        $("#resItems").append(items);

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
                  .replace(new RegExp("{EnName}", "g"), resItem.EnName)
                  .replace(new RegExp("{Family}", "g"), resItem.Family)
                  .replace(new RegExp("{Genus}", "g"), resItem.Genus)
                  .replace("{Description}", resItem.Description)
                  .replace("{OtherName}", resItem.OtherName || "无")
                  .replace("{Image}", resItem.Image);

    if (keyword != '') {
        var reg = new RegExp(keyword, "gm");

        renderHtml = renderHtml.replace(reg, '<span style="color:red;">' + keyword + '</span>');
    }

    renderHtml = renderHtml.replace(new RegExp("{Title}", "g"), [resItem.CnName, ' ', resItem.EnName, '(', resItem.Family, resItem.Genus, ')'].join(''));

    return renderHtml
}

function initMenu() {
    /// <summary>初始化目录</summary>

    $('#menu ul').hide();
    $('#menu ul:first').show();
    $('#menu li a').click(
    function () {
        $('#menu li a').removeAttr('class');
        $(this).attr('class', 'selected');

        getResourceList(1);

        var checkElement = $(this).next();
        if ((checkElement.is('ul')) && (checkElement.is(':visible'))) {
            return false;
        }
        if ((checkElement.is('ul')) && (!checkElement.is(':visible'))) {
            $('#menu ul:visible').slideUp('normal');
            checkElement.slideDown('normal');
            return false;
        }
        return true;
    });
}

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

    var size = {};
    var mobile = isMobile();
    if (mobile) {
        itemPanel.css("width", "100%");
        var img = itemPanel.find('img');
        img.css({ width: "600px", height: "430px" });
        size = {
            top: 0,
            left: 0,
            font: 30
        }
    } else {
        size = {
            top: ($(window).height() - itemPanel.height()) / 2 - 50,
            left: ($(window).width() - itemPanel.width()) / 2,
            width: 600,
            font: 16
        }
    }

    $.blockUI({
        message: itemPanel,
        css: {
            top: size.top + 'px',
            left: size.left + 'px',
            width: mobile ? "100%" : size.width + 'px',
            fadeIn: 700,
            fadeOut: 700,
            fontSize: size.font + 'px',
            border: mobile ? "0px" : "3px solid rgb(170, 170, 170)",
            cursor: 'normal'
        },
        overlayCSS: {
            cursor: 'normal'
        }
    });

    $('.blockOverlay').click($.unblockUI);
}