<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UnitList.aspx.cs" Inherits="UnitList"  EnableEventValidation="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
	
	

   <%-- <script src="js/jquery-2.1.1.min.js"></script>
        <script src="assets/js/bootstrap.min.js"></script>
        <link href="assets/css/bootstrap.min.css" rel="stylesheet"/>--%>

    <meta charset="utf-8" />
	<meta name="viewport" content="width=device-width, initial-scale=1.0,maximum-scale=1.0, user-scalable=no"/>
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
     <link href="assets/css/bootstrap.css" rel="stylesheet" />
  
	
      <!-- Bootstrap Js -->
  
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
        
         <!-- Custom Js -->
    <script src="assets/js/custom-scripts.js"></script>
    
</head>
  
<body>
    
    <form runat="server">
        <div  style="background-color:#EDEDED">
    <!-- 以下是模态框（Modal） -->
                 <div class="modal fade" id="myModal" aria-hidden="true">
	    <div class="modal-dialog">
		    <div class="modal-content">
                <form id="saveDeviceForm" action="saveDevice" method="post">
			    <div class="modal-header">
				<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
				<span class="modal-title" id="myModalLabel" style="font: '微软雅黑';font-size: medium;color:#4D4C50 ;">
					<label id="unitrank" runat="server" style="font-size:smaller;"></label>
                    
                    <label id="unitname" runat="server" style="font-size:smaller;"></label>
				</span>
			    </div>
			    <div class="modal-body" style="height:80px;text-align:center"> 
                <label style="font-size:20px;">您确定要删除该课程单元吗？</label>
				<%--<textarea id="AnswerText" runat="server" style="width:100%;height:100%"> </textarea>--%>
	            </div>
		     	<div class="modal-footer">  
				<button type="button" class="btn btn-sm btn-default" data-dismiss="modal">取消</button>
				<asp:LinkButton id="LinkButtonA" Text="确定" OnCommand="Delete_OnClick" runat="server" class="btn btn-primary btn-sm"/>

			    </div>
                </form>
		    </div>
	    </div>
                    
    </div>
    <!-- 以上是模态框（Modal） -->
                  <div class="panel-body"> 
		          <div class="panel-heading" style="color:rgb(119, 119, 119);margin-left:20px;margin-right:20px;margin-top:10px; padding-top:20px;padding-left:25px;padding-right:25px;padding-bottom:20px; background-color:#f5f5f5;border-width:1px;border-image:initial;border-radius:4px;">
                       
                                <a href="CourseList.aspx"><img src="assets/img/后退CoGraphics.png" style="height:30px;width:30px;"/></a> 

                        <label style="font-size:20px;">课程名称:</label> 
                         <asp:label id="dddd" name="dddd" runat="server" style="font-size:18px;"></asp:label>
                        <br />
                         <br />
                        <label>课程简介：</label>
                        <asp:label   id="Label1" name="dddd" runat="server"></asp:label>
             
                     </div>
						
		        </div>					

                  <div class="panel panel-default" style="margin-left:35px;margin-right:30px;">
				 <div class="panel-heading">
				<ol class="breadcrumb" style="height:20px;">
    				  <li class="active">单元列表</li>
                      <li><a href="上传课时1.aspx">添加单元</a></li>
					</ol> 
				</div>   
               
		              <div class="panel-body"style="padding-right:55px;font-size:20px;"> 
                               <table>
                                   <tr >
                                    <asp:DataList  class="alert alert-warning" id="UnitList_unit" runat="server" RepeatDirection="Vertical" style="margin-left:20px;width:100%;vertical-align:central;" >
                                        <ItemTemplate > 
  
									        <td style="border:0px;padding-top:27px;padding-left:10px;width:8%">   <p style="float:left;height:30px;margin-left:20px;">第<%#Eval("UnitRank")%>课</p> </td> 
                                             <td style="border:0px;padding-top:10px;width:62%">  <p style="float:left;margin-left:5px;"><%#Eval("UnitName")%></p> </td> 
                                             <td style="width:14%;border:0px;padding-top:10px;padding-left:10px;">                               
                                            <div style="display:none;"><textarea id="ta_UnitID"><%#Eval("UnitID")%></textarea></div></td>
                                            <td style="border:0px;padding-top:10px;padding-left:10px;width:8%"><asp:Button ID="Button1" runat="server" class="btn btn-primary btn-sm" Text="编 辑" OnCommand="Button1_Edit"  
                                                CommandArgument='<%# DataBinder.Eval(Container.DataItem,"UnitID")+","+ DataBinder.Eval(Container.DataItem,"UnitRank")+","+DataBinder.Eval(Container.DataItem,"UnitName")%>'></asp:Button></td>
                                            <td style="border:0px;padding-top:10px;padding-left:10px;width:8%"><button style="border-radius:4px;margin-right:20px;" type="button" class="btn btn-danger btn-sm" onclick="myModal(this);" data-toggle="modal">删 除</button>  </td>                         
         
                                         </ItemTemplate>       
                                     </asp:DataList> 
                                       </tr>
                             </table>
           <div style="display:none;">
          <textarea id="UnitIDID" runat="server" ></textarea>
           
          </div> 
                       </div>

			    </div>
        </div>
        
   </form>
   <%-- <script>
        $(function () {
            $('#myModal').modal({
                keyboard: true
            })
        });
</script>--%>
    <%--<script>
        function myModal(obj) {
            //var tds = $(obj).parent().parent().find('td');
            //$('#Title').html(tds.eq(0).text());
            //$('#QuestionTitle').html(tds.eq(0).text());
            //$('#Content').html(tds.eq(1).text());
            //$('#QuestionContent').html(tds.eq(1).text());

            //控制模态框的位置
            $("#myModal").modal().css({
                "margin-top": function () {
                    return ($(this).height() / 5);
                }
            });


        }
</script>--%>
    <script src="http://cdn.bootcss.com/jquery/1.10.2/jquery.min.js"></script>
<!-- 最新的 Bootstrap 核心 JavaScript 文件 -->
<script src="http://cdn.bootcss.com/twitter-bootstrap/3.0.3/js/bootstrap.min.js"></script>
    <script>
        function myModal(obj) {
            var tds = $(obj).parent().parent().find('td');
            $('#unitrank').html(tds.eq(1).text());
            $('#UnitIDID').html(tds.eq(3).text());
            $('#unitname').html(tds.eq(2).text());
           

            //控制模态框的位置
            $("#myModal").modal().css({
                "margin-top": function () {
                    return ($(this).height() / 6);
                }
            });


        }
</script>
</body>
</html>


    