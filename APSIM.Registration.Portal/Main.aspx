<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="APSIM.Registration.Portal.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>APSIM Downloads</h1>
    <form id="form1" runat="server">
        <div>
            <asp:Label id="lblEmail" runat="server">Email: </asp:Label><asp:TextBox id="txtEmail" runat="server"></asp:TextBox>
            <asp:Button id="btnGo" text="Go" onClick="OnSubmitClicked" runat="server" />
            <asp:Label ID="lblStatus" runat="server" />
        </div>
    </form>
</body>
</html>
