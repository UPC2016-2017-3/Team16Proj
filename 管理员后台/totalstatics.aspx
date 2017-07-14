<%@ Page Language="C#" AutoEventWireup="true" CodeFile="totalstatics.aspx.cs" Inherits="zonghe" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta content="" name="description" />
    <meta content="webthemez" name="author" />
    <title></title>

    <script src="Chart.bundle.js"></script>
    <script src="utils.js"></script>
    <!-- Bootstrap Styles-->
    <link href="assets/css/bootstrap.css" rel="stylesheet" />
    <!-- FontAwesome Styles-->
    <link href="assets/css/font-awesome.css" rel="stylesheet" />
    <!-- Morris Chart Styles-->
    <link href="assets/js/morris/morris-0.4.3.min.css" rel="stylesheet" />
    <!-- Custom Styles-->
    <link href="assets/css/custom-styles.css" rel="stylesheet" />
    <!-- Google Fonts-->
    <link href='https://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />
    <link href="assets/css/tbcss.css" rel="stylesheet" />
</head>
<body style="background-color: #EDEDED;">
    <form id="form1" runat="server">
    <div id="wrapper">
            <div class="header">
                <h1 class="page-header">综合统计 <small>SUMMARY STATISTICS</small>
                </h1>
                <ol class="breadcrumb">
                    <li>综合统计</li>
                    <li>统计图表</li>
                </ol>
            </div>
            <div class="header" >
                <div class="row">
                    <div class="col-sm-6 col-xs-12">
                        <div class="panel panel-default chartJs">
                            <div class="panel-heading">
                                <div class="card-title">
                                    <div class="title">
                                        月用户数
                                    </div>
                                </div>
                            </div>
                            <div class="panel-body">
                                <canvas id="bar-chart" class="chart"></canvas>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-xs-12">
                        <div class="panel panel-default chartJs">
                            <div class="panel-heading">
                                <div class="card-title">
                                    <div class="title">
                                        近十天的用户活跃度
                                    </div>
                                </div>
                            </div>
                            <div class="panel-body">
                                <canvas id="line-chart" class="chart"></canvas>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="header">
                <div style="padding: 12px 10px 12px 20px; background: #fff">
                    <span>综合统计&nbsp;&nbsp;/&nbsp;&nbsp;统计列表</span>
                    <div style="float: right;">
                            <asp:Button ID="Button2" runat="server" Text="导出数据"  class="btn btn-primary btn-sm"  OnClick="Button1_Click" />
                        </div>
                    </div>
                </div>
            </div> 

        <div  class="header hidden-xs hidden-sm">
            
            <div style="float:right; margin-top: 30px; margin-bottom: 30px">

                    <input type="text" id="text" runat="server" placeholder="你想搜的日期 例：2017-06-26" style="width: 206px; display: inline;height:30px;padding-left:10px; border:none;border-radius:3px;" />
                   <asp:Button ID="search" runat="server" Text="搜索" style="display:inline;" class="btn btn-primary btn-sm"
                        onclick="search_Click"></asp:Button>
                
            </div>
            </div>

            <div class="header hidden-xs hidden-sm">
                <table >
                    <tr>
                        <th style="width: 11%;">序号
                        </th>
                        <th style="width: 20%;">日期
                        </th>
                        <th style="width: 11%;">活跃用户
                        </th>
                        <th style="width: 11%;">总用户
                        </th>
                        <th style="width: 12%;">活跃率
                        </th>
                        <th style="width: 12%;">课程学习
                        </th>
                        <th style="width: 12%;">课程收藏
                        </th>
                        <th style="width: 11%;">评论
                        </th>
                    </tr>

                    <asp:DataList ID="zonghelist" runat="server" style="text-align:center">
                        <ItemTemplate>
                            <%# Container.ItemIndex+1%>
                            </td>
                            <td style="width: 20%;">
                                <%# DataBinder.Eval(Container.DataItem, "clogdate", "{0:yyyy-MM-dd}")%>
                            </td>
                            <td style="width: 11%;">
                                <%# Eval("LogNum")%>人
                            </td>
                            <td style="width: 11%;">
                                <%=stuNum%>人
                            </td>
                            <td style="width: 12%;">
                                <%# Eval("Logratio")%>%
                            </td>
                            <td style="width: 12%;">
                                <%# Eval("LearnNum")%>次
                            </td>
                            <td style="width: 12%;">
                                <%# Eval("collectionNum")%>次
                            
                           <td style="width: 11%;">
                               <%# Eval("DisNum")%>
                            次
                        </ItemTemplate>
                    </asp:DataList>
                </table>
                <div style="float: left; margin-top:20px;margin-bottom:20px;">
                            共有<asp:Label ID="lblRecordCount" ForeColor="red" runat="server" />条记录&nbsp;
                            当前为<asp:Label ID="lblCurrentPage" ForeColor="red" runat="server" />/<asp:Label ID="lblPageCount" ForeColor="red" runat="server" />页&nbsp;
                        </div>

                        <div style="float: right;margin-top:20px;margin-bottom:20px;">
                            <asp:LinkButton ID="lbnPrevPage" Text="上一页" CommandName="prev" OnCommand="Page_OnClick" runat="server" class="btn btn-success btn-sm" />
                            <asp:LinkButton ID="lbnNextPage" Text="下一页" CommandName="next" OnCommand="Page_OnClick" runat="server" class="btn btn-success btn-sm" />
                        </div>
                </div>    
            </div>
   
    <!-- JS Scripts-->
    <!-- jQuery Js -->
    <script src="assets/js/jquery-1.10.2.js"></script>
    <!-- Bootstrap Js -->
    <script src="assets/js/bootstrap.min.js"></script>
    <!-- Metis Menu Js -->
    <script src="assets/js/jquery.metisMenu.js"></script>
    <!-- Chart Js -->
    <script type="text/javascript" src="assets/js/Chart.min.js"></script>
    <script type="text/javascript" src="assets/js/chartjs.js"></script>
    <!-- Morris Chart Js -->
    <script src="assets/js/morris/raphael-2.1.0.min.js"></script>
    <script src="assets/js/morris/morris.js"></script>
    <!-- Custom Js -->
    <script src="assets/js/custom-scripts.js"></script>
    <script src="Chart.js"></script>

    <!--以下是月用户数统计图-->
    <script>
        var chartdata = {
            labels: [<%=data1 %>],
            datasets: [{
                label: '月用户数',
                backgroundColor: window.chartColors.blue,
                fill: false,
                data: [<%=data2 %>]
            }]
        };
        var ctx = document.getElementById("bar-chart").getContext("2d");
        window.myBarChart = new Chart(ctx, {
            type: 'bar',
            data: chartdata,
            options: {
                responsive: true,
               
                legend: {
                    position: 'top',
                },
                scales: {
                    xAxes: [{
                        display: true,
                        scaleLabel: {
                            display: true,
                            labelString: '月份'
                        }
                    }],
                    yAxes: [{
                        display: true,
                        scaleStartValue:"0",
                        scaleLabel: {
                            display: true,
                            labelString: '用户数量'
                        }
                    }]
                },
                title: {
                    display: false,
                    text: '月用户数统计图'
                }
            }
        });
    </script>
    <!--以下是近十天的用户活跃度-->
    <script>
        var MONTHS = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
        var config = {
            type: 'line',
            data: {
                labels: [<%=data4 %>],
             datasets: [{
                 label: "活跃度",
                 data: [<%=data3 %>],
                 backgroundColor: window.chartColors.blue,
                 borderColor: window.chartColors.grey,
                 fill: false,
                 pointRadius: 5,
                 lineTension: 0,
             }
             ]
         },
         options: {
             responsive: true,
             legend: {
                 position: 'top',
             },
             hover: {
                 mode: 'index'
             },
             scales: {
                 xAxes: [{
                     display: true,
                     scaleLabel: {
                         display: true,
                         labelString: '时间（天）'
                     }
                 }],
                 yAxes: [{
                     display: true,
                     scaleLabel: {
                         display: true,
                         labelString: '活跃度'
                     }
                 }]
             },
             title: {
                 display: false,
                 text: 'Chart.js Line Chart - Different point sizes'
             }
         }
     };


     window.onload = function () {
         var ctx = document.getElementById("line-chart").getContext("2d");
         window.myLine = new Chart(ctx, config);
     };
    </script>
        </form>
</body>
</html>
