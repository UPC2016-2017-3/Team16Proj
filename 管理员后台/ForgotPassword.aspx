<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>

<!doctype html>
<html lang="en">

<head>
	<title>忘记密码页</title>
	<meta charset="utf-8">
	<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
	<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0">
	<!-- VENDOR CSS -->
	<link rel="stylesheet" href="assets/vendor/bootstrap/css/bootstrap.min.css">
	<link rel="stylesheet" href="assets/vendor/font-awesome/css/font-awesome.min.css">
	<link rel="stylesheet" href="assets/vendor/linearicons/style.css">
	<!-- MAIN CSS -->
	<link rel="stylesheet" href="assets/css/main.css">
	<!-- FOR DEMO PURPOSES ONLY. You should remove this in your project -->
	<link rel="stylesheet" href="assets/css/demo.css">
	<!-- GOOGLE FONTS -->
	<!--<link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700" rel="stylesheet">-->
	<!-- ICONS -->
	<link rel="apple-touch-icon" sizes="76x76" href="assets/img/apple-icon.png">
	<link rel="icon" type="image/png" sizes="96x96" href="assets/img/favicon.png">
</head>

<body style="color: #000000;">
	<!-- WRAPPER -->
	<div id="wrapper">
		<!-- MAIN -->
		
		<div class="main">
			<!-- MAIN CONTENT -->
			<div class="main-content">
                <form id="form1" runat="server">
				<div class="container-fluid">
					<center>
					<div class="header">
						<div class="logo text-center"><img src="assets/img/arc.png" alt="Klorofil Logo" style="width: 90px;"></div>
						<p class="lead" style="font-family: '楷体';margin-top: 15px;"><strong>虹软云课堂</strong></p>
					</div>
					</center>
					<div class="row">
						<div class="col-md-12">				
							<!-- 注册框 -->
							<div class="panel">
								<center>
								<div class="panel-heading">
									<h3 class="panel-title" style="font-family: '楷体';"><strong>忘记密码</strong></h3>
								</div>
								</center>
								<div class="panel-body" style="font-family: '微软雅黑';">												                                  

									<div style="margin-top: 15px;">
									<span style="font-size:medium;color:#3E3D3E">姓名</span>
									<input runat="server" type="text" id="username" style="width: 86%;height: 38px;" placeholder="您真实姓名">							
									</div>
									<br />
									
									<div style="margin-top: 15px;">
                                        <%--<img src="assets/img/星号.png" style="width:10px;height:10px;"/>--%>
									<span style="font-size:medium;color:#3E3D3E">电话</span>
									<input onkeyup="value=value.replace(/[^\d]/g,'')" onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" runat="server" type="text" id="Tel" style="width: 86%;height: 38px;" placeholder="注册时填写的电话号码" onchange="checkrTel()">
									</div>
									<br />																		
									<div style="margin-top: 15px;">
                                        <%--<img src="assets/img/星号.png" style="width:10px;height:10px;"/>--%>
									<span style="font-size:medium;color:#3E3D3E">新密码</span>
									<input onkeyup="value=value.replace(/[\W]/g,'')" onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" runat="server" type="password" id="psd1" style="width: 83%;height: 38px;" placeholder="请输入至多8位数密码，必须是字母或者数字" onchange="checkrPsd()"> 
									<%--<img id="psd1img" src="assets/img/勾选.png" style="width:3%;height:3%;display: none;"/>--%>
									</div>
									<br />
									
									<div style="margin-top: 15px;">
                                        <%--<img src="assets/img/星号.png" style="width:10px;height:10px;"/>--%>
									<span style="font-size:medium;color:#3E3D3E">确认</span>
									<input onkeyup="value=value.replace(/[\W]/g,'')" onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" runat="server" type="password" id="psd2" style="width: 86%;height: 38px;" placeholder="请再次确认您的新密码" onchange="chick()">
									<img id="psd2imgyes" src="assets/img/勾选.png" style="width:3%;height: 3%;display: none;"/>
									<img id="psd2imgno" src="assets/img/错误.png" style="width:4%;height: 4%;display: none;"/>
									</div>
									<br />																											
									<center>
                                        <asp:button id="button1" runat="server" OnClick="button1_Click" class="btn btn-info" style="width: 98%;margin-bottom: 30px;" Text="确认"/>
									</center>
								</div>
							</div>
							<!-- END 注册框 -->						
						</div>
						<div class="col-md-12">
						</div>
					</div>
				</div>
                    </form>
			</div>
			<!-- END MAIN CONTENT -->
		</div>
		
		<!-- END MAIN -->
		<div class="clearfix"></div>
		<footer>
			<div class="container-fluid">
				<p class="copyright">&copy; 2017 <a href="#" target="_blank"></p>
			</div>
		</footer>
	</div>
	<!-- END WRAPPER -->
	<!-- Javascript -->
	<script src="assets/vendor/jquery/jquery.min.js"></script>
	<script src="assets/vendor/bootstrap/js/bootstrap.min.js"></script>
	<script src="assets/vendor/jquery-slimscroll/jquery.slimscroll.min.js"></script>
	<script src="assets/scripts/klorofil-common.js"></script>

	<!--控制两次的密码一致-->
	<script language="javascript">
	    function chick() {
	        if (document.getElementById("psd1").value == document.getElementById("psd2").value) {
	            document.getElementById("psd2imgno").style.display = "none";
	            document.getElementById("psd2imgyes").style.display = "inline";
	        } else {
	            document.getElementById("psd2imgyes").style.display = "none";
	            document.getElementById("psd2imgno").style.display = "inline";
	        }
	    }
