/// <reference path="jquery/jquery-1.7.js" />
/// <reference path="../ckeditor/ckeditor.js" />
/// <reference path="common.js" />

var cateUrl = "../services/Resource.ashx?action=GetSubCategorys";

$(function () {
    $('#resGrid').datagrid({
        title: '资源列表',
        loadMsg: '正在加载，请稍后...',
        iconCls: 'icon-res',
        queryParams: { 'action': 'GetResourceList', 'option': {}, 'recordCount': 0 },
        singleSelect: true,
        nowrap: false,
        pagination: true,       // 分页
        rownumbers: true,       // 行号
        striped: true,          // 分割线
        pageNumber: 1,
        pageSize: 10,
        sortName: 'CreateTime',
        sortOrder: 'desc',
        collapsible: true,
        url: '../Services/Resource.ashx',
        frozenColumns: [[{ field: 'ck', checkbox: true}]],
        columns: [[
    	        { field: 'CnName', title: '中文名称', width: 120, align: 'center', sortable: true },
    	        { field: 'EnName', title: '英文名称', width: 180, align: 'center', sortable: true },
    	        { field: 'CreateTime', title: '创建时间', width: 110, align: 'center', sortable: true,
    	            formatter: function (value) {
    	                return '<span>' + value.format("yyyy-MM-dd HH:mm", true) + '</span>';
    	            }
    	        },
    	        { field: 'Creator', title: '添加人', width: 100, align: 'center' },
    	        { field: 'Family', title: '科', width: 100, align: 'center' },
    	        { field: 'Genus', title: '属', width: 100, align: 'center' },
    	        { field: 'State', title: '状态', width: 100, align: 'center', sortable: true,
    	            formatter: function (value) {
    	                var status = '正常';
    	                if (value & ResourceState.Recommend == ResourceState.Recommend) {
    	                    status = '推荐资源';
    	                }
    	                return '<span>' + status + '</span>';
    	            }
    	        },
    	        { field: 'opt', title: '操作', width: 100, align: 'center',
    	            formatter: function (value, rec) {
    	                return "<span> \
        	                        <a href='javascript:void(0);' onclick='etidResource(" + $.toJSON(rec) + ")'>编辑</a>\
        	                        <a href='javascript:void(0);' onclick='deleteResource(" + $.toJSON(rec) + ")'>删除</a> \
                                </span>";
    	            }
    	        }
    	    ]],
        toolbar: [{
            id: 'btnadd',
            text: '添加资源',
            iconCls: 'icon-add',
            handler: function () {
                $('#addResWin').window('open');
            }
        }, {
            id: 'btndelete',
            text: '删除资源',
            iconCls: 'icon-cancel',
            handler: function () {
                var ids = [];
                var cnNames = [];
                var rows = $('#resGrid').datagrid('getSelections');
                for (var i = 0; i < rows.length; i++) {
                    ids.push(rows[i].ResID);
                    cnNames.push(rows[i].CnName);
                }
                if (ids.length < 1) {
                    $.messager.alert('提示', '请选择要删除的资源');
                } else {
                    $.messager.confirm('确认', '你确定要删除下列资源么?</br>' + cnNames.join('、'), function (r) {
                        if (r) {
                            alert('confirmed:' + r);
                        }
                    });
                }
            }
        }, '-', {
            id: 'btnsave',
            text: 'Save',
            disabled: true,
            iconCls: 'icon-save',
            handler: function () {
                $('#btnsave').linkbutton('disable');
                alert('save');
            }
        }],
        onBeforeLoad: function (params) {
            params.option.pageNumber = params.page;
            params.option.pageSize = params.rows;
            params.option.SortName = params.sort;
            params.option.SortDir = params.order;
            params.option = $.toJSON(params.option);
            delete params.page;
            delete params.rows;
            delete params.sort;
            delete params.order;
        }
    });

    var pager = $('#resGrid').datagrid('getPager');
    $(pager).pagination({
        pageList: [10, 15, 20, 25],
        onSelectPage: function (pageNumber, pageSize) {
            var grid = $('#resGrid');
            var queryParams = grid.datagrid('options').queryParams;
            queryParams.page = pageNumber;
            queryParams.rows = pageSize;
            grid.datagrid('load', queryParams);
        }
    });

    setTimeout(function () {
        CKEDITOR.replace('Description', {
            customConfig: '../ckeditor/config.js',
            toolbar: 'Ahzyzyw'
        });

        $('#addResWin').window('options').onClose = function () {
            $('#resForm').form('clear');
            $('#resImage').attr('src', '../images/resDefaultImage.jpg');
            CKEDITOR.instances.Description.setData("");
        };


        $('#cmbCateID').combotree({
            url: cateUrl + "&cateID=",
            onBeforeLoadSuccess: function (data) {
                var tree = [];
                for (var i = 0; i < data.length; i++) {
                    var cate = data[i];
                    var node = {
                        "id": cate.CategoryID,
                        "text": cate.CnTitle,
                        "attributes": {
                            "url": cateUrl + "&cateID=" + cate.CategoryID
                        }
                    };

                    if (cate.HasSubCategory) {
                        node.state = "closed";
                    }

                    tree.push(node);
                }
                return tree;
            },
            onBeforeLoad: function (node, params) {
                if (node && node.attributes && node.attributes.url) {
                    params.cateID = params.id;
                    $('#cmbCateID').combotree('tree').tree('options').url = node.attributes.url;
                    delete params.id;
                }
            }
        });

        $('#content').tabs({
            onSelect: function (title) {
                $(this).tabs('getTab', title);
            }
        });

        $('#resCateTree').tree({
            url: cateUrl + "&cateID=",
            onClick: function (node) {
                $(this).tree('toggle', node.target);
                //alert('you click '+node.text);
            },
            onContextMenu: function (e, node) {
                e.preventDefault();
                $(this).tree('select', node.target);
                $('#mm').menu('show', {
                    left: e.pageX,
                    top: e.pageY
                });
            },
            onBeforeLoadSuccess: function (data) {
                var tree = [];
                for (var i = 0; i < data.length; i++) {
                    var cate = data[i];
                    var node = {
                        "id": cate.CategoryID,
                        "text": cate.CnTitle + (cate.EnTitle ? '(' + cate.EnTitle + ')' : ''),
                        "attributes": {
                            "url": cateUrl + "&cateID=" + cate.CategoryID,
                            cate: cate
                        }
                    };

                    if (cate.HasSubCategory) {
                        node.state = "closed";
                    }

                    tree.push(node);
                }
                return tree;
            },
            onBeforeLoad: function (node, params) {
                if (node && node.attributes && node.attributes.url) {
                    params.cateID = params.id;
                    $('#resCateTree').tree('options').url = node.attributes.url;
                    delete params.id;
                }
            },
            onSelect: function (node) {
                $("#selectedCate").text(node.text);
                $('#cateForm').form('load', node.attributes.cate);

                $('#btnAddCate').hide();
                $('#btnEditCate').show();
            }
        });
    }, 0);
});

