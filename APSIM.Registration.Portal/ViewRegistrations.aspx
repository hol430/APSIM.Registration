<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewRegistrations.aspx.cs" Inherits="ProductRegistration.ViewRegistrations" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
       ConnectionString="Data Source=apsimdev.apsim.info;Initial Catalog=ProductRegistrations;Persist Security Info=True;User ID=sv-login-internal;password=P@ssword123" 
       SelectCommand="SELECT * FROM [Registrations]"></asp:SqlDataSource>
</body>
</html>
