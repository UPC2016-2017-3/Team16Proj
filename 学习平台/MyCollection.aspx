<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyCollection.aspx.cs" Inherits="MyCollection" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="content-type" content="text/html; charset=UTF-8"/>
	<script type="text/javascript" src="../media/flowplayer-3.2.13.min.js"></script>
    	<!-- some minimal styling, can be removed -->
    
	<!-- page title -->
	<meta charset="UTF-8"/>
		<title>我的收藏</title>		
		<link href="../css/bootstrap.min.css" rel="stylesheet"/>
   		<script src="../js/jquery-3.2.1.js"></script>
   		<script src="../js/bootstrap.min.js"></script>
   		<meta name="viewport" content="width=device-width,initial-scale=1.0,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no" id="viewport" />
   		<script type="text/javascript" src="media/flowplayer-3.2.13.min.js"></script>
        <link rel="stylesheet" href="http://cdn.static.runoob.com/libs/bootstrap/3.3.7/css/bootstrap.min.css"/>
		<script src="http://cdn.static.runoob.com/libs/jquery/2.1.1/jquery.min.js"></script>
		<script src="http://cdn.static.runoob.com/libs/bootstrap/3.3.7/js/bootstrap.min.js"></script>
        <link href="css/collection.css" rel="stylesheet" />
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
        <form id="Form1" runat="server">
    <div class="container">
        <div class="u-container" style="padding-top:20px">
            <div style="margin-top: 20px">
                <ul class="nav nav-tabs ">
                    <li class="active"><a href="#mylearn" data-toggle="tab" ><b style="color: brown">最近学习</b></a></li>
                    <li><a href="#mycollection" data-toggle="tab" ><b style="color: brown">我的收藏</b></a></li>
                </ul>
            </div>


            <div id="TabContent" class="tab-content">
                <div id="mylearn" class="tab-pane fade in active">
                    <ul class="timeline ">
                        <asp:DataList ID="datalistL" runat="server">
                        <ItemStyle Width="1200px"></ItemStyle>
                            <ItemTemplate>
                        <li >
                            <div class="time hidden-sm hidden-xs" style="font-size: 18px;"><%# Eval("LearnDateY") %></div>
                            <div class="version hidden-sm hidden-xs" style="padding-right: 30px"><%# Eval("LearnDateM") %>-<%# Eval("LearnDateM") %></div>
                            <div class="number hidden-sm hidden-xs"></div>
                            <div class="content">
                                <div  style="margin-left: 30px;border-bottom-style:solid;border-bottom-color:grey;border-width:1px; height: 155px;">
                                    <div >
                                        <img src="img/kecheng.jpg" class="img-responsive" alt="Cinque Terre" width="225"  height="142" style="max-width:35%;min-height:90px; float: left" />
                                    </div>
                                    <div >
                                        <label style="margin-left: 10px; margin-top: 15px;max-width:55%"><%# Eval("ClassName") %></label>
                                        
                                        <p style="margin-top: 15px;">&nbsp;&nbsp;&nbsp;已学<%# Eval("LearnTimeLength")%>分钟</p>
                                        <asp:button ID="Button1" runat="server" OnCommand="continueLearning" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"ClassID") %>' style="border: 1px solid brown; background-color: white; color: brown; margin-left: 10px; margin-top: 25px;display:inline" Text="继续学习"></asp:button>
                                        <asp:button ID="Button2" runat="server" OnCommand="deleteLearn" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"ClassID") %>' style="border: 1px solid brown; background-color: white; color: brown; margin-left:10px;display:inline" Text="删除"></asp:button>

                                     </div>
                                </div>
                            </div>
                        </li>

                                </ItemTemplate>
                        </asp:DataList>
                    </ul>
                </div>
                <div id="mycollection" class="tab-pane fade">
                
                    <ul class="timeline ">
                    <asp:DataList ID="datalistC" runat="server">
                     <ItemStyle Width="1200px"></ItemStyle>
                            <ItemTemplate>
                       <li >
                            <div class="time hidden-sm hidden-xs" style="font-size: 18px;"><%# Eval("CollectionDateY") %></div>
                            <div class="version hidden-sm hidden-xs" style="padding-right: 30px"><%# Eval("CollectionDateM") %>-<%# Eval("CollectionDateD") %></div>
                            <div class="number hidden-sm hidden-xs"></div>
                            <div class="content"">
                                <div style="margin-left: 30px;border-bottom-style:solid;border-bottom-color:grey;border-width:1px; height: 155px;">
                                    <div>
                                       <img src="img/kecheng.jpg" class="img-responsive" alt="Cinque Terre" width="225"  height="142" style="max-width:35%;min-height:90px;float: left" />

                                    </div>
                                    <div>
                                        <label style=" margin-left: 10px; margin-top: 15px;max-width:55%;"><%# Eval("ClassName") %></label>
                                        <p style="margin-top: 15px;">&nbsp;&nbsp;&nbsp;</p>
                                        <asp:button ID="Button1" runat="server" OnCommand="continueLearning" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"ClassID") %>' style="border: 1px solid brown; background-color: white; color: brown; margin-left: 10px; margin-top: 25px;display:inline" Text="开始学习"></asp:button>
                                        <asp:button ID="Button2" runat="server" OnCommand="deleteCollection" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"CollectionID") %>' style="border: 1px solid brown; background-color: white; color: brown; margin-left:5px;display:inline" Text="取消收藏"></asp:button>
                                    </div>
                                </div>
                            </div>
                        </li>
                         </ItemTemplate>
                        </asp:DataList>
                       
                    </ul>
                </div>
            </div>
        </div>
    </div>

</form>
</body>
</html>
