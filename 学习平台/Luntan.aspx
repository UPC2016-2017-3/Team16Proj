<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Luntan.aspx.cs" Inherits="Luntan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <title>虹软社区</title>
    <link rel="stylesheet" href="css/search.css" />
    <script src="js/jquery-3.2.1.min.js"></script>
    <script src="dist/js/bootstrap.min.js"></script>
    <link href="dist/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="css/home.css" />
</head>
<body style="font-family:'Microsoft YaHei'">
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
						<li><a href="Home.aspx">首页</a></li>
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
    <form runat="server">

    <!--以上是导航条代码-->

    <div class="main hidden-xs" style="padding-top: 53px;">
        <div class="persional_property hidden-xs">
        </div>

        <div class="persion_section">

            <div class="common_con clearfix" style="margin-top:20px">
                <div class=" hidden-xs">
                    <div class="persion_section ">

                        <div class="common_con clearfix ">
                            <div class="questions_detail_con">
                                <dl>
                                    <dt style="margin-top:10px"><%=topictitle %>
                                    </dt>
                                    <div class="q_operate">
                                        <p>
                                            <span><a><%=studentname %></a>&nbsp;于 <%=topictime %> 提问</span>
                                        </p>
                                    </div>
                                    <div class="tags">

     

                                    </div>
                                    <dd style="width:85%">
                                        <span>
                                            <%=topiccontent %>    
                                        </span>
                                        
                                    </dd>
                                    <input type="button" class="btn btn-primary " style="float:right;margin-bottom:15px" data-toggle="modal" data-target="#myModal" value="+我要回答"/>
                                        
                                    <!-- 模态框（Modal） -->
                                    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                        <div class="modal-dialog">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                                        &times;
                                                    </button>
                                                    <h4 class="modal-title" id="myModalLabel">我要回答
                                                    </h4>
                                                </div>
                                                <div class="modal-body">
                                                    <div class="form-group">
                                                        <textarea id="textareaHD" runat="server" class="form-control" rows="10" placeholder="请认真回答哦~"></textarea>
                                                    </div>
                                                </div>
                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-default" data-dismiss="modal">
                                                        关闭
                                                    </button>
                                                    <asp:Button runat="server" ID="submit"  class="btn btn-primary" OnClick="submit_Click" Text="提交回答"/>  
                                                </div>
                                            </div>
                                            <!-- /.modal-content -->
                                        </div>
                                        <!-- /.modal -->
                                    </div>
                                </dl>
                            </div>
                        </div>
                       <p style="background-color:#f2f2f2;height:10px" ></p>
                            
                                <div class="answer_detail_con" id="answer_441200">
                                    <div style="margin: 0 20px 0px;">
                                        <p style="font-size: 18px;">回答区</p>
                                    </div>
                                </div>
                            
                        <div class="common_con clearfix">
                            <div class="answer_list" style="margin-top:15px;width:100%">
                             

                                    <asp:DataList ID="datalistR" runat="server">
                                        <ItemTemplate>
                                    <dl class="clearfix">
                                        <dd class="answer_name" style="margin-left: 20px">
                                            <span style="color:blue"><%# Eval("StudentName") %></a>&nbsp;&nbsp;</span>
                                            <span class="adopt_time"><%# Eval("ReplyTime") %></span>
                                        </dd>
                                    </dl>

                                    <div style="margin: 0 20px 10px; font-size: 14px; color: #666; line-height: 24px; word-break: break-all; word-wrap: break-word;">
                                        <p><%# Eval("ReplyContent") %></p>
                                    </div>

                                    <hr align="center" width="1000px" color="lightgray" size="1">
                                            </ItemTemplate>
                                    </asp:DataList>
                                   
                                    
                                    
                                   
                            </div>

                                      <div visible="false" id="NONa" runat="server" class="answer_list" style="margin-top:15px">
                                <div class="answer_detail_con" id="Div2">
                                    <dl class="clearfix">
                                        <dd class="answer_name" style="margin-left: 20px">
                                            <a class="user_name" href="#" target="_blank"><%# Eval("StudentName") %></a>&nbsp;&nbsp;
                                            <span class="adopt_time"><%# Eval("ReplyTime") %></span>
                                        </dd>
                                    </dl>

                                    <div style="margin: 0 20px 10px; font-size: 14px; color: #666; line-height: 24px; word-break: break-all; word-wrap: break-word;">
                                         <center>咿呀，还没有人回答呢，提问的小主该急了。</center>
                                    </div>

                                    <hr align="center" width="100%" color="lightgray" size="1">                              
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        
        <div class="persion_article" style="margin-top:20px">
            <div class="mod_my_achievement hidden-sm hidden-xs">
                <div class="my_achievement clearfix">
                    <div class="achievement">
                        <h3><b >我的问答</b></h3>
        </div>
        <dl class="my_info clearfix">
          <div class="img">
            <a class="user_name"><img alt="" class="csdn-avatar50" " title="sinat_35559466" username="sinat_35559466"></a>

          </div>
          <dt style=" padding-left:40px;padding-top: 20px;"><a class="user_name" target="_blank"><b><%=name %></b></a></dt>
         
        </dl>
        <div class="my_progress">
        <div class="my_ask_info">
        	<div class="icon-A">问</div>
        	<div class="ask_answer">提了
        	<span>
        	<a href="community.aspx?method=DBind&methodid=6"><%=topic %></a>
        	</span>个问题</div>
        	<span>
        	
        	<div class="br"></div>
        	<div class="icon-B">答</div>
        	<div class="ask_answer">回答了<span>
            <div>
        	<a href="community.aspx?method=DBind&methodid=7" ><%=reply%></a></div>
        	</span>个问题</div>
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

                                            <a href="http://my.csdn.net/Spider_Black" target="_blank"></a>
                                        </dt>
                                        <dd class="mod_dl_dd_01">
                                            <a class="user_name" target="_blank"><%#Eval("studentname")%></a>
                                            <span>回答了：</span>
                                            <a class="mod_dl_a" ><%#Eval("replycontent") %>...</a>
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
        <div class=" hidden-sm hidden-lg hidden-md" style="margin-top:55px; background-color: #f6f6f6; font-family: 'Microsoft YaHei'; ">
            <ol class="breadcrumb" style="margin-top: 0px; margin-bottom: 0px; background-color: white">
                <li><a href="community.aspx">社区</a></li>
                <li><a style="color:black">帖子详情</a></li>
            </ol>
            <div class="container" style="margin-top: 10px; padding-top: 10px; background-color: white; border-bottom: 1px solid #808080">
                <div style=""><span style="color: blue"><%=studentname %></span>&nbsp;&nbsp;&nbsp;&nbsp;<span style="color: #999393; font-size: 12px">于<%=topictime %>提问</span></div>
                <div style="padding-top: 10px; padding-bottom: 10px; font-size: 18px;"><%=topictitle %></div>
                <div style="width: 100%; color: #4C4D4B">
                    <p><%=topiccontent %></p>
                </div>
            </div>
            <div class="container" style="margin-top: 10px; padding-top: 10px; background-color: white; border-bottom: 1px solid #808080">
                <p>回答区</p>
            </div>
            <asp:DataList ID="datalistRx" runat="server">
                <ItemStyle Width="1000px"  />
                <ItemTemplate>
                    <div class="container" style="padding-top: 10px; background-color: white; border-bottom: 1px solid #aca8a8">
                        <div style="padding-bottom: 10px"><span style="color: blue"><%# Eval("StudentName") %></span>&nbsp;&nbsp;&nbsp;&nbsp;<span style="color: #999393; font-size: 12px">于<%# Eval("ReplyTime") %>回答</span></div>
                        <div style="width: 100%;color:  #4C4D4B">
                            <p style="font-size:12px"><%# Eval("ReplyContent") %></p>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
            <div class="container" style="margin-top: 10px; padding-top: 10px; background-color: white; border-bottom: 1px solid #808080">
                <p>我要回答</p>
            </div>
            <div class="container" style=" padding-top: 10px; background-color: white; border-bottom: 1px solid #808080">
                
                <textarea runat="server" id="textareaHDx" rows="3" class="form-control" style="height: 80px; resize: none; padding-bottom: 5px;" placeholder="请认真回答哦"></textarea>
                <br />
                <div style="text-align:right;margin-bottom:20px">
                    <asp:Button runat="server" ID="Button1" class="btn btn-primary" OnClick="submitxs_Click" Text="提交回答" />
                </div>

            </div>
        </div>
        <!--手机端-->
    </form>
</body>
</html>
