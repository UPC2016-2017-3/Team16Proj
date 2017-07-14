<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchResult.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>搜索结果</title>
    <meta name="viewport" content="width=device-width,initial-scale=1.0,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no" id="viewport" />
    <link rel="stylesheet" href="http://cdn.static.runoob.com/libs/bootstrap/3.3.7/css/bootstrap.min.css"/>
	<script src="http://cdn.static.runoob.com/libs/jquery/2.1.1/jquery.min.js"></script>
	<script src="http://cdn.static.runoob.com/libs/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link href="css/home.css" rel="stylesheet" />
    
</head>
<body style="background-color:#f6f6f6" > 
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
						<li class="active"><a href="ClassPage.aspx">课程</a></li>
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

    <form id="form1" runat="server">
        <div class="container hidden-xs"  style="padding-top: 10px; background-color: white;">

            <ol class="breadcrumb" style="background-color: white; margin-top: 10px">
               	<li class="active"><a href="Home.aspx">首页</a></li>
						<li><a href="ClassPage.aspx">课程</a></li>
						<li><a >搜索结果</a></li>
            </ol>
        </div>
        <p class="container" style="padding: 20px 20px 20px 20px">共有<%=ClassNum %>门相关的课程</p>

        <div class="container breadcrumb" style="background-color: white;">

            <span>全部结果</span>
            <div class="btn-group" style="float: right">
                <asp:button runat="server" OnClick="Zonghe_Click" class="btn btn-default" Text="综合"></asp:button>
                <asp:button runat="server" OnClick="Zuire_Click" class="btn btn-default" Text="最热"></asp:button>
                <div class="btn-group">
                    <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">
                        价格
			<span class="caret"></span>
                    </button>
                    <ul class="dropdown-menu" style="min-width:70px">
                        <li><asp:button runat="server" OnClick="Quanbu_Click" class="btn btn-default" BorderStyle="None" Width="100%" Text="全部"></asp:button></li>
                        <li><asp:button runat="server" OnClick="Mianfei_Click" class="btn btn-default" BorderStyle="None" Width="100%" Text="免费"></asp:button></li>
                        <li><asp:button runat="server" OnClick="Fufei_Click" class="btn btn-default" BorderStyle="None" Width="100%" Text="付费"></asp:button></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="container">
            <asp:DataList ID="datalist1" runat="server" RepeatColumns="4" RepeatDirection="Horizontal">
                <ItemTemplate>
            <div class="col-md-3 col-sm-6 hidden-xs">
                <div class="course">
                    <img src="img/picture4.jpg" style="width: 260px; height: 165px" />
                    <div style="margin-left: 10px;font-family:'微软雅黑'">
                        <a href="VideoPage.aspx?classid=<%#Eval("ClassID") %>"><p style="font-size: 16px; color: black"><%# Eval("ClassName") %></p></a>
                        <div style="font-size: 12px; color: #808080">
                            <p><%# Eval("DepartmentName") %>&nbsp;</p>
                        </div>
                        <div style="margin-bottom: 5px">
                            <span style="color:red">￥<%# Eval("ClassPrice") %></span>
                            <span style="float: right; margin-right: 15px; font-size: 12px; color: #808080"><%# Eval("ClassCollectionNum") %>人收藏</span>
                        </div>
                    </div>
                </div>
            </div>
                    </ItemTemplate>
                </asp:DataList>
        </div>
        <!--手机推荐课程-->
        <div class="container" style="background-color: white;">
            <asp:DataList ID="datalist2" runat="server" RepeatColumns="2" RepeatDirection="Horizontal">
                <ItemTemplate>
                    <div class="hidden-lg hidden-md hidden-sm col-xs-6" style="margin-top: 10px">

                        <img src="img/picture4.jpg" style="width: 120px; height: 78px" />
                        
                        <div style="font-size: 12px;font-family: '微软雅黑';width:120px">
                           <a href="VideoPage.aspx?classid=<%#Eval("ClassID") %>"> <p style="width: 120px;"><%# Eval("ClassName") %></p></a>
                            <span style="color: red">￥<%# Eval("ClassPrice") %></span>
                            <span style="color: #808080;font-size:12px;float:right;margin-right:10px"><%# Eval("ClassCollectionNum") %>人收藏</span>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>

    </form>
</body>
</html>
