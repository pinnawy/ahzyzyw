function initSelectedMenu() {
    ///<summary>初始化目录选中状态</summary>

    $("#index-Menu>li>a").each(function () {
        $(this).removeAttr("id");
    });
    
    var url = location.href;
    if (url.indexOf("index.aspx") > -1 || url.indexOf("news.aspx") > -1) {
        $("#IndexMenu").attr("id", "menu_selected");
    }
    else if (url.indexOf("medicine.aspx") > -1) {
        $("#MedicineMenu").attr("id", "menu_selected");
    }
    else if (url.indexOf("garden") > -1) {
        $("#GardenMenu").attr("id", "menu_selected");
    }
    else if (url.indexOf("study.aspx") > -1) {
        $("#StudyMenu").attr("id", "menu_selected");
    }
    else if (url.indexOf("produce.aspx") > -1) {
        $("#ProduceMenu").attr("id", "menu_selected");
    }
    else if (url.indexOf("specimen.aspx") > -1) {
        $("#SpecimenMenu").attr("id", "menu_selected");
    }
    else if (url.indexOf("service.aspx") > -1) {
        $("#ServiceMenu").attr("id", "menu_selected");
    }
}