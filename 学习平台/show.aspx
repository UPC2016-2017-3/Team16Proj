<%@ Page Language="C#" AutoEventWireup="true" CodeFile="show.aspx.cs" Inherits="upload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="FlexPaper/js/jquery.js" type="text/javascript"></script>
    <script src="FlexPaper/js/flexpaper_flash_debug.js" type="text/javascript"></script>
    <script src="FlexPaper/js/flexpaper_flash.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    
    <div style="position: absolute; left: 20px; top: 20px;">
        <a id="viewerPlaceHolder" style="width: 660px; height: 480px; display: block;"></a>
        <script type="text/javascript">
            var fp = new FlexPaperViewer(
        'FlexPaper/FlexPaperViewer',
        'viewerPlaceHolder',
        { config: {
            SwfFile: escape('TestSWF/2016中国网络购物行业监测-现状趋势篇.swf'),
            Scale: 0.6,
            ZoomTransition: 'easeOut',
            ZoomTime: 0.5,
            ZoomInterval: 0.2,
            FitPageOnLoad: false,
            FitWidthOnLoad: false,
            PrintEnabled: true,
            FullScreenAsMaxWindow: false,
            ProgressiveLoading: false,
            MinZoomSize: 0.2,
            MaxZoomSize: 5,
            SearchMatchAll: false,
            InitViewMode: 'Portrait',
            ViewModeToolsVisible: true,
            ZoomToolsVisible: true,
            NavToolsVisible: true,
            CursorToolsVisible: true,
            SearchToolsVisible: true,
            localeChain: 'en_US'
        }
        }
        );
        </script>
    </div>
    </form>
</body>
</html>