function uploadResImage() {
    /// <summary>上传资源分类</summary>
    
    if ($("#postResImage").val() == "") {
        $.messager.alert('提示', '请选择一个图片文件，再点击上传。');
        return;
    }

    $('#resForm').ajaxSubmit({
        success: function (result) {
            result = eval('(' + $(result).text() + ')');
            if (result.success == true) {
                $.messager.alert('提示', '资源图片上传成功');
                $("#resImage").attr('src', result.image);
            }
            else {
                $.messager.alert('提示', result.msg);
            }
        }
    });
}

function deleteResource(resource) {
    /// 删除资源

    $.messager.confirm('确认', '你确定要删除"' + resource.CnName + '"么?</br>', function (r) {
        if (r) {
            $.post("../Services/Resource.ashx?", { action: 'DeleteResource', resID: resource.ResID, imageName: resource.Image }, function (result) {
                if (result === "true") {
                    $('#resGrid').datagrid("reload");
                } else {
                    $.messager.alert('提示', '删除失败');
                }
            });
        }
    });
}

function etidResource(resource) {
    /// 编辑资源

    $('#resForm').form('load', resource);
    $('#addResWin').window('open');

    $('#resImage').attr('src', resource.Image);
    CKEDITOR.instances.Description.setData(resource.Description);

    var resForm = document.getElementById("resForm");
    if ((resource.State & ResourceState.Recommend) === ResourceState.Recommend) {
        resForm.Recommend.checked = true;
    }

    if ((resource.State & ResourceState.InGarden) === ResourceState.InGarden) {
        resForm.InGarden.checked = true;
    }
}

