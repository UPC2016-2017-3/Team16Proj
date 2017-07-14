<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VideoPage.aspx.cs" Inherits="VideoPage" %>

<!DOCTYPE html >

<html>
<head>
    <style>
        .play_name
        {
            cursor: pointer;
            border: 1px solid #fff;
        }

            .play_name:hover .ico_play
            {
                background-image: url(css/ico_play.png);
            }

        .ico_play
        {
            position: absolute;
            top: 50%;
            left: 50%;
            width: 110px;
            height: 102px;
        }

        .auto-style1
        {
            width: 31px;
            height: 32px;
        }
    </style>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8">
    <script type="text/javascript" src="../media/flowplayer-3.2.13.min.js"></script>
    <!-- some minimal styling, can be removed -->

    <!-- page title -->
    <meta charset="UTF-8">
    <title>课程学习</title>

    <script type="text/javascript">
        
    </script>

    <link href="../css/bootstrap.min.css" rel="stylesheet">
    <script src="../js/jquery-3.2.1.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <meta name="viewport" content="width=device-width,initial-scale=1.0,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no" id="viewport" />
    <script type="text/javascript" src="media/flowplayer-3.2.13.min.js"></script>
    <link rel="stylesheet" href="http://cdn.static.runoob.com/libs/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="http://cdn.static.runoob.com/libs/jquery/2.1.1/jquery.min.js"></script>
    <script src="http://cdn.static.runoob.com/libs/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="FlexPaper/js/jquery.js" type="text/javascript"></script>
    <script src="FlexPaper/js/flexpaper_flash_debug.js" type="text/javascript"></script>
    <script src="FlexPaper/js/flexpaper_flash.js" type="text/javascript"></script>
    <script type="text/javascript">
        function $(id) {
            return document.getElementById(id);
        }
        //------ajax Demo  By  jerry ----------------
        //创建xmlhttp对象
        function CreateXMLHTTP() {
            var XmlHttp;
            try {
                XmlHttp = new ActiveXObject("Msxml2.XMLHTTP");
            }
            catch (E) {
                try {
                    XmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
                }
                catch (E) {
                    XmlHttp = new XMLHttpRequest(); 
                }
            }
            return XmlHttp;
        }
        function Ajax(url) {
            var XmlHttp = CreateXMLHTTP();
            var z=document.getElementById("myVideo").readyState; 
            var x = document.getElementById("myVideo").duration;
            var y=document.getElementById("myVideo").currentTime;
            var temurl = url + "?played=" + y + "&length=" + x + "&readyState=" + z + "&method=record"; 
            XmlHttp.open("POST", temurl, true); 
            XmlHttp.onreadystatechange = function () {
                if (XmlHttp.readyState == 4 && XmlHttp.status == 200)
                {
                }
            }
            XmlHttp.send(null);
        }

       
    </script>
