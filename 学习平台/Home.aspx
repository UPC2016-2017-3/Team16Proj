<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<!DOCTYPE html>
<html>
	<head>
		<meta charset="UTF-8">
		<title>首页</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/> 
        <meta name="viewport" content="width=device-width,initial-scale=1.0,minimum-scale=1.0,maximum-scale=1.0,user-scalable=no" id="viewport"/>    
        <script src="js/jquery-3.2.1.min.js"></script>
        <script src="dist/js/bootstrap.min.js"></script>
        <link href="dist/css/bootstrap.min.css" rel="stylesheet"/>
        <link rel="stylesheet" href="css/home.css"/>
	</head>	
	
	<body style="background-color: #EAECEB">
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

                console.log(s);
                //window.open('SearchResult.aspx?search=' + s, "_blank");
                window.open('SearchResult.aspx?search=' + s + '&type=1', "_blank");


            }
        </script>

		<!--以上是导航条代码-->
		<form id="form2" runat="server">
		<div class="container" style="padding-bottom:0;">
		<div class="col-lg-3 hidden-sm hidden-xs hidden-md" >
        		<ul id="ul1" class="nav nav-pills nav-stacked" style="background-color:#D0D0D0 ;padding-bottom:0;height:454px;color:black;">
        			<li><a href="SearchResult.aspx?search=1&type=2">暗光高清拍摄技术 ></a></li>
 	                <li><a href="SearchResult.aspx?search=2&type=2">防抖技术 ></a></li>
 	                <li><a href="SearchResult.aspx?search=3&type=2">全景技术 ></a></li>
 	                <li><a href="SearchResult.aspx?search=4&type=2">人脸技术 ></a></li>
                	<li><a href="SearchResult.aspx?search=5&type=2">HDR技术 ></a></li>
                    <li><a href="SearchResult.aspx?search=6&type=2">手势识别技术 ></a></li>
 	                <li><a href="SearchResult.aspx?search=7&type=2">场景检测与物体识别技术 ></a></li>
 	                <li><a href="SearchResult.aspx?search=8&type=2">体感技术 ></a></li>
 	                <li><a href="SearchResult.aspx?search=9&type=2">3D立体成像技术 ></a></li>
 	                <li><a href="SearchResult.aspx?search=10&type=2">AR/VR技术 ></a></li>
               </ul>
        </div>
        
        <div id="myCarousel" class="carousel slide col-lg-9">
        	<ol class="carousel-indicators">
               <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
               <li data-target="#myCarousel" data-slide-to="1"></li>
               <li data-target="#myCarousel" data-slide-to="2"></li>
               <li data-target="#myCarousel" data-slide-to="3"></li>
            </ol>
        	<div class="carousel-inner">
        	<div class="active item embed-responsive embed-responsive-16by9"><img class="img-responsive center-block" src="img/home/picture2.jpg"/></div>
        	<div class="item embed-responsive embed-responsive-16by9"><img class="img-responsive center-block" src="img/home/picture3.jpg"/></div>
        	<div class="item embed-responsive embed-responsive-16by9"><img class="img-responsive center-block" src="img/home/picture4.jpg"/></div>
        	<div class="item embed-responsive embed-responsive-16by9"><img class="img-responsive center-block" src="img/home/picture5.jpg"/></div>
            </div>
            <a class="carousel-control left" href="#myCarousel"  data-slide="prev"></a>
            <a class="carousel-control right" href="#myCarousel" data-slide="next"></a>
        </div>
    </div> 
    </form>
	</body>
	<!--推荐课程与免费课程-->

     <!--推荐课程-->
        <div class="container">
			<div class="commend" style="margin-left: 15px;margin-top:30px;">
				<p>推荐课程</p>
			</div>
            <div class="col-md-3 col-sm-6 hidden-xs" >
           <a href="VideoPage.aspx?classid=<%=classid1%>">
				<div class="course" >  
					<div class="top" style="background:url(img/ph4.png);">
                        <%--<img src="img/ph1.png" class="img-responsive" >--%>
						<img src="img/雪花.png" alt="图片描述" />
						<label style="margin-left:3px;"><%=category1%></label>
					</div>
					<div class="text">
					    <p><%=classname1%></p>
                        <p style="overflow: hidden;text-overflow: ellipsis;display: -webkit-box;-webkit-line-clamp: 3;-webkit-box-orient: vertical;"><%=classinfo1%></p>	                        
					</div>
					<div class="department">
						<label><%=departmentname1%></label>
						<img src="img/美元.png" alt="图片描述" />
                        <label><%=classprice1%></label>
					</div>                
				</div>
			
            </a>
           </div>
            <div class="col-md-3 col-sm-6 hidden-xs" >
           <a href="VideoPage.aspx?classid=<%=classid2%>">
				
				<div class="course" >  
					<div class="top" style="background:url(img/ph2.png);">
						<img src="img/雪花.png" alt="图片描述" />
						<label style="margin-left:3px;"><%=category2%></label>
					</div>
					<div class="text">
					       <p><%=classname2%></p>
                        <p style="overflow: hidden;text-overflow: ellipsis;display: -webkit-box;-webkit-line-clamp: 3;-webkit-box-orient: vertical;"><%=classinfo2%></p>	                        
					</div>
					<div class="department">
						<label><%=departmentname2%></label>
						<img src="img/美元.png" alt="图片描述" />
                        <label><%=classprice2%></label>
					</div>                
				</div>
			
            </a>
           </div>
            <div class="col-md-3 col-sm-6 hidden-xs" >
           <a href="VideoPage.aspx?classid=<%=classid3%>">
				
				<div class="course" >  
					<div class="top" style="background:url(img/ph3.png);">
						<img src="img/雪花.png" alt="图片描述" />
						<label style="margin-left:3px;"><%=category3%></label>
					</div>
					<div class="text">
					    <p><%=classname3%></p>
                        <p style="overflow: hidden;text-overflow: ellipsis;display: -webkit-box;-webkit-line-clamp: 3;-webkit-box-orient: vertical;"><%=classinfo3%></p>	                        
					</div>
					<div class="department">
						<label><%=departmentname3%></label>
						<img src="img/美元.png" alt="图片描述" />
                        <label><%=classprice3%></label>
					</div>                
				</div>
			
            </a>
           </div>
            <div class="col-md-3 col-sm-6 hidden-xs" >
           <a href="VideoPage.aspx?classid=<%=classid4%>">
				
				<div class="course" >  
					<div class="top" style="background:url(img/ph5.png);">
						<img src="img/雪花.png" alt="图片描述" />
						<label style="margin-left:3px;"><%=category4%></label>
					</div>
					<div class="text">
					     <p><%=classname4%></p>
                        <p style="overflow: hidden;text-overflow: ellipsis;display: -webkit-box;-webkit-line-clamp: 3;-webkit-box-orient: vertical;"><%=classinfo4%></p>	                        
					</div>
					<div class="department">
						<label><%=departmentname4%></label>
						<img src="img/美元.png" alt="图片描述" />
                        <label><%=classprice4%></label>
					</div>                
				</div>
			
            </a>
           </div>
        </div>

            <!--手机推荐课程-->
        <div class="container">
            <div class="hidden-lg hidden-md hidden-sm col-xs-6" >
           <a href="VideoPage.aspx?classid=<%=classid1%>">
				
				<div class="course1"  > 
                     					             
				</div>
			    <div class="text">
					    <p style="width:140px;font-size:12px;"><%=classname1%></p>
					</div>
				<div style="margin-top:0px;font-size:5px;">
                        <label style="font-size:8px;color:#a6a0a0" >&nbsp;<%=departmentname1%></label>
                        <label style="color:#fa2424;margin-right:5px;">￥<%=classprice1%></label>
					</div>   
            </a>
           </div>
            <div class="hidden-lg hidden-md hidden-sm col-xs-6" >
            <a href="VideoPage.aspx?classid=<%=classid2%>">
				
				<div class="course1"  >  					             
				</div>
			    <div class="text">
					    <p style="width:140px;font-size:12px;"><%=classname2%></p>
					</div>
				<div style="margin-top:0px;font-size:5px;">
                        <label style="font-size:8px;color:#a6a0a0" >&nbsp;<%=departmentname2%></label>
                        <label style="color:#fa2424;margin-right:5px;">￥<%=classprice2%></label>
					</div>   
            </a>
           </div>
            <div class="hidden-lg hidden-md hidden-sm col-xs-6" >
            <a href="VideoPage.aspx?classid=<%=classid3%>">
				
				<div class="course1"  >  					             
				</div>
			    <div class="text">
					    <p style="width:140px;font-size:12px;"><%=classname3%></p>
					</div>
				<div style="margin-top:0px;font-size:5px;">
                        <label style="font-size:8px;color:#a6a0a0" >&nbsp;<%=departmentname3%></label>
                        <label style="color:#fa2424;margin-right:5px;">￥<%=classprice3%></label>
					</div>   
            </a>
              </div>
            <div class="hidden-lg hidden-md hidden-sm col-xs-6" >
           <a href="VideoPage.aspx?classid=<%=classid4%>">
				
				<div class="course1"  >  					             
				</div>
			    <div class="text">
					    <p style="width:140px;font-size:12px;"><%=classname4%></p>
					</div>
				<div style="margin-top:0px;font-size:5px;">
                        <label style="font-size:8px;color:#a6a0a0" >&nbsp;<%=departmentname4%></label>
                        <label style="color:#fa2424;margin-right:5px;">￥<%=classprice4%></label>
					</div>   
            </a>
              </div>
        </div>

    <!--免费课程-->
         <div class="container">
			<div class="commend" style="margin-top: 50px;">
                <p>&nbsp;</p>
				<p>免费课程</p>
			</div>
           
            <div class="col-md-3 col-sm-6 hidden-xs"  >
          <a href="VideoPage.aspx?classid=<%=classid5%>">	
                <div class="course" >
					<div class="top">
						<img src="img/雪花.png" alt="图片描述" />
						<label style="margin-left:3px;"><%=category5%></label>
					</div>
					<div class="text">
					    <p><%=classname5%></p>
					    <p style="overflow: hidden;text-overflow: ellipsis;display: -webkit-box;-webkit-line-clamp: 3;-webkit-box-orient: vertical;"><%=classinfo5%></p>	
					</div>
					<div class="department">
						<label><%=departmentname5%></label>
						<img src="img/home/免费.png" alt="图片描述" />
						<label></label>
					</div>
				</div> 
                </a>             
			</div>
       
            <div class="col-md-3 col-sm-6 hidden-xs"  >
           <a href="VideoPage.aspx?classid=<%=classid6%>">	
                <div class="course" >
					<div class="top">
						<img src="img/雪花.png" alt="图片描述" />
						<label style="margin-left:3px;"><%=category6%></label>
					</div>
					<div class="text">
					    <p><%=classname6%></p>
					    <p style="overflow: hidden;text-overflow: ellipsis;display: -webkit-box;-webkit-line-clamp: 3;-webkit-box-orient: vertical;"><%=classinfo6%></p>	
					</div>
					<div class="department">
						<label><%=departmentname6%></label>
						<img src="img/home/免费.png" alt="图片描述" />
						<label></label>
					</div>
				</div> 
                </a>             
			</div>
       
            <div class="col-md-3 col-sm-6 hidden-xs"  >
          <a href="VideoPage.aspx?classid=<%=classid7%>">	
                <div class="course" >
					<div class="top">
						<img src="img/雪花.png" alt="图片描述" />
						<label style="margin-left:3px;"><%=category7%></label>
					</div>
					<div class="text">
					    <p><%=classname7%></p>
					    <p style="overflow: hidden;text-overflow: ellipsis;display: -webkit-box;-webkit-line-clamp: 3;-webkit-box-orient: vertical;"><%=classinfo7%></p>	
					</div>
					<div class="department">
						<label><%=departmentname7%></label>
						<img src="img/home/免费.png" alt="图片描述" />
						<label></label>
					</div>
				</div> 
                </a>             
			</div>
       
            <div class="col-md-3 col-sm-6 hidden-xs"  >
           <a href="VideoPage.aspx?classid=<%=classid8%>">
                <div class="course" >
					<div class="top">
						<img src="img/雪花.png" alt="图片描述" />
						<label style="margin-left:3px;"><%=category8%></label>
					</div>
					<div class="text">
					    <p><%=classname8%></p>
					    <p style="overflow: hidden;text-overflow: ellipsis;display: -webkit-box;-webkit-line-clamp: 3;-webkit-box-orient: vertical;"><%=classinfo8%></p>	
					</div>
					<div class="department">
						<label><%=departmentname8%></label>
						<img src="img/home/免费.png" alt="图片描述" />
						<label></label>
					</div>
				</div> 
                </a>             
			</div>
          </div>

            <div class="container">
            <div class="hidden-lg hidden-md hidden-sm col-xs-6" >
            <a href="VideoPage.aspx?classid=<%=classid5%>">
				
				<div class="course1"  >  					             
				</div>
			    <div class="text">
					    <p style="width:140px;font-size:12px;"><%=classname5%></p>
					</div>
				<div style="margin-top:0px;font-size:5px;">
                        <label style="font-size:8px;color:#a6a0a0" >&nbsp;<%=departmentname5%></label>
                        <label style="color:#fa2424;margin-right:5px;">免费</label>
					</div>   
            </a>
           </div>
            <div class="hidden-lg hidden-md hidden-sm col-xs-6" >
            <a href="VideoPage.aspx?classid=<%=classid6%>">
				
				<div class="course1"  >  					             
				</div>
			    <div class="text">
					    <p style="width:140px;font-size:12px;"><%=classname6%></p>
					</div>
				<div style="margin-top:0px;font-size:5px;">
                        <label style="font-size:8px;color:#a6a0a0" >&nbsp;<%=departmentname6%></label>
                        <label style="color:#fa2424;margin-right:5px;">免费</label>
					</div>   
            </a>
           </div>
            <div class="hidden-lg hidden-md hidden-sm col-xs-6" >
            <a href="VideoPage.aspx?classid=<%=classid7%>">
				
				<div class="course1"  >  					             
				</div>
			    <div class="text">
					    <p style="width:140px;font-size:12px;"><%=classname7%></p>
					</div>
				<div style="margin-top:0px;font-size:5px;">
                        <label style="font-size:8px;color:#a6a0a0" >&nbsp;<%=departmentname7%></label>
                        <label style="color:#fa2424;margin-right:5px;">免费</label>
					</div>   
            </a>
              </div>
            <div class="hidden-lg hidden-md hidden-sm col-xs-6" >
           <a href="VideoPage.aspx?classid=<%=classid8%>">
				
				<div class="course1"  >  					             
				</div>
			    <div class="text">
					    <p style="width:140px;font-size:12px;"><%=classname8%></p>
					</div>
				<div style="margin-top:0px;font-size:5px;">
                        <label style="font-size:8px;color:#a6a0a0" >&nbsp;<%=departmentname8%></label>
                        <label style="color:#fa2424;margin-right:5px;">免费</label>
					</div>   
            </a>
              </div>
        </div>
      <div class="container">
			<div class="tailor" >
				<label><a href="http://www.arcsoft.com.cn/" target="_blank">虹软公司</a></label>
				<label>企业注册</label>
				<label>联系我们</label>
				<label>常见问题</label>
				<label>意见反馈</label>
				<br />
				<br />
				<label class="hidden-xs">Copyright @2013-2017 摄影艺术家  hongruan.com All Rights Reserved. 备案号：鲁ICP备15012807号-1 </label>
			</div>
		</div> 

</html>