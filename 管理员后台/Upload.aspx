<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Upload.aspx.cs" Inherits="Upload" EnableSessionState="ReadOnly" Async="true"%>

<%@ Import Namespace="System.IO"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <script runat="server">
        
</script>
    <style type="text/css">
        BODY{margin:0; padding:0; background-color:white;}
    </style>
</head>
<body>
    <form id="form" runat="server" enctype="multipart/form-data">
    <asp:ScriptManager ID="scriptManager" runat="server" />
    <script type="text/javascript">
        function pageLoad(sender, args){               
            window.parent.register(
                $get('<%= this.form.ClientID %>'), 
                $get('<%= this.fileUpload.ClientID %>')
            );
        }
    </script>
    <div style="margin-top:10px;">
        <asp:FileUpload ID="fileUpload" runat="server" Width="100%" />
    </div>
    </form>
</body>
</html>
