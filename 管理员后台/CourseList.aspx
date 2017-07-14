<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CourseList.aspx.cs" Inherits="CourseList" EnableEventValidation="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
     <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
	<meta content="" name="description" />
    <meta content="webthemez" name="author" />
    <title>管理员回答页</title>
	  <!-- Bootstrap Styles-->
    <link href="assets/css/bootstrap.css" rel="stylesheet" />
     <!-- FontAwesome Styles-->
    <link href="assets/css/font-awesome.css" rel="stylesheet" />
    <!-- Morris Chart Styles-->   
    <!-- Custom Styles-->
    <!-- Google Fonts-->
    <link href='https://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />
    <!-- TABLE STYLES-->
    <link href="assets/js/dataTables/dataTables.bootstrap.css" rel="stylesheet" />
    <link href="assets/css/tbcss.css" rel="stylesheet" />
    <!-- jQuery Js -->
    <script src="assets/js/jquery-1.10.2.js"></script>
      <!-- Bootstrap Js -->
    <script src="assets/js/bootstrap.min.js"></script>
    <!-- Metis Menu Js -->
    <script src="assets/js/jquery.metisMenu.js"></script>
     <!-- DATA TABLE SCRIPTS -->
    <script src="assets/js/dataTables/jquery.dataTables.js"></script>
    <script src="assets/js/dataTables/dataTables.bootstrap.js"></script>
        
         <!-- Custom Js -->
    <script src="assets/js/custom-scripts.js"></script>
    <script src="assets/js/dataTables/jquery.dataTables.js"></script>
    <script src="assets/js/dataTables/dataTables.bootstrap.js"></script>
        <script>
            $(document).ready(function () {
                $('#dataTables-example').dataTable();
            });
    </script>
         <!-- Custom Js -->
    <script src="assets/js/custom-scripts.js"></script>
    
