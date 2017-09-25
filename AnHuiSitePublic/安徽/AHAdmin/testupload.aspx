<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testupload.aspx.cs" Inherits="AnHuiSite.AHAdmin.testupload" %>

<%@ Register Assembly="Brettle.Web.NeatUpload" Namespace="Brettle.Web.NeatUpload" TagPrefix="Upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript">
        function ToggleVisibility(id, type) {
            el = document.getElementById(id);
            if (el.style) {
                if (type == 'on') {
                    el.style.display = 'block';
                }
                else {
                    el.style.display = 'none';
                }
            }
            else {
                if (type == 'on') {
                    el.display = 'block';
                }
                else {
                    el.display = 'none';
                }
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <Upload:InputFile ID="AttachFile" runat="server" BorderWidth="1" BorderColor="#d5d5d5" Width="245" />*支持flv,mp4,mov,f4v,3gp格式视频文件
            <br />
            <Upload:ProgressBar ID="ProgressBar1" runat='server' Inline="true" Width="475px" Height="50px" />
            <br />
            <asp:Button ID="btnUpload" Width="68" runat="server" Text="上传" OnClientClick="ToggleVisibility('ProgressBar1','on')" OnClick="btnUpload_Click" />
            <input type="text" id="txtFileInfo" name="txtFileInfo" value="<%=fileinfo %>" style="border:0px;" readonly="true" />
        </div>
    </form>
</body>
</html>
