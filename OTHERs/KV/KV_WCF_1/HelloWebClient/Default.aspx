<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-family:Arial">
            <asp:Button ID="Button1" runat="server" Text="Get Message" OnClick="Button1_Click" />
            <asp:TextBox ID="myTextBox" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="myLabel" runat="server" Text="Label" Font-Bold="true"></asp:Label>
        </div>
        
    </form>
</body>
</html>