</head>
<body style="background-color:#EDEDED">
    <form id="form1" runat="server">
        
    <div >
			  <div class="header"> 
                        <h1 class="page-header" style="margin-left:25px;">
                            管理课程 <small>请先新建课程，再上传单元</small>
                        </h1>
                  <%-- 上传课程和搜索框--%>
                  <div>
                      <div style="float:left;">				
					          <p><a href="上传课程.aspx" style="font-size:20px;margin-left:30px;">点此新建课程</a></p>
                      </div>
                      <div style="float: right;margin-right:35px;">
                         <input id="SearchText" type="text" runat="server" placeholder="输入课程名或课程简介..."  style="width: 180px; display: inline;height:34px;padding-left:10px; border-radius:6px; border:1px #EDEDED solid"/>
                         <asp:LinkButton ID="LinkButton1" Text="搜索" CommandName="next"  OnCommand="Search_OnClick" runat="server" class="btn btn-primary btn-sm"/>          
                      </div>
                  </div>
		        <%-- 动态绑定的课程列表--%>
                    <div  class="panel panel-success" style="margin-top:75px;margin-right:25px;margin-left:25px;">
                        <asp:DataList id="DataList_course" runat="server" RepeatDirection="Horizontal" RepeatColumns="4"  BorderStyle="Double"  >
                            <ItemTemplate >   
                   <%-- 课程封面——上--%>
                               
                        <div  style="height:35px; text-align:center;font-size:18px;color:white;border-radius:5px; background-color:#9e2727 ;padding-top:11px;">
                             <%#Eval("CategoryName")%> 
                        </div>         
                         &nbsp;
                   <%--课程封面——中--%>
                        <div  style="margin-left:6px;margin-right:6px;min-height:30px;">
                           <p style="font: '微软雅黑';font-size: medium;color:#4D4C50 ;"><%#Eval("ClassName")%></p>              
                           &nbsp;
                           <p title="<%#Eval("ClassInfo")%>" style="color:#93999f;height:42px;"><%#FormatFoo(Eval("ClassInfo"))%></p>
                        </div>
                        <hr style="border:1px #EDEDED solid; margin-bottom:8px;" />   
                   <%-- 课程封面——下 --%>  
                        <div style="height:20px;width:200px;color:#93999f;font-size:8px;height:20px;padding-top:6px;">
                           <p style="float:left;padding-left:8px;"><%#Eval("DepartmentName")%></p> 
                           <asp:LinkButton ID="Button1" runat="server" style="float:right;padding-right:1px;" OnCommand="Button1_Command"  CommandArgument='<%# DataBinder.Eval 
                                         (Container.DataItem,"ClassID") %>'>管理课程</asp:LinkButton>
                           <p  style="float:right;padding-right:4px;">￥<%#Eval("ClassPrice")%></p>
                           <p  style="float:right;padding-right:2px;"><%#Eval("ClassOpenness")%></p>       
                          
                          
                        </div>   
                             </ItemTemplate>
                            
                         </asp:DataList> 
                    </div>
                </div>
            
                   <!-- 静态课程列表页面-->
           <%-- <div class="row" style="margin-left:20px;margin-right:20px;">
                <div class="col-md-3 col-sm-3" style="margin-left:30px;">
                    <div class="panel panel-default">
                        <div class="panel-heading" style="text-align:center">
                           摄影技术
                        </div>
                        <div class="panel-body" style="margin-left:20px;margin-right:20px;">
                            <p style="font: '微软雅黑';font-size: medium;color:#4D4C50 ;">Oeasy教你玩转后期剪辑Premiere</p>
                             <p title="Oeasy教你玩转后期剪辑Premiere,详细介绍如何使用" style="color:#93999f">Oeasy教你玩转后期剪辑Premiere,详细介绍如何使用</p>
                        </div>
                        <div class="panel-footer" style="height:43px;color:#93999f;font-size:8px;">
                           <p style="float:left;margin-left:20px;">实习部</p> 
                             <p  style="float:left;margin-left:65px;">公开</p>       
                           <p  style="float:right;margin-right:25px;">￥30</p>
                          
                        </div>
                    </div>
                </div>
                <div class="col-md-3 col-sm-3">
                    <div class="panel panel-default">
                        <div class="panel-heading" style="text-align:center">
                           摄影技术
                        </div>
                        <div class="panel-body" style="margin-left:20px;margin-right:20px;">
                            <p style="font: '微软雅黑';font-size: medium;color:#4D4C50 ;">Oeasy教你玩转后期剪辑Premiere</p>
                             <p title="Oeasy教你玩转后期剪辑Premiere,详细介绍如何使用" style="color:#93999f">Oeasy教你玩转后期剪辑Premiere,详细介绍如何使用</p>
                        </div>
                        <div class="panel-footer" style="height:43px;color:#93999f;font-size:8px;">
                           <p style="float:left;margin-left:20px;">实习部</p> 
                             <p  style="float:left;margin-left:65px;">非公开</p>       
                           <p  style="float:right;margin-right:25px;display:none">￥30</p>
                          
                        </div>
                    </div>
                </div>
                <div class="col-md-3 col-sm-3">
                    <div class="panel panel-default">
                        <div class="panel-heading" style="text-align:center">
                           摄影技术
                        </div>
                        <div class="panel-body" style="margin-left:20px;margin-right:20px;">
                            <p style="font: '微软雅黑';font-size: medium;color:#4D4C50 ;">Oeasy教你玩转后期剪辑Premiere</p>
                             <p title="Oeasy教你玩转后期剪辑Premiere,详细介绍如何使用" style="color:#93999f">Oeasy教你玩转后期剪辑Premiere,详细介绍如何使用</p>
                        </div>
                        <div class="panel-footer" style="height:43px;color:#93999f;font-size:8px;">
                           <p style="float:left;margin-left:20px;">实习部</p> 
                             <p  style="float:left;margin-left:65px;">公开</p>       
                           <p  style="float:right;margin-right:25px;">￥30</p>
                          
                        </div>
                    </div>
                </div>
                <div class="col-md-3 col-sm-3">
                    <div class="panel panel-default">
                        <div class="panel-heading" style="text-align:center">
                           摄影技术
                        </div>
                        <div class="panel-body" style="margin-left:20px;margin-right:20px;">
                            <p style="font: '微软雅黑';font-size: medium;color:#4D4C50 ;">Oeasy教你玩转后期剪辑Premiere</p>
                             <p title="Oeasy教你玩转后期剪辑Premiere,详细介绍如何使用" style="color:#93999f">Oeasy教你玩转后期剪辑Premiere,详细介绍如何使用</p>
                        </div>
                        <div class="panel-footer" style="height:43px;color:#93999f;font-size:8px;">
                           <p style="float:left;margin-left:20px;">实习部</p> 
                             <p  style="float:left;margin-left:65px;">公开</p>       
                           <p  style="float:right;margin-right:25px;">￥30</p>
                          
                        </div>
                    </div>
                </div>
            </div>--%>
                  
				<footer><p style="text-align:center;">Copyright &copy; 2016.Company name All rights reserved.<a target="_blank" href="http://www.cssmoban.com/">&#x7F51;&#x9875;&#x6A21;&#x677F;</a></p></footer>
					
			 <!-- /. PAGE INNER  -->
            </div>
            
    </form>
    <!-- jQuery Js -->
    <script src="assets/js/jquery-1.10.2.js"></script>
      <!-- Bootstrap Js -->
    <script src="assets/js/bootstrap.min.js"></script>
    <!-- Metis Menu Js -->
    <script src="assets/js/jquery.metisMenu.js"></script>
      <!-- Custom Js -->
    <script src="assets/js/custom-scripts.js"></script>
</body>
</html>