</head>
<body onunload="Ajax('ajax.aspx')">
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
								<li class="active"><a href="Home.aspx">首页</a></li>
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
    <form id="form2" runat="server">
        <div class="container" style="padding-top: 10px;">
            <div id="class-name-bar" style="background-color: dimgray">
                <ol class="breadcrumb" style="background-color: dimgray">
                    <li><a href="#" style="color: #FFFFFF; padding-bottom: 0;">首页</a></li>
                    <li><a href="#" style="color: #FFFFFF; padding-bottom: 0;"><%=Category%></a></li>
                    <li><a href="#" style="color: #FFFFFF; padding-bottom: 0;"><%=Class%></a></li>
                </ol>
                <h2 class="hidden-xs" id="uuuuu" style="color: #FFFFFF; padding-left: 30px; padding-bottom: 20px">&nbsp;&nbsp;&nbsp;<%=Class%></h2>

            </div>
            <div class="visible-xs" style="margin-bottom: 10px">
                <ul class="nav nav-tabs ">
                    <li class="active"><a href="#vedio-frame" data-toggle="tab"><b style="color: brown;">课程视频</b></a></li>
                    <li><a href="#ppt-frame" data-toggle="tab"><b style="color: brown;">课程PPT</b></a></li>
                    <li><a href="#audio-frame" data-toggle="tab"><b style="color: brown;">课程音频</b></a></li>
                </ul>
            </div>
            <div class=" hidden-xs ">
                <ul class="nav nav-tabs" style="float: right; margin-top: 10px">
                    <li class="active" onclick="v()"><a href="#vedio-frame" data-toggle="tab"><b style="color: brown;">课程视频</b></a></li>
                    <li onclick="p()"><a href="#ppt-frame" data-toggle="tab"><b style="color: brown;">课程PPT</b></a></li>
                    <li onclick="z()"><a href="#audio-frame" data-toggle="tab"><b style="color: brown;">课程音频</b></a></li>
                </ul>
            </div>
        </div>
        <script>
            function z() {
                document.getElementById("adown").style.display = "inline";
                document.getElementById("vdown").style.display = "none";
                document.getElementById("pdown").style.display = "none";
            }
        </script>
        <script>
          
            function p() {
                document.getElementById("pdown").style.display = "inline";
                document.getElementById("vdown").style.display = "none";
                document.getElementById("adown").style.display = "none";
            }
            function v() {
                document.getElementById("vdown").style.display = "inline";
                document.getElementById("pdown").style.display = "none";
                document.getElementById("adown").style.display = "none";
            }
          
        </script>
        <div class="container">
            <div id="Mulu" class="col-md-2 hidden-xs" style="display: inline; height: auto; width: 22%;">
                <h4>课程目录</h4>
                <div style="background-color: gainsboro; height: auto; width: 100%">
                    <a href="#" class="list-group-item active" style="background-color: brown;"><%=Class%></a>
                    <asp:DataList ID="DataListM1" runat="server" Style="width: 100%">
                        <ItemTemplate>
                            <div onclick="changeunit(<%# Eval("UnitID") %>)">
                                <a href="#" class="list-group-item">课时<%# Container.ItemIndex+1%>&nbsp;&nbsp;<%# Eval("UnitName")%></a>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            </div>

            <div style="display: inline;">
                <div id="tubiao" class="hidden-xs btn btn-primary" style="background-color: brown; margin-top: 5px"><b id="n"><<</b></div>
                <asp:Button runat="server" ID="collect" class="hidden-xs btn btn-primary" Style="float: right; margin-top: 5px;" Text="收藏" OnClick="btn_Collect_Click"></asp:Button>
                <a href="<%=strURL %>" id="vdown" class="hidden-xs btn btn-primary" style="background-color: brown; float: right; margin-top: 5px; margin-right: 10px"><b>下载</b></a>
                <a href="<%=ppturl %>" id="pdown" class="hidden-xs btn btn-primary" style="background-color: brown; float: right; margin-top: 5px; margin-right: 10px; display: none"><b>下载</b></a>
                <a href="<%=audiourl %>" id="adown" class="hidden-xs btn btn-primary" style="background-color: brown; float: right; margin-top: 5px; margin-right: 10px; display: none"><b>下载</b></a>

            </div>
            <script type="text/javascript" src="FlexPaper/js/jquery.js"></script>
            <script type="text/javascript">
                $(document).ready(function () {
                    $('#tubiao').click(function () {
                        $('#Mulu').animate({ width: 'toggle' }, 100);
                        if ($('#n').text() == "<<") {
                            $('#n').text(">>");
                        } else {
                            $('#n').text("<<");
                        }
                    });
                });
            </script>
            <div id="TabContent" class="tab-content" style="display: inline;">
                <div id="audio-frame" class="tab-pane fade">
                    <div class="embed-responsive embed-responsive-16by9 " style="text-align: center;">
                       
                        <p ><label id="myaudioname" runat="server"><%=audioname %></label>    </p>
                        <audio id="myAudio" src="<%=audiourl%>" controls="controls" preload="auto" loop="loop" />
                    </div>
                </div>

                <div id="ppt-frame" class="tab-pane fade">
                    <div class="embed-responsive embed-responsive-16by9 ">
                        <div class="visible-xs" style="text-align: center">
                            <p>暂不支持手机预览PPT哦~</p>
                            <a href="<%=ppturl %>" class="btn btn-primary" style="background-color: brown; margin-top: 5px;"><b>下载</b></a>
                        </div>
                        <a id="viewerPlaceHolder" class="hidden-xs" style="width: 660px; height: 480px;"></a>
                        <script type="text/javascript">    
                            var a="<%=ppturl%>";
                            function changeunit(uid) {

                                $.ajax({
                                    url: "Default.aspx/AjaxMethod", //发送到本页面后台AjaxMethod方法
                                    type: "POST",
                                    dataType: "json",
                                    async: true, //async翻译为异步的，false表示同步，会等待执行完成，true为异步
                                    contentType: "application/json; charset=utf-8", //不可少
                                    data: "{param2:'" + uid + "'}",
                                    success: function (data) {
                                        Ajax('ajax.aspx');

                                        if (data != "") {
                                            var json = JSON.parse(data.d);

                                            $.each(json, function (index) {
                                                var VideoUrl = json[index].videourl;
                                                a = json[index].SwfURL;
                                                var Ppt2Url = json[index].PPTURL;
                                                var AudioUrl = json[index].AudioURL;
                                                var AudioName = json[index].AudioName;
                                                $("#myVideo").attr("src", VideoUrl);
                                                $("#myAudio").attr("src", AudioUrl);
                                                $("#vdown").attr("href", VideoUrl);
                                                $("#pdown").attr("href", Ppt2Url);
                                                $("#adown").attr("href", AudioUrl);
                                                //$("#myaudioname").innerHTMlL = AudioName;
                                                document.getElementById('myaudioname').innerHTML = AudioName;
                                                exchang();
                                            });
                                        }
                                    },
                                    error: function () {

                                        alert("请求出错处理");
                                    }
                                });
                            }; 

                            function exchang(){
                                var fp = new FlexPaperViewer(
                            'FlexPaper/FlexPaperViewer',
                            'viewerPlaceHolder',
                            {
                                config: {
                                    SwfFile: escape(a),
                                    Scale: 0.6,
                                    ZoomTransition: 'easeOut',
                                    ZoomTime: 0.5,
                                    ZoomInterval: 0.2,
                                    FitPageOnLoad: false,
                                    FitWidthOnLoad: false,
                                    PrintEnabled: true,
                                    FullScreenAsMaxWindow: false,
                                    ProgressiveLoading: false,
                                    MinZoomSize: 0.2,
                                    MaxZoomSize: 5,
                                    SearchMatchAll: false,
                                    InitViewMode: 'Portrait',
                                    ViewModeToolsVisible: true,
                                    ZoomToolsVisible: true,
                                    NavToolsVisible: true,
                                    CursorToolsVisible: true,
                                    SearchToolsVisible: true,
                                    localeChain: 'en_US'
                                }
                            }
                                );
                            }
                        </script>
                    </div>
                </div>

                <div id="vedio-frame" class="tab-pane fade in active ">
                    <div class="embed-responsive embed-responsive-16by9 play_name ">
                        <video id="myVideo" class="embed-responsive-item" style="padding-top: 5px;" src="<%=strURL%>" onended="Ajax('ajax.aspx')">
                            <param name="wmode" value="opaque" />
                            <param name="vmode" value="opaque" />
                            您的浏览器不支持Video标签。
                        </video>
                        <div class="ico_play" id="con" onclick="setCurTime()"></div>
                    </div>
                </div>

            </div>
        </div>

        <div class="container" style="margin-top: 30px">
            <ul id="myTab" class="nav nav-tabs">
                <li class="visible-xs">
                    <a href="#mulu" data-toggle="tab">
                        <b style="color: brown;">目录</b>
                    </a>
                </li>
                <li class="active">
                    <a href="#home" data-toggle="tab">
                        <b style="color: brown;">评论</b>
                    </a>
                </li>
                <li><a href="#ios" data-toggle="tab"><b style="color: brown;">问答</b></a></li>
            </ul>

            <div id="myTabContent" class="tab-content">
                <div id="mulu" class="tab-pane fade  hidden-md hidden-lg" style="padding-top: 20px; padding-left: 20px; padding-right: 20px; height: auto;">

                    <div style="background-color: gainsboro; height: auto; width: 100%">
                        <a href="#" class="list-group-item active" style="background-color: brown;"><%=Class%></a>
                        <asp:DataList ID="DataListM2" runat="server" Style="width: 100%">
                            <ItemTemplate>
                                <div onclick="changeunit(<%# Eval("UnitID") %>)">
                                    <a href="#" class="list-group-item">课时<%# Container.ItemIndex+1%>&nbsp;&nbsp;<%# Eval("UnitName")%></a>
                                </div>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>

                </div>
                <div class="tab-pane fade in active" id="home">
                    <!--<p>菜鸟教程是一个提供最新的web技术站点，本站免费提供了建站相关的技术文档，帮助广大web技术爱好者快速入门并建立自己的网站。菜鸟先飞早入行——学的不仅是技术，更是梦想。</p>-->
                    <div class="row" style="padding-top: 25px;">
                        <div class="col-sm-10 col-sm-offset-1 form-group">
                            <!--<input style="height: 100px;" type="text" class="form-control" id="lastname" placeholder="请输入姓">-->
                            <textarea runat="server" id="CommentText" rows="3" class="form-control" style="height: 80px; resize: none; padding-bottom: 5px;" placeholder="鼓励、吐槽、表演，想说啥就说啥"></textarea>
                            <br />
                            <asp:Button runat="server" ID="btn_Comment" type="button" class="btn btn-primary" Style="font-weight: bold; background-color: brown; border-radius: 5px; float: right;" OnClick="btn_Comment_Click" Text="评论" />
                            <%--<b>评论</b></asp:Button>--%>
                            <%--type="button"--%>
                        </div>
                    </div>
                    <div class="row" style="padding-top: 10px">
                        <div class="col-md-10 col-md-offset-1 col-xs-12">
                            <asp:DataList ID="DataList1" runat="server" CellSpacing="5" RepeatDirection="Vertical">
                                <ItemTemplate>
                                    <div class="row" style="padding-top: 2px;">
                                        <div class="col-sm-12 form-group">
                                            <li class="list-group-item media" style="margin-top: 5px;">
                                                <div class="media-left item-avatar">
                                                    <img class="img-circle media-object" src="img/picture4.jpg" height="50" width="50" />
                                                </div>
                                                <div class="media-body">
                                                    <span class="media-heading">
                                                        <label style="color: #4C4D4B; margin-top: 18px"><%# Eval("StudentName")%></label>
                                                    </span>

                                                    <div>
                                                        <p style="font: '微软雅黑'; font-size: small; color: #4C4D4B;"><%# Eval("DiscussContent") %></p>

                                                        <div class="small gray">
                                                            <a class="btn-xs node small"></a>
                                                            <p style="color: #4C4D4B;">
                                                                提问时间：
   							        	                                <span><%# Eval("DiscussTime") %></span>
                                                            </p>
                                                        </div>
                                                    </div>
                                                </div>
                                            </li>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:DataList>
                        </div>
                        <%--</form>--%>
                        <br />
                        <!--<div class="col-md-10 col-md-offset-1" style="height: 40px;">
					            <p style="border-bottom-right-radius: 5px;" class="bg-warning">赞同楼上</p>
				             </div>-->
                    </div>
                </div>


                <!--问答区-->
                <div class="tab-pane fade" id="ios">
                    <div class="row" style="padding-top: 25px;">
                        <div class="col-sm-10 col-sm-offset-1 form-group">
                            <img class="img-circle media-object" src="img/picture4.jpg" height="40" width="40" />
                            <textarea runat="server" id="TextareaQT" rows="1" class="form-control" style="height: 40px; resize: none; padding-bottom: 5px; margin-top: 5px;" placeholder="请输入提问标题"></textarea>
                            <br />
                            <textarea runat="server" id="TextareaQC" onkeyup="checklength(this)" rows="4" class="form-control" style="height: 80px; resize: none; padding-bottom: 5px; overflow-y: scroll;" placeholder="请尽量用通俗且描述完整的语句说明问题，所提问题要与本课程相关哦~"></textarea>
                            <br />
                            <div style="float: right">您还可以输入<span id="result">140</span>/140个字</div>
                            <br />
                            <asp:Button runat="server" ID="ButtonQ" type="button" class="btn btn-primary" Style="font-weight: bold; background-color: brown; border-radius: 5px; float: right;" OnClick="btn_Question_Click" Text="提问" />
                        </div>
                    </div>

                    <asp:DataList ID="datalistQ" runat="server" CellSpacing="5" RepeatDirection="Vertical">
                        <ItemTemplate>
                            <div class="row" style="padding-top: 2px;">
                                <div class="col-sm-10 col-sm-offset-1 form-group">
                                    <li class="list-group-item media" style="margin-top: 5px;">
                                        <div class="media-left item-avatar">
                                            <img class="img-circle media-object" src="img/picture4.jpg" height="50" width="50" />
                                        </div>
                                        <div class="media-body">
                                            <span class="media-heading">
                                                <label style="color: #4C4D4B; margin-top: 18px"><%# Eval("StudentName")%></label>
                                            </span>
                                            <label style="font: '微软雅黑'; color: #606099; margin-left: 8px;"><%# Eval("QuestionTitle") %></label>
                                            <div>
                                                <p style="font: '微软雅黑'; font-size: small; color: #4C4D4B;"><%# Eval("QuestionContent") %></p>
                                                <div>
                                                    <p style="color: #4C4D4B;">[最新 <strong><%# Eval("ManagerName") %></strong> 的回复] <%# Eval("AnswerContent") %></p>
                                                </div>
                                                <div class="small gray">
                                                    <a class="btn-xs node small"></a>
                                                    <p style="color: #4C4D4B;">
                                                        提问时间：
   							        	<span><%# Eval("QuestionTime") %></span>
                                                    </p>
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
                <div style="height: 400px;"></div>
            </div>
        </div>
    </form>
    <script type="text/javascript" src="FlexPaper/js/jquery.js"></script>
    <script type="text/javascript">
        $("#TextareaQC").bind('input', function () {
            var bb = $('#TextareaQC').val();//
            var cc = bb.substring(0, 140);//
            $('#TextareaQC').val(cc);//该三行写在“input”函数外面也可以
            var aa = $(this).val().length;
            if (aa < 140) {
                $('#result').html(140 - $(this).val().length);
            } else {
                $('#result').html("0");
            }
        })   
    </script>
    <script type="text/javascript" src="./../js/jquery.js"></script>
    <script>
        var x = document.getElementById("myVideo");
        var con=document.getElementById("con");
       
        
        function setCurTime() {
            x.play();
            x.currentTime = <%=lasttime %> ;
            x.controls="control";
            con.style.display="none";
       
        } 
        function resetCurTime(){
            x.play();
            x.controls="control";
            con.style.display="none";
       
        }
    </script>
</body>
</html>
