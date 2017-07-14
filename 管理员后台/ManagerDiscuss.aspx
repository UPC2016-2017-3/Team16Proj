<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManagerDiscuss.aspx.cs" Inherits="ManagerDiscuss" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
	<meta content="" name="description" />
    <meta content="webthemez" name="author" />
    <title></title>
	  <!-- Bootstrap Styles-->
    <link href="assets/css/bootstrap.css" rel="stylesheet" />
     <!-- FontAwesome Styles-->
    <link href="assets/css/font-awesome.css" rel="stylesheet" />
    <!-- Morris Chart Styles-->   
    <!-- Custom Styles-->
    <link href="assets/css/custom-styles.css" rel="stylesheet" />
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
        <script>
            $(document).ready(function () {
                $('#dataTables-example').dataTable();
            });
    </script>
         <!-- Custom Js -->
    <script src="assets/js/custom-scripts.js"></script>
    
</head>
<body style="background-color: #EDEDED">
    <form id="form2" runat="server">
<div id="wrapper">
	<div style="background-color: #EDEDED;height:auto">
	<div class="header"> 
      <h1 class="page-header"> 学员评论管理 <small>学员的评论很重要哦，请认真审核！</small></h1> 				   										
	</div>
<!--以下是管理员回答问题窗口-->
    <div class="modal fade" id="myModal" aria-hidden="true">
	    <div class="modal-dialog">
		    <div class="modal-content">
                <form id="saveDeviceForm" action="saveDevice" method="post">
			    <div class="modal-header">
				<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
				<span class="modal-title" id="myModalLabel" style="font: '微软雅黑';font-size: medium;color:#4D4C50 ;">
					<label id="Title" runat="server" style="font-size:medium;"></label>
                    <br/><label id="Content" runat="server" style="font-size:medium;"></label>
				</span>
			    </div>
			    <div class="modal-body" style="height:70px;text-align:center"> 
                <label style="font-size:20px;">您确定要删除该评论吗？</label>
	            </div>
		     	<div class="modal-footer">  
				<button type="button" class="btn btn-sm btn-default" data-dismiss="modal">取消</button>
				<asp:LinkButton id="LinkButtonA" Text="删除" OnCommand="Submit_OnClick" runat="server" class="btn btn-primary btn-sm"/>

			    </div>
                </form>
		    </div>
	    </div>
    </div>
<!--以上是管理员回答问题窗口 -->
  <!--以下是查看评论区-->     
      <div class="header">
      <div style="font-size:large;font-family:'微软雅黑';color:#41494F;"><strong>查看学员的评论</strong></div> 
      <div style="float: right;margin-bottom:1.5%;">
         <input id="SearchText" type="text" runat="server" placeholder="输入评论内容关键字..." style="width: 200px; display: inline;height:31px;padding-left:10px; border:none;border-radius:3px;"/>
         <asp:LinkButton ID="LinkButton1" Text="搜索" CommandName="next" OnCommand="Search_OnClick" runat="server" class="btn btn-primary btn-sm"/>          
      </div>
      </div>
      <div class="header">
                <div id="tbcontent">
                    <table>
                        <thead>
                        <tr>                        
                            <th style="width: 18%;">单元（所属课程）</th>
                            <th style="width: 32%;">评论内容</th>
                            <th style="width: 5%;"></th>
                            <th style="width: 10%;vertical-align:central">评论人</th>
                            <th style="width: 10%;">所属部门</th>
                            <th style="width: 15%;">评论时间</th>
                            <th style="width: 10%;">操作</th>
                        </tr>
                        </thead>
                        <tbody id="tbody">
                                          
                         <tr id="aa">             
                             <asp:DataList id="DatalistDis" runat="server">
                          <ItemTemplate>
                              <%#Eval("UnitName")%> (<%#Eval("ClassName")%>)
                            </td>
                            <td style="width:30%;" id="content">
                               <%#Eval("DiscussContent")%>
                              
                                
                            </td>
                              <td style="width:5%;border:0px;display:none"> 
                            <div style="width:6px;"><textarea id="ta_UnitID"><%#Eval("DisscusID")%></textarea></div></td>
                            <td style="width:10%;text-align:center;" id="studentname">
                                 <%# Eval("StudentName") %>
                            </td>
                              <td style="width: 10%;text-align:center;" id="departmentname">
                                <%# Eval("DepartmentName") %>
                            </td>
                            <td style="width: 15%;text-align:center;" id="time">
                                  <%# Eval("DiscussTime") %>
                            </td>
                            <td style="width: 10%;">
                            <button type="button" style="margin-left:8px;" class="btn btn-primary btn-sm" onclick="myModal(this);" data-toggle="modal">删除</button>                           
                        </ItemTemplate>
                       </asp:DataList>
                           </tr>
                        
                        </tbody>                        
                    </table>
                    <div style="display:none " ><textarea id="DiscussID" runat="server" ></textarea> </div> 
                </div>
         <div id="Page1" style="float:left;margin-top:20px;margin-bottom:20px;" runat="server">
             共有<asp:Label id="lblRecordCount" ForeColor="red" runat="server" />条记录&nbsp;
             当前为<asp:Label id="lblCurrentPage" ForeColor="red" runat="server" />/<asp:Label id="lblPageCount" ForeColor="red" runat="server" />页&nbsp;
         </div>       
             <div id="Page2" style="float:right;margin-bottom:20px;margin-top:20px;" runat="server">
                <asp:LinkButton id="lbnPrevPage" Text="上一页" CommandName="prev" OnCommand="Page_OnClick" runat="server" class="btn btn-success btn-sm"/>
                <asp:LinkButton id="lbnNextPage" Text="下一页" CommandName="next" OnCommand="Page_OnClick" runat="server" class="btn btn-success btn-sm"/>                
             </div>
          <div style="display:none;">
          <textarea id="QuestionTitle" runat="server" ></textarea>
           <textarea id="QuestionContent" runat="server"></textarea>  
          </div> 
            </div>   
  <!--以上是查看评论区-->           

                <footer style="text-align:center;margin:0px;margin-top:30px;">
                   <p>Copyright &copy; <a target="_blank" href="http://www.arcsoft.com.cn/">虹软中国</a>
                   </p>
               </footer>
        </div>
       </div>
         </form> 
</body>
</html>
<script src="http://cdn.bootcss.com/jquery/1.10.2/jquery.min.js"></script>
<!-- 最新的 Bootstrap 核心 JavaScript 文件 -->
<script src="http://cdn.bootcss.com/twitter-bootstrap/3.0.3/js/bootstrap.min.js"></script>
<script>
    function myModal(obj) {
        var tds = $(obj).parent().parent().find('td');
        $('#Title').html(tds.eq(0).text());
        $('#DiscussID').html(tds.eq(2).text());
        $('#Content').html(tds.eq(1).text());
       

        //控制模态框的位置
        $("#myModal").modal().css({
            "margin-top": function () {
                return ($(this).height() / 7);
            }
        });


    }
</script>




