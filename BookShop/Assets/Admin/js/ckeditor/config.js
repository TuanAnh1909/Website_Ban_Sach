/// <reference path="../../../../Scripts/ckfinder.html" />
/// <reference path="../../../../Scripts/ckfinder.html" />
/**
 * @license Copyright (c) 2003-2015, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
    // config.uiColor = '#AADC6E';
 //   config.extraPlugins = 'syntaxhighlight';
    config.syntaxhighlight_lang='csharp';
    config.syntaxhighlight_hideControls = true;
    config.language = 'vi';
    config.filebrowerBrowseUrl = '/Assets/Admin/js/plugins/ckfinder/ckfinder.html';
    config.filebrowerImageBrowseUrl = '/Assets/Admin/js/plugins/ckfinder.html?Type=Images';
    config.filebrowerFlashBrowseUrl = '/Assets/Admin/js/plugins/ckfinder.html?Type=Flash';
    config.filebrowerUploadUrl = '/Assets/Admin/js/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpLoad&Type=Files';
    config.filebrowerImageUploadUrl = '/Data';
    config.filebrowerFlashUploadUrl = '/Assets/Admin/js/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpLoad&Type=Flash';
    
    CKFinder.setupCKEditor(null, '/Assets/Admin/js/plugins/ckfinder/');
};
