<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManagerAnswer.aspx.cs" Inherits="ManagerQandA" %>

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
      <h1 class="page-header"> 管理员回复学员提问 <small>学员的问题很重要哦，请认真回答！</small></h1> 				   										
	</div>
<!--以下是管理员回答问题窗口-->
    <div class="modal fade" id="myModal" aria-hidden="true">
	    <div class="modal-dialog">
		    <div class="modal-content">
                <form id="saveDeviceForm" action="saveDevice" method="post">
			    <div class="modal-header">
				<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
				<span class="modal-title" id="myModalLabel" style="font: '微软雅黑';font-size: medium;color:#4D4C50 ;">
					<label id="Title" runat="server" style="font-size:smaller;"></label>
                    </br><label id="Content" runat="server" style="font-size:smaller;"></label>
				</span>
			    </div>
			    <div class="modal-body" style="height:200px;"> 
                <label style="font-size:x-small;">请输入您的答案：</label>
				<textarea id="AnswerText" runat="server" style="width:100%;height:100%"> </textarea>
	            </div>
		     	<div class="modal-footer">  
				<button type="button" class="btn btn-sm btn-default" data-dismiss="modal">关闭</button>
				<asp:LinkButton id="LinkButtonA" Text="提交" OnCommand="Submit_OnClick" runat="server" class="btn btn-primary btn-sm"/>

			    </div>
                </form>
		    </div>
	    </div>
    </div>
<!--以上是管理员回答问题窗口 -->
  <!--以下是查看未被管理员回答表格-->     
      <div class="header">
      <div style="font-size:large;font-family:'微软雅黑';color:#41494F;"><strong>查看未回答的提问</strong></div> 
      <div style="float: right;margin-bottom:1.5%;">
         <input id="SearchText" type="text" runat="server" placeholder="输入问题标题、内容关键字..." style="width: 200px; display: inline;height:31px;padding-left:10px; border:none;border-radius:3px;"/>
         <asp:LinkButton Text="搜索" CommandName="next" OnCommand="Search_OnClick" runat="server" class="btn btn-primary btn-sm"/>          
      </div>
      </div>
      <div class="header">
                <div id="tbcontent">
                    <table>
                        <thead>
                        <tr>                        
                            <th style="width: 20%;">标题</th>
                            <th style="width: 35%;">内容</th>
                            <th style="width: 10%;">提问人</th>
                            <th style="width: 10%;">所属部门</th>
                            <th style="width: 15%;">提问时间</th>
                            <th style="width: 10%;">操作</th>
                        </tr>
                        </thead>
                        <tbody id="tbody">
                            <c:forEach items="${personList.datas}" var="person">                     
                         <tr id="aa">             
                             <asp:DataList id="DatalistQ" runat="server">
                          <ItemTemplate>
                              <%#Eval("QuestionTitle")%>
                            </td>
                            <td style="width:35%;" id="content">
                               
                               <%#Eval("QuestionContent")%>
                            </td>
                            <td style="width:10%;text-align:center;" id="studentname">
                                 <%# Eval("StudentName") %>
                            </td>
                              <td style="width: 10%;text-align:center;" id="departmentname">
                                <%# Eval("DepartmentName") %>
                            </td>
                            <td style="width: 15%;text-align:center;" id="time">
                                  <%# Eval("QuestionTime") %>
                            </td>
                            <td style="width: 10%;">
                            <button type="button" class="btn btn-primary btn-sm" onclick="myModal(this);" data-toggle="modal">回答</button>                           
                        </ItemTemplate>
                       </asp:DataList>
                           </tr>
                          </c:forEach> 
                        </tbody>                        
                    </table>
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
  <!--以上是查看未被管理员回答表格-->           
       
         <!--  以下是已回答问题列表区-->
                         <div class="row" >
                               <div class="col-md-12">
                                         <!--    Context Classes  -->
                                    <div class="header" style="margin-top:40px;">                      
                                           <div style="font-size:large;font-family:'微软雅黑';color:#41494F;"><strong>查看已回答的提问</strong></div>     
                                     </div>           
                                                                               
                                                     <div class="header" style="margin-top:30px;">
                                                          <div id="tbcontent2">
                                                              <div style="overflow-y:scroll;height:300px;text-align:center;"> 
                                                                 <table>   
                                                                    <tr>                       
                                                                            <th style="width:15%;font-size:15px;">
                                                                                提问人
                                                                            </th >
                                                                            <th style="width:18%;font-size:15px">
                                                                                标题
                                                                            </th >
                                                                            <th style="width:20%;font-size:15px" >
                                                                               内容
                                                                            </th>
                                                                            <th style="width:20%;font-size:15px">
                                                                                答案
                                                                            </th>
                                                                            <th style="width:15%;font-size:15px">
                                                                                解答时间
                                                                            </th>
                                                                            <th style="width:12%;font-size:15px">
                                                                                回答者
                                                                            </th>                           
                                                                        </tr>                    
                                                                    <asp:DataList id="zonghelist" runat="server">
                                                                          <ItemTemplate>
                                                                              <%#Eval("StudentName")%> (
                                                                              <%#Eval("DepartmentName")%>)
                               
                                                                            </td>
                                                                            <td style="width:18%;height:50px;" >
                                                                               <font title="<%#Eval("QuestionTitle")%>"> <%#FormatFoo(Eval("QuestionTitle"))%></font>
                     
                                                                            </td>
                                                                            <td style="width:20%;" >
                                                                                <%-- <%#FormatFoo(Eval("QuestionContent"))%>--%>
                                                                                <font title="<%#Eval("QuestionContent")%>"> <%#FormatFoo(Eval("QuestionContent"))%></font>
                                                                            </td>   
                                                                            <td style="width:20%">
                                                                               <font title="<%#Eval("AnswerContent")%>"> <%#FormatFoo(Eval("AnswerContent"))%></font>
                                                                            </td>
                                                                            <td style="width:15%">
                                                                                  <%#Eval("AnswerTime")%>
                                                                            </td>
                                                                            <td style="width:12%">
                                                                                 <%#Eval("ManagerName")%>
                                                                            </td>
                          
                                                                        </ItemTemplate>
                                                                       </asp:DataList>     
                                                                 </table>
                                                              </div>
                                                          <!--以上是添加的试用表格！-->
                                                          </div>
                                                     </div> 
             	                    </div>
                               </div>
                         
        <!--  以上是已回答问题列表区-->
        
       
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
        $('#QuestionTitle').html(tds.eq(0).text());
        $('#Content').html(tds.eq(1).text());
        $('#QuestionContent').html(tds.eq(1).text());
     
        //控制模态框的位置
        $("#myModal").modal().css({
            "margin-top": function () {
                return  ($(this).height() / 5);
            }
        });
      

}
</script>




