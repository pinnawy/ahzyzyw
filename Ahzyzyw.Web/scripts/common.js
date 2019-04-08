//排序方向
var SortDir = {
    // 升序
    ASC: 'ASC',
    
    // 降序
    DESC: 'DESC'
};

// 药用资源状态
var ResourceState =
{
    // 无状态
    None: 0x00,

    // 推荐资源
    Recommend: 0x01,

    // 属于药苑资源
    InGarden: 0x02
};

Date.prototype.format = function(formatString, fullTimeString) {
    /// <summary>格式化日期</summary>
    /// <param name="formatString" type="string">格式化字符串</param>
    /// <param name="fullTimeString" type="bool">是否显示完整日期格式</param>

    var date = new Date(this.getTime());
    var month = date.getMonth() + 1;
    var day = date.getDate();
    var hour = date.getHours();
    var minute = date.getMinutes();
    var second = date.getSeconds();

    return formatString
        .replace("yyyy", date.getFullYear())
        .replace("MM", month < 10 && fullTimeString ? '0' + month : month)
        .replace("dd", day < 10 && fullTimeString ? '0' + day : day)
        .replace("HH", hour < 10 && fullTimeString ? '0' + hour : hour)
        .replace("mm", minute < 10 && fullTimeString ? '0' + minute : minute)
        .replace("ss", second < 10 && fullTimeString ? '0' + second : second);
};
 

function isMobile() {
    var ua = navigator.userAgent;
    var ipad = ua.match(/(iPad).*OS\s([\d_]+)/),
    isIphone = !ipad && ua.match(/(iPhone\sOS)\s([\d_]+)/),
    isAndroid = ua.match(/(Android)\s+([\d.]+)/);
    return isIphone || isAndroid;
}
