/*
Copyright (c) 2003-2011, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function (config) {
    config.language = 'zh-cn';
    config.toolbar_Ahzyzyw =
    [
        { name: 'clipboard', items: ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord', '-', 'Undo', 'Redo'] },
        { name: 'basicstyles', items: ['Bold', 'Italic', 'Underline', 'Strike', 'RemoveFormat'] },
        { name: 'paragraph', items: ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock'] },
        { name: 'editing', items: ['SelectAll'] },
        { name: 'tools', items: ['Maximize', 'ShowBlocks'] },
        '/',
        { name: 'styles', items: ['Styles', 'Format', 'Font', 'FontSize'] },
        { name: 'colors', items: ['TextColor', 'BGColor'] },
        { name: 'document', items: ['DocProps', '-', 'Preview', 'Source'] }
    ];
    config.enterMode = CKEDITOR.ENTER_BR;   // 使用回车换行模式
    config.font_names = 'Arial;Times New Roman;Verdana;宋体;楷体;微软雅黑;';
};