function queryRes(value, cate) {
    /// 查询资源列表
    alert("cate:" + cate + ",value:" + value);
}

function addOrSaveResource() {
    /// <summary>添加或更新资源</summary>
    
    var resForm = document.getElementById("resForm");

    if($.trim(resForm.CnName.value) === "") {
        $.messager.alert('提示', '资源中文名称不能为空');
        resForm.CnName.focus();
        return;
    }

    if ($.trim(resForm.CategoryID.value) === "") {
        $.messager.alert('提示', '资源分类不能为空');
        return;
    }
         
    var state = 0;
    if (resForm.Recommend.checked) {
        state = state | ResourceState.Recommend;
    }

    if (resForm.InGarden.checked) {
        state = state | ResourceState.InGarden;
    }
    
    var des = CKEDITOR.instances.Description.getData();
    
    var resource = {
        ResID : resForm.ResID.value,
        CnName: escape(resForm.CnName.value),
        EnName: escape(resForm.EnName.value),
        OtherName: escape(resForm.OtherName.value),
        CategoryID: escape(resForm.CategoryID.value),
        Description: escape(des),
        State: state,
        Image: $("#resImage").attr('src')
    };

    // 添加资源
    if (resource.ResID === "") {
        $.post("../Services/Resource.ashx?", { action: 'AddResource', resource: $.toJSON(resource) }, function (resID) {
            if($.trim(resID) !== "") {
                $.messager.alert('提示', '资源添加成功');
                $('#addResWin').window('close');
                $('#resGrid').datagrid("reload");
            }
        });
    }
    
    // 更新资源
    else {
        $.post("../Services/Resource.ashx?", { action: 'EditResource', resource: $.toJSON(resource) }, function (result) {

        }); 
    }
}

function collapse(){
	var node = $('#resCateTree').tree('getSelected');
	$('#resCateTree').tree('collapse', node.target);
}

function expand() {
    var node = $('#resCateTree').tree('getSelected');
    $('#resCateTree').tree('expand', node.target);
}

function append() {
    var node = $('#resCateTree').tree('getSelected');
    $("#selectedCate").text(node.text);
    $('#cateForm').form('clear');

    $('#btnAddCate').show();
    $('#btnEditCate').hide();
}


function etidCate() {
    alert("edit cate");
}

function addCate() {
    /// <summary>添加资源分类</summary>
    
    var node = $('#resCateTree').tree('getSelected');
    var cnTitle = $("#cateCnTitle").val();
    var enTitle = $("#cateEnTitle").val();
    cate = {
        CnTitle: escape(cnTitle),
        EnTitle: escape(enTitle)
    };

    $.post("../Services/Resource.ashx?", { action: 'CreateCategory', cate: $.toJSON(cate), parentCateID: node.id }, function (cateID) {
        var newNode = {
            "id": cateID,
            "text": cnTitle + (enTitle ? '(' + enTitle + ')' : ''),
            "attributes": {
                "url": cateUrl + "&cateID=" + cateID,
                cate: cate
            }
        };

        $('#resCateTree').tree('append', {
            parent: (node ? node.target : null),
            data: [newNode]
        });
    });
}

function deleteResCate() {
    /// <summary>获取资源分类</summary>
    
    var node = $('#resCateTree').tree('getSelected');
    $.messager.confirm('确认', '你确定要删除"' + node.text + '"么?</br>', function (r) {
        if (r) {
            $.post("../Services/Resource.ashx?", { action: 'DeleteCategory', cateID: node.id }, function (result) {
                if(result === "true") {
                    $('#resCateTree').tree('remove', node.target);
                    $("#selectedCate").text("");
                    $('#cateForm').form('clear');
                }else {
                    alert("删除失败;");
                }
            });
        }
    });
}