<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Downloads.aspx.cs" Inherits="APSIM.Registration.Portal.Downloads" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>APSIM Downloads</h1>
        <div>
            <label>Product: </label><asp:DropDownList id="productsDropDown" OnSelectedIndexChanged="SelectedProductChanged" AutoPostBack="true" runat="server" />
            <asp:Table id="tblDownloads" runat="server">
                <asp:TableHeaderRow runat="server">
                    <asp:TableHeaderCell runat="server">Version Name</asp:TableHeaderCell>
                    <asp:TableHeaderCell runat="server">Version Number</asp:TableHeaderCell>
                    <asp:TableHeaderCell runat="server">Release Date</asp:TableHeaderCell>
                    <asp:TableHeaderCell runat="server">Download Link</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
            <br />
            <br />
            <asp:Label ID="downloadLink" runat="server" />
        </div>
    </form>
</body>
</html>
