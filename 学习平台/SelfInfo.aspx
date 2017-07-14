<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelfInfo.aspx.cs" Inherits="SelfInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>个人信息</title>
		<meta name="viewport" content="width=device-width, initial-scale=1.0">
		<!-- 引入 Bootstrap -->
		<script type="text/javascript" src="js/jquery-3.2.1.min.js"></script>
		<link rel="stylesheet" href="https://cdn.bootcss.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
		<script src="https://cdn.bootcss.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
	</head>
	<body>
		<!--以下是导航条代码-->		
		<nav class="navbar navbar-default" role="navigation">
			<div class="container" >
				<div class="navbar-header">
					<img class="navbar-brand" src="img/HongRuan.png"/>
					<a class="navbar-brand" href="#" style="color: #D9534F;">虹软云课堂</a>					
					<button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#example-navbar-collapse">
						<span class="sr-only">切换导航</span>
						<span class="icon-bar"></span>
						<span class="icon-bar"></span>
						<span class="icon-bar"></span>
					</button>
				</div>
				<div class="collapse navbar-collapse" id="example-navbar-collapse">
					<ul class="nav navbar-nav">
								<li ><a href="Home.aspx">首页</a></li>
						<li><a href="ClassPage.aspx">课程</a></li>
						<li><a href="community.aspx">社区</a></li>
					</ul>
					<form class="navbar-form navbar-left" name="myForm">
		        		<div class="form-group">
		          			<input name="searchbox" type="text" class="form-control" onkeydown="inputaa(event)" placeholder="你想搜的课程"/>
		        		</div>
                        <script>
                            function inputaa(event) {
                                if (event.keyCode == 13) {

                                    stopDefault(event);
                                    var s = document.forms["myForm"]["searchbox"].value;
                                    window.open('SearchResult.aspx?search=' + s + '&type=1', "_blank");
                                    return false;
                                }
                            }
                            function stopDefault(e) {
                                //如果提供了事件对象，则这是一个非IE浏览器   
                                if (e && e.preventDefault) {
                                    //阻止默认浏览器动作(W3C)  
                                    e.preventDefault();
                                } else {
                                    //IE中阻止函数器默认动作的方式   
                                    window.event.returnValue = false;
                                }
                                return false;
                            }

                        </script>
		        		<input  type="button" class="btn btn-default" onclick="btn()" value="搜索"/>
		      		</form>
		      		<ul class="nav navbar-nav navbar-right">
		        		<li class="dropdown">
		          			<a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">账号 <span class="caret"></span></a>
		          			<ul class="dropdown-menu">
                                <li><a href="SelfInfo.aspx">个人中心</a></li>
                                <li><a href="MyCollection.aspx">我的收藏</a></li>
		            			<li role="separator" class="divider"></li>
		            			<li><a href="Login.aspx">退出</a></li>
		          			</ul>
		        		</li>
		      		</ul>
				</div>
			</div>
		</nav>
        <script type="text/javascript">
            function btn() {
                var s = document.forms["myForm"]["searchbox"].value;
                window.open('SearchResult.aspx?search=' + s + '&type=1', "_blank");
            }
        </script>

		<!--以上是导航条代码-->
		<div class="container">
			<div class="row">
				<div class="col-xs-12" style="height: 60px;background-color:  #D9534F;">
					<h3 style="color: white;">个人信息</h3>
				</div>
			</div>
			<div class="row">
				<div class="col-xs-12">
					<form class="form-inline" runat="server" action="ChangeInfo.aspx" method="Post">
						<br />
  						<div class="form-group">
    						<label for="Name">姓名</label>
    						<input type="text" class="form-control" name="Name" id="Name" value='<%=Name %>' disabled/>
  						</div>
  						<br /><br />
  						<div class="form-group">
    						<label for="Sex">性别</label>
    						<select class="form-control" name="Sex" id="Sex">
      							<option><%=Sex %></option>
      							<option><%=Sex2 %></option>
    						</select>
    					</div>
    					<br /><br />
  						<div class="form-group">
    						<label for="Account">昵称</label>
    						<input type="text" class="form-control" name="Account" id="Account" value='<%=Account %>' placeholder="请输入一个昵称">
  						</div>
  						<br /><br />
  						<div class="form-group">
    						<label for="Email">Email</label>
    						<input type="email" class="form-control" name="Email" id="Email" value='<%=Email %>' placeholder="请输入邮箱地址">
  						</div>
  						<br /><br />
  						<div class="form-group">
    						<label for="Telephone">手机号码</label>
    						<input type="text" class="form-control" value="+86" style="width: 50px;" disabled/>
    						<input type="text" class="form-control" name="Telephone" id="Telephone" value='<%=Telephone %>'' placeholder="请输入手机号" />
  						</div>
  						<br /><br />
  						
  						<a class="btn" role="button" data-toggle="collapse" href="#collapseExample" aria-expanded="false" aria-controls="collapseExample">
  							修改密码
						</a>
						
						<div class="collapse" id="collapseExample">
							<br />
  							<div class="form-group">
    							<input type="password" class="form-control" name="Password1" id="Password1" placeholder="请输入您之前的密码"/>
    							<br />
    							<input type="password" class="form-control" name="Password2" id="Password2" placeholder="请输入新密码"/>
    							<br />
    							<input type="password" class="form-control" name="Password3" id="Password3" placeholder="请确认新密码"/>
  							</div>
						</div>
						<br /><br />

  						<button type="submit" class="btn btn-default">保存修改</button>
					</form>
				</div>
			</div>
		</div>
	</body>
</html>