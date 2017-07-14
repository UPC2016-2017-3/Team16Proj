<%@ Page Language="C#" AutoEventWireup="true" CodeFile="上传课时3.aspx.cs" Inherits="上传课时3" %>

<%@ Register Assembly="MattBerseth.WebControls.AJAX" Namespace="MattBerseth.WebControls.AJAX.Progress" TagPrefix="mb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>添加课时页面3</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
	<meta content="" name="description" />
    <meta content="webthemez" name="author" />
    <link rel="Stylesheet" href="assets/css/progress.css" />
    <link rel="Stylesheet" href="assets/css/upload.css" />
    <link href="assets/css/bootstrap.css" rel="stylesheet" />
    <link href="assets/css/font-awesome.css" rel="stylesheet" />	
    <link href="assets/css/select2.min.css" rel="stylesheet" />
	<link href="assets/css/checkbox3.min.css" rel="stylesheet" />
    <link href="assets/css/custom-styles.css" rel="stylesheet" />
   <link href='https://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />
    <style type="text/css">
        BODY{ font-family:Arial, Sans-Serif; font-size:12px;}
    </style>
    <script type="text/C#" runat="server">
        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public static object GetUploadStatus()
        {
            //获取文件长度
            UploadInfo info = HttpContext.Current.Session["UploadInfo"] as UploadInfo;
            if (info != null && info.IsReady)
            {
                int soFar = info.UploadedLength;
                int total = info.ContentLength;
                int percentComplete = (int)Math.Ceiling((double)soFar / (double)total * 100);
                string message = string.Format("上传 {0} ... {1} of {2} 字节", info.FileName, soFar, total);                
                //  返回百分比
                return new { percentComplete = percentComplete, message = message };
            }
            //  还没有准备好...
            return null;
        }    
    </script>
