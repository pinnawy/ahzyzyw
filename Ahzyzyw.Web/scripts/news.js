/// <reference path="jquery/jquery-1.7.js" />
/// <reference path="common.js" />

// 资源页面全局变量
var News = {
    // 当前页码
    PageNumber: 1,

    // 每页显示资源数
    PageSize: 10,

    // 植物资源模板
    NewsTtileItemTemplate: ' <tr> \
            <td class="time-list"><span>{PublishTime}</span></td> \
            <td ><a href="newsdetail.aspx?newsId={NewsId}" title="{Title}">{Title}</a></td> \
          </tr>'
};

// 加载分页控件
$(document).ready(function () {
    getNewsList(1);

    $('#searchbutton').click(function() {
        getNewsList(News.PageNumber);
    });

    $('#query').keydown(function (e ) {
        if(e.keyCode === 13) {
            getNewsList(News.PageNumber);
        }
    });
});

function getNewsList(pageNumber) {
     /// <summary>获取新闻列表</summary>
     /// <param name='pageIndex'>页码</param>
     /// <param name='pageSize'>每页显示记录数</param>
     /// <param name='queryKeyWord'>查询关键字(按新闻标题名称查询)</param>
     
     var queryKeyWord = escape($('#query').val());
     // 查询参数
     var option = {
         PageNumber: pageNumber,
         PageSize: News.PageSize,
         QueryKeyWord: queryKeyWord
     };

     $("#news_items").append("新闻列表加载中....");
    
     // 请求资源列表数据
     $.post("Services/News.ashx", { action: 'GetNewsList', option: $.toJSON(option), recordCount: 0, timestamp: new Date().getTime() }, function (data) {
         data = eval('(' + data + ')');
         var items = '';

         for (var index = 0; index < data.rows.length; index++) {
             var newsItem = data.rows[index];
             items += News.NewsTtileItemTemplate
                 .replace(new RegExp("{PublishTime}", "g"), newsItem.PublishTime.format("yyyy/MM/dd",true))
                 .replace(new RegExp("{Title}", "g"), newsItem.Title)
                 .replace(new RegExp("{NewsId}", "g"), newsItem.NewsId);
         }

         items = $(items);

         $("#news_items").empty();
         $("#news_items").append(items);

        $("#pager").show();
        // 重新加载分页控件
        initPager(pageNumber, parseInt(data.total / News.PageSize + 1));
     });
 }

 function initPager(pageNumber, pageCount) {
     /// <summary>初始化分页控件</summary>
     /// <param name='pageNum'>当前页码</param>
     /// <param name='pageCount'>总页数</param>

     News.PageNumber = pageNumber;
     $("#pager").pager({
         pagenumber: pageNumber,
         pagecount: pageCount,
         buttonClickCallback: getNewsList
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

