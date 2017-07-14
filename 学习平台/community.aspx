<%@ Page Language="C#" AutoEventWireup="true" CodeFile="community.aspx.cs" Inherits="community" %>

<!DOCTYPE html>
<html>
<head>

    <meta charset="utf-8" />
    <title>虹软社区</title>
    
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/> 
    <meta name="viewport" content="width=device-width,initial-scale=1.0,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no" id="viewport"/>   
    <script src="js/jquery-3.2.1.min.js"></script>
    <script src="dist/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="css/search.css" />
    <link href="dist/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="css/home.css" />
 
</head>
<body>
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
						<li class="active"><a href="community.aspx">社区</a></li>
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
    <form id="Form1" runat="server">
       

        <div class="main hidden-xs" style="padding-top: 40px;">
            <div class="persional_property hidden-xs">
                <div class="second_nav_con">
                    <div class="second_nav">

                        <dd>
                            <a href="community.aspx?method=DBind&methodid=1">全部问答</a>
                        </dd>

                        <dd>
                            <a href="community.aspx?method=DBind&methodid=2">待回答</a>
                        </dd>

                        <dd>
                            <a href="community.aspx?method=DBind&methodid=3">已解决</a>
                        </dd>


                    </div>
                    <dl class="second_tips">
                        <dd class="ask_tips">
                            <div class="tracking-ad" data-mod="popu_64" style="margin-top: 5px">

                                <input type="button" class="btn btn-primary " style="float: right; margin-bottom: 15px" data-toggle="modal" data-target="#myModal" value="我要提问" />

                                <!-- 模态框（Modal） -->
                                <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                    <div class="modal-dialog">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                                    &times;
                                                </button>
                                                <h4 class="modal-title" id="myModalLabel">我要提问
                                                </h4>
                                            </div>
                                            <div class="modal-body">
                                                <div class="form-group">
                                                    <textarea id="TextareaQT" runat="server" class="form-control" rows="1" style="height: 40px;" placeholder="请输入提问标题~"></textarea>
                                                </div>
                                                <div class="form-group">
                                                    <textarea id="TextareaQC" runat="server" maxlength="500" class="form-control" rows="10" placeholder="请尽量用通俗且描述完整的语句说明问题，回答率会更高哦~"></textarea>
                                                </div>
                                            </div>
                                            <div class="modal-footer">
                                                <button type="button" class="btn btn-default" data-dismiss="modal">
                                                    关闭
                                                </button>
                                                <asp:Button runat="server" ID="submit" class="btn btn-primary" OnClick="submit_Click" Text="提交" />
                                            </div>
                                        </div>
                                        <!-- /.modal-content -->
                                    </div>
                                    <!-- /.modal -->
                                </div>

                            </div>
                        </dd>

                    </dl>
                </div>
            </div>

            <div class="persion_section">

                <div class="common_con clearfix">
                    <div class=" hidden-xs">
                        <div class="persion_section ">

                            <div class="common_con clearfix ">
                                <div class="questions_tab_con">

                                    <div class="sort">
                                        <div class="sort_list_label">
                                            <b style="color: gray">V</b>
                                            <i class="icon-caret-down"></i>
                                        </div>
                                        <ul>
                                            <a href="community.aspx?method=DBind&methodid=4 ">
                                                <li>时间</li>
                                            </a>
                                            <a href="community.aspx?method=DBind&methodid=5 ">
                                                <li>回答数</li>
                                            </a>

                                            <li class="arrow"></li>
                                        </ul>
                                    </div>

                                </div>

                                <div class="share_bar_con">
                                </div>


                                <asp:DataList ID="TopicList" runat="server">
                                    <ItemTemplate>
                                        <div class="questions_detail_con">
                                            <div class="q_time">
                                                <span><%# Eval("TopicTime")  %>来自</span>

                                                <a class="user_name"><%#Eval("StudentName") %></a>


                                            </div>
                                            <dl>
                                                <dt>
                                                    <a href="luntan.aspx?topicid=<%#Eval("topicid") %>"><%#Eval("TopicTitle") %></a>
                                                </dt>
                                                <dd>
                                                    <%#Eval("TopicContent") %>
                                                </dd>
                                            </dl>

                                            <a class="answer_num ">
                                                <span><%#Eval("replycount") %></span>
                                                <p>回答</p>
                                            </a>

                                        </div>
                                    </ItemTemplate>
                                </asp:DataList>

                                <div class="share_bar_con">
                                </div>

                                <div class="csdn-pagination hide-set">
                                    <span class="page-nav">
                                        <span class="text">共<%=topicPage%>页</span>
                                        <asp:button ID="lkPre" runat="server" class="btn btn-xs btn-default" Width="50px" OnCommand="IndexChanging" CommandArgument="pre" Text="上一页"></asp:button>


                                        <label style="color: gray">1</label>

                                        <label style="color: gray">&nbsp;2</label>
                                        <span class="ellipsis">...</span>


                                        <asp:button ID="lkNext" runat="server" class="btn btn-xs btn-default" Width="50px" OnCommand="IndexChanging" CommandArgument="next" Text="下一页"></asp:button>

                                    </span>

                                    <span class="page-go">
                                        <span class="text">到第</span>
                                        <input id="pg" runat="server" type="text" name="page" />

                                        <span class="text">页</span>
                                        <asp:button ID="lkConvert" runat="server" OnCommand="IndexChanging" CommandArgument="convert" class="btn btn-link btn-xs btn-default btn-go" Text="GO"></asp:button>

                                    </span>

                                </div>


                                <div class="csdn-pagination hide-set">
                                </div>


                            </div>
                        </div>
                    </div>




                </div>
            </div>
            <div class="persion_article">
                <div class="mod_my_achievement hidden-sm hidden-xs">
                    <div class="my_achievement clearfix">
                        <div class="achievement">
                            <h3><b>我的问答</b></h3>
                        </div>
                        <dl class="my_info clearfix">
                            <div class="img">
                                <a class="user_name">
                                    <img alt="" class="csdn-avatar50"></a>
                            </div>
                            <dt style="padding-left: 40px; padding-top: 20px;"><a class="user_name" target="_blank"><b><%=name %></b></a></dt>

                        </dl>
                        <div class="my_progress">
                            <div class="my_ask_info">
                                <div class="icon-A">问</div>
                                <div class="ask_answer">
                                    提了
        	<span>
                <a href="community.aspx?method=DBind&methodid=6"><%=topic %></a>
            </span>个问题
                                </div>
                                <span>

                                    <div class="br"></div>
                                    <div class="icon-B">答</div>
                                    <div class="ask_answer">
                                        回答了<span>
                                            <div>
                                                <a href="community.aspx?method=DBind&methodid=7"><%=reply%></a>
                                            </div>
                                        </span>个问题
                                    </div>
                                    <div class="br"></div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="mod_answer_ing hidden-sm hidden-xs">
                    <div class="mod_answer">
                        <h3>最新回答</h3>
                        <div id="" class="mod_dl_box">
                            <div class="scrollcontent">
                                <asp:DataList ID="replylist" runat="server">
                                    <ItemTemplate>
                                        <dl class="info_box clearfix">
                                            <dt>

                                                <a></a>
                                            </dt>
                                            <dd class="mod_dl_dd_01">
                                                <a class="user_name"><%#Eval("studentname")%></a>
                                                <span>回答了：</span>
                                                <a class="mod_dl_a"><%#Eval("replycontent") %>...</a>
                                                <p></p>
                                            </dd>
                                        </dl>
                                    </ItemTemplate>
                                </asp:DataList>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!--手机端-->
        <div class=" hidden-sm hidden-lg hidden-md" style="background-color: #f6f6f6; font-family: 'Microsoft YaHei';">
            <ol class="breadcrumb" style="margin-top: 0px; margin-bottom: 0px; background-color: white">
                <li><a href="#">社区</a></li>
                <a data-toggle="collapse" data-parent="#accordion"
                    href="#collapseOne" style="float: right">我要提问</a>
            </ol>
            <div id="collapseOne" class="panel-collapse collapse">
                <div class="panel-body">
                    <div class="container" style="margin-top: 10px; padding-top: 10px; background-color: white;">
                        <p>我要提问</p>
                    </div>

                    <div class="container" style="padding-top: 10px; background-color: white;">
                        <textarea runat="server" id="TextareaQTx" rows="1" class="form-control" style="height: 40px; resize: none; padding-bottom: 5px;" placeholder="请输入提问标题~（不能为空）"></textarea>
                        <br />
                        <textarea runat="server" id="TextareaQCx" rows="3" class="form-control" style="height: 80px; resize: none; padding-bottom: 5px;" placeholder="请尽量用通俗且描述完整的语句说明问题，回答率会更高哦~（不能为空）"></textarea>
                        <br />
                        <div style="text-align: right; margin-bottom: 20px">
                            <asp:Button runat="server" ID="Button1" class="btn btn-primary" OnClick="submitxs_Click" Text="发表" />
                        </div>

                    </div>
                </div>
            </div>

            <div class="container" style="margin-top: 10px; padding-top: 10px; padding-bottom: 10px; background-color: white;">
                <ul class="nav nav-tabs" style="font-size: 12px">
                    <li >
                        <a href="community.aspx?method=DBind&methodid=1">全部问答</a></li>
                    <li >
                        <a href="community.aspx?method=DBind&methodid=2">待回答</a></li>
                    <li >
                        <a href="community.aspx?method=DBind&methodid=3">已解决</a></li>
                </ul>
            </div>
            <asp:DataList runat="server" ID="xsTopicList">
                <ItemStyle Width="1000px" />
                <ItemTemplate>
                    <div class="container" style="margin-top: 5px; width: 100%; padding-top: 10px; background-color: white; border-bottom: 1px solid #808080">
                        <div style=""><span style="color: blue"><%#Eval("StudentName") %></span>&nbsp;&nbsp;&nbsp;&nbsp;<span style="color: #999393; font-size: 12px">于<%# Eval("TopicTime")  %>提问</span></div>
                        <div style="padding-top: 10px; padding-bottom: 10px; font-size: 18px;"><a href="luntan.aspx?topicid=<%#Eval("topicid") %>" style="color: black"><%#Eval("TopicTitle") %></a></div>
                        <div style="width: 100%; color: #4C4D4B">
                            <p><%#Eval("TopicContent") %></p>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
        <!--手机端-->
    </form>
</body>
</html>
