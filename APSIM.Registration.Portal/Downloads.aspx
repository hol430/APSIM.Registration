<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Downloads.aspx.cs" Inherits="APSIM.Registration.Portal.Downloads" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" media="screen" href="Downloads.css" type="text/css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>APSIM Upgrades</h1>
        <div>
            <label>Product:</label>
            <asp:DropDownList id="productsDropDown" OnSelectedIndexChanged="SelectedProductChanged" AutoPostBack="true" runat="server" />
        </div>
        <br />
        <asp:Table id="tblDownloads" runat="server">
            <asp:TableHeaderRow runat="server">
                <asp:TableHeaderCell runat="server">Release Date</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">Release Number</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">Release Information</asp:TableHeaderCell>
                <asp:TableHeaderCell runat="server">Download Link</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
        <br />
        <label>Max number of rows:</label>
        <asp:TextBox ID="NumRowsTextBox" type="number" runat="server" AutoPostBack="True" ontextchanged="OnNumRowsChanged" >10</asp:TextBox>
    </form>
</body>
</html>
