<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta content="" name="description" />
    <meta content="webthemez" name="author" />
    <title>虹软云课堂后台</title>
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

</head>
<body>
    <form>

        <div id="wrapper">
            <!--以下是导航栏-->
            <nav class="navbar navbar-default top-navbar" role="navigation">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".sidebar-collapse">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" href="index.html"><strong>虹软云课堂后台</strong></a>

                    <div id="sideNav" href="">
                        <i class="fa fa-bars icon"></i>
                    </div>
                </div>
                <label style="display:none;" id="label_CompanyID" ><%=MANAGERID%></label>
                <ul class="nav navbar-top-links navbar-right">
                    <!--以下是消息栏-->
                    
                    <li>
                        <img class="loge" src="assets/img/HongRuan.png" style="height: 30px; width: 60px;" /></li>
                    <li class="dropdown">

                        <a class="dropdown-toggle" data-toggle="dropdown" href="#" aria-expanded="false">
                            <i class="fa fa-bell fa-fw"></i>
                            <i class="fa fa-caret-down"></i>
                            <i style="color: red; font-style: normal;"><% =intCount %>条</i>
                        </a>
                        <ul class="dropdown-menu dropdown-alerts">

                            <li>
                                <a class="text-center" href="ManagerAnswer.aspx" target="win">
                                    <label id="AnswerCount" runat="server" onclick="CheckQuestion">您有<% =intCount %>条提问待回复</label>
                                    <i class="fa fa-angle-right"></i>
                                </a>
                            </li>

                        </ul>
                        <!-- /.dropdown-alerts以上是消息栏 -->
                    </li>
                    <!--以下是个人信息设置栏-->
                    <li class="dropdown">
                        <a class="dropdown-toggle" data-toggle="dropdown" href="#" aria-expanded="false">
                            <i class="fa fa-user fa-fw"></i><i class="fa fa-caret-down"></i>
                        </a>
                        <ul class="dropdown-menu dropdown-user">
                            <li><a href="#"><i class="fa fa-user fa-fw"></i>个人信息</a>
                            </li>
                            <li><a href="#"><i class="fa fa-gear fa-fw"></i>账号设置</a>
                            </li>
                            <li class="divider"></li>
                            <li><a href="#"><i class="fa fa-sign-out fa-fw"></i>退出登录</a>
                            </li>
                        </ul>
                        <!-- /.dropdown-user -->
                    </li>
                    <!-- /.dropdown -->
                </ul>
            </nav>
            <!--/. NAV TOP  -->
            <nav class="navbar-default navbar-side" role="navigation">
                <div class="sidebar-collapse">
                    <ul class="nav" id="main-menu">
                        <li>
                            <a href="#"><i class="fa fa-sitemap"></i>企业设置<span class="fa arrow"></span></a>
                            <ul class="nav nav-second-level">
                                <li>
                                    <a href="chart.html" target="win">公司概况</a>
                                </li>
                                <li>
                                    <a href="chart.html" target="win">员工管理</a>
                                </li>
                            </ul>
                        </li>

                        <li>
                            <a href="CourseList.aspx" target="win"><i class="fa fa-sitemap"></i>课程中心 <span ></span></a>
                           <%-- <ul class="nav nav-second-level">
                                <li>
                                    <a href="#">课程列表</a>
                                </li>
                                <li>
                                    <a href="#">上传课程</a>
                                </li>
                            </ul>--%>
                        </li>
                        <li>
                            <a href="#"><i class="fa fa-sitemap"></i>互动中心 <span class="fa arrow"></span></a>
                            <ul class="nav nav-second-level">
                                <li>
                                    <a href="ManagerAnswer.aspx" target="win">问答</a>
                                </li>
                                <li>
                                    <a href="ManagerDiscuss.aspx" target="win">评论中心</a>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <a href="#"><i class="fa fa-sitemap"></i>统计中心 <span class="fa arrow"></span></a>
                            <ul class="nav nav-second-level">
                                <li>
                                    <a href="totalstatics.aspx " target="win">综合统计</a>
                                </li>
                                <li>
                                    <a href="classstatics.aspx" target="win">课程统计</a>
                                </li>
                                <li>
                                    <a href="staffstatics.aspx" target="win">员工统计</a>
                                </li>
                                <li>
                                    <a href="departmentstatics.aspx" target="win">部门统计</a>
                                </li>
                            </ul>
                        </li>
                </div>

            </nav>
            <!-- /. NAV SIDE  -->

            <div id="page-wrapper">
                <iframe style="width: 100%;" id="win" name="win" onload="Javascript:SetWinHeight(this)" frameborder="0" scrolling="no" src="chart.html"></iframe>
            </div>
            <!-- /. PAGE INNER  -->
            <script>
                function SetWinHeight(obj) {
                    var win = obj;
                    if (document.getElementById) {
                        if (win && !window.opera) {
                            if (win.contentDocument && win.contentDocument.body.scrollHeight)
                                win.height = win.contentDocument.body.scrollHeight;
                            else if (win.Document && win.Document.body.scrollHeight)
                                win.height = win.Document.body.scrollHeight;
                        }
                    }
                }
            </script>

            <script src="assets/js/jquery-1.10.2.js"></script>
            <!-- Bootstrap Js -->
            <script src="assets/js/bootstrap.min.js"></script>
            <!-- Metis Menu Js -->
            <script src="assets/js/jquery.metisMenu.js"></script>
            <!-- DATA TABLE SCRIPTS -->

            <!-- Custom Js -->
            <script src="assets/js/custom-scripts.js"></script>
    </form>

</body>
</html>
