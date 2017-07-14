<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="登录" %>

<!doctype html>
<html lang="en" class="fullscreen-bg">

<head>
	<title>虹软云课堂登录</title>
	<meta charset="utf-8">
	<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
	<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0">
	<link rel="stylesheet" href="assets/css/bootstrap.min.css">
	<link rel="stylesheet" href="assets/css/font-awesome.min.css">
	<link rel="stylesheet" href="assets/css/style.css">
	<link rel="stylesheet" href="assets/css/main.css">
	<link rel="stylesheet" href="assets/css/demo.css">
    <link rel="stylesheet" href="assets/css/checkbox3.min.css">
	<link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700" rel="stylesheet">

</head>

<body>
    
	<div id="wrapper">
		<div class="vertical-align-wrap">
			<div class="vertical-align-middle">
				<div class="auth-box ">
					<div class="left">
						<div class="content">                     
							<div class="header">
								<div class="logo text-center"><img src="assets/img/logo.png" alt="Klorofil Logo"></div>
								<p class="lead" style="font-family: '楷体';">欢迎使用虹软云课堂</p>
							</div>
							<form class="form-auth-small" runat="server">
								<div class="form-group">
									<label for="signin-email" class="control-label sr-only">账号</label>
									<input type="text" Class="form-control" runat="server" id="account" placeholder="姓名或者手机号">
								</div>
								<div class="form-group">
									<label for="signin-password" class="control-label sr-only">密码</label>
                                    <asp:TextBox ID="password" runat="server" TextMode="Password" placeholder="密码" class="form-control"></asp:TextBox>
									<%--<input type="password" runat="server" class="form-control" id="password" placeholder="密码">--%>
								</div>
                                <div Class="form-group clearfix">
								<!--以下是对学员是否开放radio--> 




								<div class="element-left">
                                    <input TYPE="radio" NAME="a" value="管理员" onclick="check()">
                                    <span style="margin-top: 20px;">管理员</span>
                                    &nbsp;&nbsp;&nbsp;
                                    <input TYPE="radio" NAME="a" value="学员" onclick="check()">
                                    <span>学员</span>
                                </div>   
                                     <!--以上是对学员是否开放radio-->
								<textarea id="text1" style="display: none;" runat="server"></textarea>
								</div>
                                                                               
								<div class="form-group clearfix">
									<div class="element-left">
                                        <asp:CheckBox ID="remME" runat="server" Text="记住密码" style="font-family:'微软雅黑';font-size:smaller;color:#93999f"/>
										
									</div>
								</div>
                                <asp:Button runat="server" type="submit" class="btn btn-primary btn-lg btn-block" Text="登录" OnClick="Login_Click"/>								
								<div class="bottom">
									<span class="helper-text"><i><img src="assets/img/锁.png" style="width: 15px;height: 15px;"></i> <a href="#">忘记密码?</a></span>
								</div>
							</form>
						</div>
					</div>
					<div class="right">
						<div class="overlay"></div>
						<div class="content text">
							<center>								
								<h1 class="heading" style="font-family: '楷体';"><strong>虹软云课堂</strong></h1>
								<strong><p>by <a href="http://www.arcsoft.com.cn/" style="color: white;font-family: '楷体';"" target="_blank">虹软中国</a></p></strong>								
							</center>
						</div>
						
					</div>
					<div class="clearfix"></div>
                   
				</div> 
			</div>
		</div>
	</div>
    <script language="javascript">
        function check() {
            var sel = 0;
            for (var i = 0; i < document.getElementsByName("a").length; i++) {
                if (document.getElementsByName("a")[i].checked) {
                    sel = document.getElementsByName("a")[i].value;
                    document.getElementById('text1').value = sel;
                }
            }
        }
</script>

</body>

</html>
