<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-family:Arial">
            <asp:Button ID="public" runat="server" Text="Get Public Message" OnClick="public_Click" />
            <br />
            <asp:Label ID="myLabel" runat="server"  Font-Bold="true"></asp:Label>
        </div>

        <div style="font-family:Arial">
            <asp:Button ID="private" runat="server" Text="Get Private Message" OnClick="private_Click" />
            <br />
            <asp:Label ID="myLabel1" runat="server"  Font-Bold="true"></asp:Label>
        </div>
    </form>
</body>
</html>
