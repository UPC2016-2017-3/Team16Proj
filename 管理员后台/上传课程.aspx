<%@ Page Language="C#" AutoEventWireup="true" CodeFile="上传课程.aspx.cs" Inherits="上传课程" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
	<meta content="" name="description" />
    <meta content="webthemez" name="author" />
    <title>添加课程页面</title>
    <link href="assets/css/bootstrap.css" rel="stylesheet" />
    <link href="assets/css/font-awesome.css" rel="stylesheet" />	
    <link href="assets/css/select2.min.css" rel="stylesheet" />
	<link href="assets/css/checkbox3.min.css" rel="stylesheet" />
    <link href="assets/css/custom-styles.css" rel="stylesheet" />
   <link href='https://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />
</head>
<body style="background-color: #EDEDED;font-family: '微软雅黑';">
    <form id="form1" runat="server">  
		  <div class="header" style="margin-top: 40px;background-color:white;height: 41px;">
		  	<div style="margin-left: 20px;">
               <a href="CourseList.aspx"><img src="assets/img/后退CoGraphics.png" style="height:30px;width:30px;"/></a> 
             <font style="font-size:x-large;margin-left:20px;">  <strong>您正在添加课程</strong></font>
		  	</div>											
		</div>
		
            <div id="page-inner"> 
                       <div class="row">
                        <div class="col-xs-12">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <div class="card-title">
                                        <div class="title">
                                        	<font style="font-size:x-large;margin-top:20px;">课程信息</font> 
                                        </div>                                     
                                    </div>
                                     <p style="font-family: '微软雅黑';font-size:medium;">请您完善该门课程相关信息，让学员更了解您的课程哦</p>
                                </div>
                                <div class="panel-body">                                   
                                    <div class="sub-title">课程名称</div>
                                    <div>
                                        <input type="text" class="form-control" id="ClassName" runat="server"/>
                                    </div>
                                    <div class="sub-title"> 
                                        课程封面
                                        <span style="font-size:small;color:red;">(课程封面可自行选择是否上传，若不上传，将使用默认封面)</span>
                                    </div>
                                    
                                    <div runat="server">
                                        <asp:FileUpload ID="Coverload" runat="server" />
                                        <%--<input type="file" id="Coverload" runat="server"/>--%>
                                        <span>仅支持上传.png/.jpg/.jpeg图片格式的文件</span>
                                        <asp:Image ID="Image1" runat="server"/> 
                                        <asp:Button runat="server" ID="file" class="btn btn-default btn-sm" Onclick="file_Click" Text="上传" style="margin-left:100px;"/>                                       
										<textarea id="filename" runat="server"><%=FName %></textarea>                             									
                                    </div>
                                    <div class="sub-title">课程类别</div>
                                    
                                    <div>
                                        <select class="selectbox" id="Categoryselect" onchange="checkcategoryselect()">
                                        	<optgroup>
                                            <option value=""></option>
                                        	<option value="暗光高清拍摄技术">暗光高清拍摄技术</option>
                                            <option value="防抖技术">防抖技术</option>
                                            <option value="全景技术">全景技术</option>
                                            <option value="人脸技术">人脸技术</option>
                                            <option value="HDR技术">HDR技术</option>
                                            <option value="手势识别技术">手势识别技术</option>
                                            <option value="场景检测与物体识别技术">场景检测与物体识别技术</option>
                                            <option value="体感技术">体感技术</option>
                                            <option value="3D立体成像技术">3D立体成像技术</option>
                                            <option value="AR/VR技术">AR/VR技术</option>
                                           </optgroup>
                                        </select>
                                        <textarea id="Category" style="display:none;" runat="server"></textarea>
                                    </div>
                                    <div class="sub-title">所属部门</div>
                                    <div>
                                        <select class="selectbox" id="Departmentselect" onchange="checkselect()">
                                        	<optgroup>
                                            <option value=""></option>
                                        	<option value="实习部">实习部</option>
                                            <option value="外景部">外景部</option>
                                            <option value="人力资源部">人力资源部</option>
                                            <option value="产品部">产品部</option>
                                            <option value="研发部">研发部</option>
                                            <option value="总经理办公室">总经理办公室</option>
                                            <option value="董事长办公室">董事长办公室</option>
                                           </optgroup>
                                        </select>
                                        <textarea id="Department" style="display:none;" runat="server"></textarea>
                                    </div>
                                    <div class="sub-title">课程简介</div>
                                    <div>
                                        <textarea id="Class_info" class="form-control" rows="5" onkeyup= "checklength(this)" runat="server"></textarea>
                                        <div style="float:right">请您将课程简介控制在200字以内，您还可以输入<span  id="result">200</span>/200个字</div
                                    </div>                                    
                                    <div class="sub-title">该门课程是否对非本部门学员开放 </div>
                                    <div>                                    	
                                    <!--以下是对学员是否开放radio-->                                        
                                        <INPUT TYPE="radio" NAME="a" value="1" onclick="check()"><label style="margin-top: 10px;">开放</label><br>
                                        <INPUT TYPE="radio" NAME="a" value="2" onclick="check()"><label>不开放</label><br>
                                       <!-- <INPUT TYPE="button" onclick="chk()" value="请确认您的选择" class="btn btn-info btn-xs">-->
                                        <textarea id="text1" style="display:none;" runat="server"></textarea>
                                        <!--以上是对学员是否开放radio-->                                       
                                        <div id="classprice" style="">
                                        <div class="sub-title">该门课程的价格，若是仅对本部门学员开放或者免费，请您填写数字0</div>
                                        <div>
                                        <input type="text" class="form-control" id="Price" runat="server"/>
                                        </div>
                                        </div>                   
                                        <div style="margin-top: 20px;margin-bottom: 20px;">  
                                          <center>  <asp:Button runat="server" id="btn_Comment" type="button" class="btn btn-info btn-lg" OnClick="SubmitClick" Text="添加"/>
                                        </center>
                                        </div>
                                 </div>                                  
                                </div>
                            </div>
                        </div>
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
    <!--获取radio的值，并弹框提示-->
   <script language="javascript">
    function check() {
        var sel = 0;
        for (var i = 0; i < document.getElementsByName("a").length; i++) {
            if (document.getElementsByName("a")[i].checked) {
                sel = document.getElementsByName("a")[i].value;
            }
        }
        if (sel == 1) {
            document.getElementById('text1').value = '开放';
            alert("您确定要为该门课程设置开放属性吗？");
        }
        else if (sel == 2) {
            document.getElementById('text1').value = '不开放';
            alert("您确定要为该门课程设置不开放属性吗？");
        } else {
            alert("您还未选择该门课程是否开放！");
        }
    }
</script>
<!--获取select的值-->
<script language="JavaScript">
    function checkselect() {
        var r = document.getElementById("Departmentselect").value;
        document.getElementById('Department').value = r;
    }
</script>
<script language="JavaScript">
    function checkcategoryselect() {
        var r = document.getElementById("Categoryselect").value;
        document.getElementById('Category').value = r;
    }
</script>
 <!--限制文本款的字数-->
<script type="text/javascript">
    $("#Class_info").bind('input', function () {
        var bb = $('#Class_info').val();
        var cc = bb.substring(0, 200);
        $('#Class_info').val(cc);
        var aa = $(this).val().length;
        if (aa < 200) {
            $('#result').html(200 - $(this).val().length);
        } else {
            $('#result').html("0");
        }
    })
</script>
</body>
</html>

