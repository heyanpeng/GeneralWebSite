<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AnHuiSite.AHAdmin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>
        <asp:Literal runat="server" ID="litSiteTitle" /></title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <!-- basic styles -->
    <link href="assets/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="assets/css/font-awesome.min.css" />
    <!--[if IE 7]>
		  <link rel="stylesheet" href="assets/css/font-awesome-ie7.min.css" />
		<![endif]-->
    <!-- page specific plugin styles -->
    <!-- fonts -->
    <link href="css/family=Open+Sans.css" rel="stylesheet" />
    <!-- ace styles -->
    <link rel="stylesheet" href="assets/css/ace.min.css" />
    <link rel="stylesheet" href="assets/css/ace-rtl.min.css" />
    <!--[if lte IE 8]>
		  <link rel="stylesheet" href="assets/css/ace-ie.min.css" />
		<![endif]-->
    <!-- inline styles related to this page -->
    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
		<script src="assets/js/html5shiv.js"></script>
		<script src="assets/js/respond.min.js"></script>
		<![endif]-->
    <script src="../js/jquery.js"></script>
    <script src="js/login.js"></script>
    <!--[if IE 8]> 
    <script type="text/javascript"> 
    alert("您的IE版本过低，请升级您的IE或者使用Chorme浏览器！");
    </script> 
    <![endif]-->
    <!--[if IE 9]> 
    <script type="text/javascript"> 
    alert("您的IE版本过低，请升级您的IE或者使用Chorme浏览器！");
    </script> 
    <![endif]-->
</head>
<body class="login-layout">
    <form id="form1" runat="server">
        <div class="main-container">
            <div class="main-content">
                <div class="row">
                    <div class="col-sm-10 col-sm-offset-1">
                        <div class="login-container">
                            <div class="center">
                                <h1>
                                    <i class="icon-leaf green"></i>
                                    <span class="red"></span>
                                    <span class="white" style="font-size: 27px; font-family: 微软雅黑;">
                                        <asp:Literal runat="server" ID="litSiteName" /></span>
                                </h1>
                                <h4 class="blue" style="font-family: 微软雅黑;"></h4>
                            </div>

                            <div class="space-6"></div>

                            <div class="position-relative">
                                <div id="login-box" class="login-box visible widget-box no-border">
                                    <div class="widget-body">
                                        <div class="widget-main">
                                            <h4 class="header blue lighter bigger" style="font-family: 微软雅黑;">
                                                <i class="icon-coffee green"></i>
                                                请输入您的账户信息
                                            </h4>

                                            <div class="space-6"></div>

                                            <fieldset>
                                                <label class="block clearfix">
                                                    <span class="block input-icon input-icon-right">
                                                        <input id="txtUsername" type="text" class="form-control" style="font-family: 微软雅黑;" placeholder="用户名" />
                                                        <i class="icon-user"></i>
                                                    </span>
                                                </label>

                                                <label class="block clearfix">
                                                    <span class="block input-icon input-icon-right">
                                                        <input id="txtPassword" type="password" class="form-control" style="font-family: 微软雅黑;" />
                                                        <i class="icon-lock"></i>
                                                    </span>
                                                </label>

                                                <div class="space"></div>

                                                <div class="clearfix">
                                                    <label class="inline">
                                                        <input type="checkbox" class="ace" />
                                                        <span class="lbl" style="font-family: 微软雅黑;display:none;">记住我</span>
                                                    </label>

                                                    <button onclick="btnLoginEvent()" type="button" class="width-35 pull-right btn btn-sm btn-primary" style="font-family: 微软雅黑;">
                                                        <i class="icon-key"></i>
                                                        登录
                                                    </button>
                                                </div>

                                                <div class="space-4"></div>
                                            </fieldset>
                                        </div>
                                        <!-- /widget-main -->
                                    </div>
                                    <!-- /widget-body -->
                                </div>
                                <!-- /login-box -->
                            </div>
                            <!-- /position-relative -->
                        </div>
                    </div>
                    <!-- /.col -->
                </div>
                <!-- /.row -->
            </div>
        </div>
        <!-- /.main-container -->

        <!-- basic scripts -->

        <!--[if !IE]> -->

        <script src="assets/js/jquery-2.0.3.min.js"></script>

        <!-- <![endif]-->

        <!--[if IE]>
        <script src="assets/js/jquery-1.10.2.min.js"></script>
        <![endif]-->

        <!--[if !IE]> -->

        <script type="text/javascript">
            window.jQuery || document.write("<script src='assets/js/jquery-2.0.3.min.js'>" + "<" + "/script>");
        </script>

        <!-- <![endif]-->

        <!--[if IE]>
        <script type="text/javascript">
         window.jQuery || document.write("<script src='assets/js/jquery-1.10.2.min.js'>"+"<"+"/script>");
        </script>
        <![endif]-->

        <script type="text/javascript">
            if ("ontouchend" in document) document.write("<script src='assets/js/jquery.mobile.custom.min.js'>" + "<" + "/script>");
        </script>

        <!-- inline scripts related to this page -->

        <script type="text/javascript">
            function show_box(id) {
                jQuery('.widget-box.visible').removeClass('visible');
                jQuery('#' + id).addClass('visible');
            }
        </script>
    </form>
</body>
</html>
