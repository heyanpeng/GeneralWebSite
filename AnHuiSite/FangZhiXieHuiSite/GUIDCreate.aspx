<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GUIDCreate.aspx.cs" Inherits="AnHuiSite.GUIDCreate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox runat="server" ID="txtGuidCount" /><br /><br />
            <asp:TextBox runat="server" ID="txtGuid" TextMode="MultiLine" Width="1000" Height="500" /><br /><br />
            <asp:Button ID="btnCreate" runat="server" Text="生成" OnClick="btnCreate_Click" />
        </div>

    </form>
</body>
</html>