</head>
<body style="background-color: #EDEDED;font-family: '微软雅黑';">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="scriptManager" runat="server" EnablePageMethods="true" />
    
    <script type="text/javascript">
        var intervalID = 0;
        var progressBar;
        var fileUpload;
        var form;
        // 进度条      
        function pageLoad() {
            //出现第一次
            $addHandler($get('upload'), 'click', onUploadClick);
            progressBar = $find('progress');
        }
        // 注册表单       
        function register(form, fileUpload) {
            this.form = form;
            this.fileUpload = fileUpload;
        }
        //上传验证
        function onUploadClick() {
            var vaild = fileUpload.value.length > 0;
            if (vaild) {
                //出现第二次
                $get('upload').disabled = 'disabled';
                updateMessage('info', '初始化上传...');
                //提交上传
                form.submit();
                // 隐藏frame
                Sys.UI.DomElement.addCssClass($get('uploadFrame'), 'hidden');
                // 0开始显示进度条
                progressBar.set_percentage(0);
                progressBar.show();
                // 上传过程
                intervalID = window.setInterval(function () {
                    PageMethods.GetUploadStatus(function (result) {
                        if (result) {
                            //  更新进度条为新值
                            progressBar.set_percentage(result.percentComplete);
                            //更新信息
                            updateMessage('info', result.message);
                            if (result == 100) {
                                // 自动消失
                                window.clearInterval(intervalID);
                            }
                        }
                    });
                }, 500);
            }
            else {
                onComplete('error', '您必需选择一个文件');
            }
        }

        function onComplete(type, msg) {
            // 自动消失
            window.clearInterval(intervalID);
            // 显示消息
            updateMessage(type, msg);
            // 隐藏进度条
            progressBar.hide();
            progressBar.set_percentage(0);
            // 重新启用按钮
            //出现第三次
            $get('upload').disabled = '';
            //  显示frame
            Sys.UI.DomElement.removeCssClass($get('uploadFrame'), 'hidden');
        }
        function updateMessage(type, value) {
            var status = $get('status');
            status.innerHTML = value;
            // 移除样式
            status.className = '';
            Sys.UI.DomElement.addCssClass(status, type);
        }
    </script>
    
        <div class="header" style="margin-top: 40px;background-color:white;height: 41px;">
		  	<div style="margin-left: 20px;">
               <a href="#"><img src="assets/img/后退CoGraphics.png" style="height:30px;width:30px;"/></a> 
             <font style="font-size:x-large;margin-left:20px;">  
                 <strong>您正在为第<%=URank %>课时添加音频资料
                     <span style="font-size:small;">若没有请单击“我不需要添加文件了”</span>
                 </strong></font>
		  	</div>											
		</div>

        <div id="page-inner">
            <div class="panel panel-default">
                <div class="panel-body"> 
                    <div class="sub-title" style="font-size:medium;">课时：<%=URank %></div>
                    <div class="sub-title" style="font-size:medium;">课时名称：<%=UName %></div>         
                    <div style="margin-top: 20px;">
                        <label for="exampleInputFile" style="font-size:medium;">上传课时资料
                            <span style="font-size:smaller;">（资料可上传任意一种，也可三种资料都上传，即三步操作，但每种资料上传数目仅限一个！）</span>
                        </label>
                        <div>

                            <label style="margin-top:15px;font-size:medium;">音频资料<span style="font-size:smaller;">(若没有此类型资料请单击“我不需要添加文件了”)</span></label>
                            <div class="upload" style="width:800px;">
                                <h3 style="color:red;">上传会涉及文件格式修正，请不要采取其他任何操作，等待下方提醒“文件已成功上传”，否则可能导致文件上传失败！</h3>
                                <div>
                                    <iframe id="uploadFrame" frameborder="0" scrolling="no" src="Upload.aspx" style="height:50px;"></iframe>
                                    <mb:ProgressControl ID="progress" runat="server" CssClass="lightblue" style="display:none" Value="0" Mode="Manual" Speed=".4" Width="100%" />
                                    <div>
                                         <div id="status" class="info">请选择要上传的音频文件，格式包括wav,mp3,ogg</div>
                                        <div class="commands" style="margin-right:350px;">                 
                                            <asp:Button ID="upload" runat="server" Text="上传" />
                                            <p style="display:none;"><%=fileName %></p>                                           
                                        </div>
                                    </div>
                                </div>
                             </div>
                           <%-- <div class="sub-title" style="font-size:medium;">资料类型</div>
                                    <div>
                                        <div>
                                        <select class="selectbox" id="SelectCategory1" onchange="checkcategoryselect1()">
                                        	<optgroup>
                                            <option value=""></option>
                                        	<option value="PPT.PDF.WORD">PPT.PDF.WORD</option>
                                            <option value="视频">视频</option>
                                            <option value="音频">音频</option>                                        
                                           </optgroup>
                                        </select> </div>
                                        <textarea ID="FileCategory1" style="display:none;" runat="server"></textarea>                             
                                    </div>--%>   
                        </div>
                        </div>                     
                <div style="margin-top: 20px;margin-bottom: 20px;">  
                                          <center>
                                              <asp:Button ID="Button1" class="btn btn-info btn-lg" OnClick="upload_Click" runat="server" Text="提交" /> 
                                              <label style="margin-left:20px;">
                                                  <a href="UnitList.aspx">
                                                  我不需要添加文件了
                                                  </a>
                                              </label> 
                                        </center>
               </div>                          </div>
            </div>
            
        <footer style="text-align: center;"><p>Copyright &copy; 虹软中国 All rights reserved.</p></footer>

</div>
    </form>
    <script src="assets/js/jquery-1.10.2.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>
    <script src="assets/js/jquery.metisMenu.js"></script>
	<script src="assets/js/select2.full.min.js"></script>
	<script type="text/javascript">
	    $(document).ready(function () {
	        $(".selectbox").select2();
	    });
	</script>
    <script src="assets/js/custom-scripts.js"></script> 
    <script language="JavaScript">
        function checkcategoryselect1() {
            var r = document.getElementById("SelectCategory1").value;
            document.getElementById('FileCategory1').value = r;
        }
        //function checkcategoryselect2() {
        //    var r = document.getElementById("SelectCategory2").value;
        //    document.getElementById('FileCategory2').value = r;
        //}
        //function checkcategoryselect3() {
        //    var r = document.getElementById("SelectCategory3").value;
        //    document.getElementById('FileCategory3').value = r;
        //}
</script>
</body>
</html>

