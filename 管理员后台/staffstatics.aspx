<%@ Page Language="C#" AutoEventWireup="true" CodeFile="staffstatics.aspx.cs" Inherits="员工统计" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta content="" name="description" />
    <meta content="webthemez" name="author" />
    <title>员工统计</title>
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

<body style="background: #EDEDED;">
    <form id="form2" runat="server">
        <div id="wrapper">
            <div class="header">
                <h1 class="page-header">员工统计  <small>EMPLOYEE STATISTICS</small></h1>
                <ol class="breadcrumb">
                    <li>员工统计</li>
                    <li>统计图表</li>
                </ol>
            </div>
            <div class="header">
                <div class="row">
                    <div class="col-sm-6 col-xs-12">
                        <div class="panel panel-default chartJs">
                            <div class="panel-heading">
                                <div class="card-title">
                                    <div class="title">课程学习完成量排行榜</div>
                                </div>
                            </div>
                            <div class="panel-body" style="width: auto; height: auto;">
                                <div class="chart1"></div>
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-6 col-xs-12">
                        <div class="panel panel-default chartJs">
                            <div class="panel-heading">
                                <div class="card-title">
                                    <div class="title">任务完成量排行榜</div>
                                </div>
                            </div>
                            <div class="panel-body" style="width: auto; height: auto;">
                                <canvas id="chart1"></canvas>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="header">
                <div style="padding: 12px 10px 12px 20px; background: #fff">
                    <span>员工统计&nbsp;&nbsp;/&nbsp;&nbsp;统计列表</span>
                    <div style="float: right;">

                        <asp:Button ID="Button1" runat="server" Text="导出数据" class="btn btn-primary btn-sm" OnClick="Button1_Click" />

                    </div>
                </div>
            </div>
             <div class="header hidden-xs hidden-sm">
                <div style="float: right; margin-top: 30px; margin-bottom: 30px">
                    <input type="text" id="text" runat="server" placeholder="你想搜的员工姓名" style="width: 200px; display: inline;height:31px;padding-left:10px; border:none;border-radius:3px;" />
                   <asp:Button ID="search" runat="server" Text="搜索" style="display:inline;" class="btn btn-primary btn-sm"
                        onclick="search_Click"></asp:Button>
                </div>
            </div>

            <div class="header hidden-xs hidden-sm">
                <table>
                    <tr>
                        <th style="width: 12%;">序号</th>
                        <th style="width: 16%;">员工</th>
                        <th style="width: 12%;">学习课程</th>
                        <th style="width: 12%;">完成课程</th>
                        <th style="width: 12%;">学习完成率</th>
                        <th style="width: 12%;">专题任务数</th>
                        <th style="width: 12%;">完成任务数</th>
                        <th style="width: 12%;">完成率</th>
                    </tr>
                    <asp:DataList runat="server" ID="datalist1" style="text-align:center">
                        <ItemTemplate>
                            <%# Container.ItemIndex+1%></td>
                                <td style="width: 16%;"><%# Eval("studentname")%></td>
                            <td style="width: 12%;"><%# Eval("classnum")%></td>
                            <td style="width: 12%;"><%# Eval("learnnum")%></td>
                            <td style="width: 12%;"><%# Eval("LCratio")%>%</td>
                            <td style="width: 12%;"><%# Eval("tasknum")%></td>
                            <td style="width: 12%;"><%# Eval("TskDoneNum")%></td>
                            <td style="width: 12%;"><%# Eval("taskratio")%>
                            %
                        </ItemTemplate>
                    </asp:DataList>
                </table>
                <div style="float: left; margin-top: 20px; margin-bottom: 20px;">
                    共有<asp:Label ID="lblRecordCount" ForeColor="red" runat="server" />条记录&nbsp;
                            当前为<asp:Label ID="lblCurrentPage" ForeColor="red" runat="server" />/<asp:Label ID="lblPageCount" ForeColor="red" runat="server" />页&nbsp;
                </div>

                <div style="float: right; margin-top: 20px; margin-bottom: 20px;">
                    <asp:LinkButton ID="lbnPrevPage" Text="上一页" CommandName="prev" OnCommand="Page_OnClick" runat="server" class="btn btn-success btn-sm" />
                    <asp:LinkButton ID="lbnNextPage" Text="下一页" CommandName="next" OnCommand="Page_OnClick" runat="server" class="btn btn-success btn-sm" />
                </div>
            </div>
           
        </div>
         
        <footer></footer>

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

        <!--以下是课程学习完成量排行榜-->
        <script>
            function createConfig(pointStyle) {
                return {
                    type: 'line',
                    data: {
                        labels: [<%=data1 %>],
                    datasets: [{
                        label: "My First dataset",
                        backgroundColor: window.chartColors.red,
                        borderColor: window.chartColors.red,
                        data: [<%=data2 %>],
                        fill: false,
                        pointRadius: 5,
                        pointHoverRadius: 15,
                        showLine: false
                    }]
                },
                options: {
                    responsive: true,
                    title: {
                        display: false,
                    },
                    legend: {
                        display: false
                    },
                    elements: {
                        point: {
                            pointStyle: pointStyle
                        }
                    }
                }
            };
        }

        window.onload = function () {
            var container = document.querySelector('.chart1');
            [
                'circle',
                /*'triangle',
                'rect',
                'rectRounded',
                'rectRot',
                'cross',
                'crossRot',
                'star',
                'line',
                'dash'*/
            ].forEach(function (pointStyle) {
                var div = document.createElement('div');
                div.classList.add('chart-container');
                var canvas = document.createElement('canvas');
                div.appendChild(canvas);
                container.appendChild(div);
                var ctx = canvas.getContext('2d');
                var config = createConfig(pointStyle);
                new Chart(ctx, config);
            });
        };
        </script>
        <!--以下是任务完成量排行榜-->
        <script>
            var ctx, data, myBarChart;
            Chart.defaults.global.responsive = true;
            ctx = $('#chart1').get(0).getContext('2d');
            data = {
                labels: [<%=data3%>],
            datasets: [{
                label: "任务完成量",
                fillColor: "rgba(26, 188, 156,0.6)",
                backgroundColor: "#1ABC9C",
                data: [<%=data4%>]
            }, ]
        };
        window.myBarChart = new Chart(ctx, {
            type: 'bar',
            data: data,

            options: {
                responsive: true,

            }
        });
        </script>
    </form>
</body>

</html>
