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
                            <h3 class="title ellipsis" title="{CnName}{EnName}（{Family}{Genus}）">{CnName}{EnName}（{Family}{Genus}）</h3> \
                            <div class="img">\
                                <a title="{CnName}"><img src="{Image}" alt="{CnName}" /></a> \
                            </div>\
                            <p><span>【别名】</span>{OtherName}</p>\
                            <p>{Description}</p> \
                        </li>'
};

// 加载分页控件
$(document).ready(function () {
    initMenu();
    getResourceList(1);

    $('#searchbutton').click(function() {
        getResourceList(Medicine.PageNumber);
    });

    $('#query').keydown(function (e ) {
        if(e.keyCode === 13) {
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
     /// <param name='categroyID'>资源分类</param>
     
     var queryKeyWord = escape($('#query').val());
     var categroyID = $('#menu li a[class=selected]').attr('cateID');
     // 查询参数
     var option = {
         PageNumber: pageNumber,
         PageSize: Medicine.PageSize,
         QueryKeyWord: queryKeyWord,
         CategroyID: categroyID
     };
     
     // 请求资源列表数据
     $.post("Services/Resource.ashx?", { action: 'GetResourceList', option: $.toJSON(option), recordCount: 0, timestamp: new Date().getTime() }, function (data) {
         data = eval('(' + data + ')');
         var items = '';
         for (var index = 0; index < data.rows.length; index++) {
             var resItem = data.rows[index];
             items += Medicine.ResItemTemplate
                 .replace(new RegExp("{CnName}", "g"), resItem.CnName)
                 .replace(new RegExp("{EnName}", "g"), resItem.EnName)
                 .replace(new RegExp("{Family}", "g"), resItem.Family)
                 .replace(new RegExp("{Genus}", "g"), resItem.Genus)
                 .replace("{Description}", resItem.Description)
                 .replace("{OtherName}", resItem.OtherName)
                 .replace("{Image}", resItem.Image);
         }

         items = $(items);
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
    var itemPanel = $("#itemDetail");
    var img = e.data.img;
    itemPanel.find("#itemContent").html($(img).parent().parent().parent().clone());
    
    $.blockUI({
        message: itemPanel,
        css: {
            top: ($(window).height() - itemPanel.height()) / 2 + 'px',
            left: ($(window).width() - itemPanel.width()) / 2 + 'px',
            width: '600px',
            fadeIn: 700,
            fadeOut: 700,
            cursor:'normal'
        },
        overlayCSS: {
            cursor: 'normal'
        }
    });

    $('.blockOverlay').click($.unblockUI);
}