</script>
<script  language="javascript">
    function chk() {
        var regu = "^(([0-9a-zA-Z]+)|([0-9a-zA-Z]+[_.0-9a-zA-Z-]*[0-9a-zA-Z]+))@([a-zA-Z0-9-]+[.])+([a-zA-Z]{2}|net|NET|com|COM|gov|GOV|mil|MIL|org|ORG|edu|EDU|int|INT)$";
        var re = new RegExp(regu);
        if (s.search(re) != -1) {
            return true;
        } else {
            window.alert("请输入有效合法的E-mail地址 ！")
            return false;
        }
    }
</script>
<script language="javascript">
    function checkrname() {
        if (document.getElementById("username").value != String.EMPTY) {
            document.getElementById("realnameimgy").style.display = "inline";
        }
        else {
            document.getElementById("realnameimgn").style.display = "inline";
        }
    }
</script>
<script language="javascript">
    function checkrTel() {
        if (document.getElementById("Tel").value != String.EMPTY) {
            document.getElementById("Telimgy").style.display = "inline";
        }
        else {
            document.getElementById("Telimgn").style.display = "inline";
        }
    }
</script>
<script language="javascript">
    function checkrUser() {
        if (document.getElementById("Name").value != String.EMPTY) {
            document.getElementById("usernameimgy").style.display = "inline";
        }
    }
</script>
<script language="javascript">
    function checkrPsd() {
        if (document.getElementById("psd1").value != String.EMPTY) {
            document.getElementById("psd1img").style.display = "inline";
        }
    }
</script>
<script language="javascript">
    function checkrEmail() {
        if (document.getElementById("emailin").value != String.EMPTY) {
            document.getElementById("email1").style.display = "inline";
        }
        var regu = "^(([0-9a-zA-Z]+)|([0-9a-zA-Z]+[_.0-9a-zA-Z-]*[0-9a-zA-Z]+))@([a-zA-Z0-9-]+[.])+([a-zA-Z]{2}|net|NET|com|COM|gov|GOV|mil|MIL|org|ORG|edu|EDU|int|INT)$";
        var re = new RegExp(regu);
        if (s.search(re) != -1) {
            return true;
        } else {
            window.alert("请输入有效合法的E-mail地址 ！")
            return false;
        }
        //var regu = "^(([0-9a-zA-Z]+)|([0-9a-zA-Z]+[_.0-9a-zA-Z-]*[0-9a-zA-Z]+))@([a-zA-Z0-9-]+[.])+([a-zA-Z]{2}|net|NET|com|COM|gov|GOV|mil|MIL|org|ORG|edu|EDU|int|INT)$";
        //var re = new RegExp(regu);
        //if (s.search(re) != -1) {
        //    return true;
        //} else {
        //    window.alert("请输入有效合法的E-mail地址 ！")
        //    return false;
        //}
    }
</script>
	<script language="javascript">
	    function check() {
	        var sel = 0;
	        for (var i = 0; i < document.getElementsByName("gender").length; i++) {
	            if (document.getElementsByName("gender")[i].checked) {
	                sel = document.getElementsByName("gender")[i].value;
	            }
	        }
	        if (sel == 1) {
	            document.getElementById('text1').value = '男';
	        }
	        if (sel == 2) {
	            document.getElementById('text1').value = '女';
	        }
	    }
</script>
	<script language="JavaScript">
	    function checkcategoryselect() {
	        var r = document.getElementById("Categoryselect").value;
	        document.getElementById('Category').value = r;
	    }
</script>
</body>

</html>
