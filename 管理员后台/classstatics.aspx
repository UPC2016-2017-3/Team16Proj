<%@ Page Language="C#" AutoEventWireup="true" CodeFile="classstatics.aspx.cs" Inherits="课程统计" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta content="" name="description" />
    <meta content="webthemez" name="author" />
    <title>Bootstrap Admin Template</title>
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

<body  style="background-color: #EDEDED;">
    <form id="Form1" runat="server">
    <div id="wrapper">
            <div class="header">
                <h1 class="page-header">课程统计  <small>CURRICULUM STATISTICS</small></h1>
                <ol class="breadcrumb">
                    <li>课程统计</li>
                    <li>统计图表</li>
                </ol>
            </div>
            <div class="header">
                <div class="row">
                    <div class="col-sm-6 col-xs-12">
                        <div class="panel panel-default chartJs">
                            <div class="panel-heading">
                                <div class="card-title">
                                    <div class="title">课程学习/收藏人数情况图(按类别 )</div>
                                </div>
                            </div>
                            <div class="panel-body">
                                <canvas id="chart1"></canvas>
                            </div>
                        </div>
                    </div>

                    <div class="col-sm-6 col-xs-12">
                        <div class="panel panel-default chartJs">
                            <div class="panel-heading">
                                <div class="card-title">
                                    <div class="title">课程点击量排行榜</div>
                                </div>
                            </div>
                            <div class="panel-body">
                                <canvas id="bar-chart"></canvas>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="header">
                <div style="padding: 12px 10px 12px 20px; background: #fff">
                    <span>课程统计&nbsp;&nbsp;/&nbsp;&nbsp;统计列表</span>
                    <div style="float: right;">
                        
                            <asp:Button ID="Button1" runat="server" Text="导出数据" class="btn btn-primary btn-sm" OnClick="Button1_Click" />
                        
                    </div>
                </div>
            </div>
             <div class="header hidden-xs hidden-sm">
                <div style="float: right; margin-top: 30px; margin-bottom: 30px">
                    <input type="text" id="text" runat="server" placeholder="你想搜的课程" style="width: 200px; display: inline;height:31px;padding-left:10px; border:none;border-radius:3px;" />
                   <asp:Button ID="search" runat="server" Text="搜索" style="display:inline;" class="btn btn-primary btn-sm"
                        onclick="search_Click"></asp:Button>
                </div>
            </div>

            <div class="header hidden-xs hidden-sm">

                <table>
                    <tr>
                        <th style="width: 7%;">序号</th>
                        <th style="width: 20%;">课程名</th>
                        <th style="width: 20%;">类别</th>
                        <th style="width: 9%;">总点击量</th>
                        <th style="width: 9%;">学习课程</th>
                        <th style="width: 8%;">评论数</th>
                        <th style="width: 8%;">提问数</th>
                        <th style="width: 10%;">课程章节数</th>
                        <th style="width: 9%;">收藏人数</th>
                    </tr>
                    <asp:DataList runat="server" ID="datalist1" style="text-align:center">
                        <ItemTemplate>
                            <%# Container.ItemIndex+1%></td>
                                <td style="width: 20%;"><%# Eval("ClassName")%></td>
                            <td style="width: 20%;"><%# Eval("CategoryName")%></td>
                            <td style="width: 9%;"><%# Eval("ClassClickNum")%></td>
                            <td style="width: 9%;"><%# Eval("learnNum")%>人</td>
                            <td style="width: 8%;"><%# Eval("ClassDiscussNum")%></td>
                            <td style="width: 8%;"><%# Eval("Qnum")%></td>
                            <td style="width: 10%;"><%# Eval("UnitNum")%>章</td>
                            <td style="width: 9%;"><%# Eval("ClassCollectionNum")%>
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

    <!--以下是课程学习人数和收藏人数统计图-->
    <script>
        var chartdata = {
            labels: [<%=data3%>],
            datasets: [{
                label: '课程学习人数',
                backgroundColor: window.chartColors.blue,
                fill: false,
                data: [<%=data5%>],
                }, {
                    type: 'bar',
                    label: '课程收藏人数',
                    backgroundColor: window.chartColors.red,
                    data: [<%=data4%>],
            }]

        };
        var ctx1 = document.getElementById("chart1").getContext("2d");
        window.myBarChart = new Chart(ctx1, {
            type: 'bar',
            data: chartdata,
            options: {
                responsive: true,
                title: {
                    display: false,
                    text: '课程学习/收藏人数情况图(按类别 )'
                }
            }
        });
    </script>

    <!--以下是课程点击量排行榜-->
    <script>
        var ctx, data, myBarChart, option_bars;
        Chart.defaults.global.responsive = true;
        ctx = $('#bar-chart').get(0).getContext('2d');

        data = {
            labels: [<%=data1 %>],
            datasets: [{
                label: "点击量",
                fillColor: "rgba(26, 188, 156,0.6)",
                backgroundColor: "#1ABC9C",
                data: [<%=data2 %>]
                }, ]
        };
            window.myBarChart = new Chart(ctx, {
                type: 'bar',
                data: data,
                options: {
                    responsive: true,
                    title: {
                        display: false,
                        text: '课程学习/收藏人数情况图(按类别 )'
                    }
                }
            });
    </script>
        </form>
</body>
</html>
