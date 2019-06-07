<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="ProductRegistration.Registration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>APSIM Initiative Product Registration</title>
    <link rel="stylesheet" media="screen" href="Screen_Styles.css" type="text/css" />
    <style type="text/css">
       #form1
       {
          height: 565px;
       }
    </style>
</head>
<body>
   <h1>
      APSIM Initiative Product Registration
   </h1>
   To download software you must complete the registration form below. All fields marked with an asterisk (*) are mandatory.
    <form id="form1" runat="server">
      <asp:Label ID="ErrorLabel" runat="server" Font-Bold="True" ForeColor="#FF3300" 
         Visible="False"></asp:Label>
      <asp:Table 
         ID="Table1" runat="server" Height="500px" Width="836px"
         EnableTheming="True">
         <asp:TableRow ID="TableRow1" runat="server">
            <asp:TableCell ID="TableCell1" runat="server">Product to download*:</asp:TableCell>
            <asp:TableCell ID="TableCell2" runat="server"><asp:DropDownList ID="Product" runat="server" Width="200px" AutoPostBack="True"/></asp:TableCell>
         </asp:TableRow>
         <asp:TableRow runat="server">
            <asp:TableCell ID="VersionLabel" runat="server"> </asp:TableCell>
            <asp:TableCell runat="server"><asp:DropDownList ID="Version" runat="server" Width="200px"></asp:DropDownList></asp:TableCell>
         </asp:TableRow>
         <asp:TableRow runat="server">
            <asp:TableCell runat="server"> </asp:TableCell>
            <asp:TableCell runat="server"> </asp:TableCell>
         </asp:TableRow>
         <asp:TableRow runat="server">
            <asp:TableCell runat="server">First name:*</asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="FirstName" runat="server" Width="400px"></asp:TextBox></asp:TableCell>
         </asp:TableRow>
         <asp:TableRow runat="server">
            <asp:TableCell runat="server">Last name*:</asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="LastName" runat="server" Width="400px"></asp:TextBox></asp:TableCell>
         </asp:TableRow>
         <asp:TableRow runat="server">
            <asp:TableCell runat="server">Organisation*:</asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="Organisation" runat="server" Width="400px"></asp:TextBox></asp:TableCell>
         </asp:TableRow>
         <asp:TableRow runat="server">
            <asp:TableCell runat="server">Address 1*:</asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="Address1" runat="server" Width="400px"></asp:TextBox></asp:TableCell>
         </asp:TableRow>
         <asp:TableRow runat="server">
            <asp:TableCell runat="server">Address 2:</asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="Address2" runat="server" Width="400px"></asp:TextBox></asp:TableCell>
         </asp:TableRow>
         <asp:TableRow runat="server">
            <asp:TableCell runat="server">City/Location*:</asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="City" runat="server" Width="200px"></asp:TextBox></asp:TableCell>
         </asp:TableRow>
         <asp:TableRow runat="server">
            <asp:TableCell runat="server">State/Province:</asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="State" runat="server" Width="200px"></asp:TextBox></asp:TableCell>
         </asp:TableRow>
         <asp:TableRow runat="server">
            <asp:TableCell runat="server">Postcode/Zipcode*:</asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="Postcode" runat="server" Width="200px"></asp:TextBox></asp:TableCell>
         </asp:TableRow>
         <asp:TableRow runat="server">
            <asp:TableCell runat="server">Country*:</asp:TableCell>
            <asp:TableCell runat="server">
                <asp:DropDownList ID="Country" runat="server" Width="200px">
                    <asp:ListItem Value=""></asp:ListItem>
               </asp:DropDownList>                                          
            </asp:TableCell>
         </asp:TableRow>
         <asp:TableRow runat="server">
            <asp:TableCell runat="server">Email*:</asp:TableCell>
            <asp:TableCell runat="server"><asp:TextBox ID="Email" runat="server" Width="400px"></asp:TextBox></asp:TableCell>
         </asp:TableRow>
      </asp:Table>
      <asp:Button ID="YesButton" runat="server" Text="Yes I agree, begin download" onclick="YesButton_Click" Width="238px" />
      <asp:Button ID="NoButton" runat="server" Text="No I don't agree, go back" 
            onclick="NoButton_Click" /><br />
      <asp:Label ID="CompleteLabel" runat="server" Text="            " Font-Bold="True" 
         ForeColor="#0066FF"></asp:Label>
      </form>
      <asp:Label runat="server">Terms:</asp:Label>
      <asp:Table 
         ID="Table2" runat="server" Height="100px" Width="836px"
         EnableTheming="True">
         <asp:TableRow ID="TableRow2" runat="server">
            <asp:TableCell ID="Terms" runat="server"></asp:TableCell>
         </asp:TableRow>
      </asp:Table>      
</body>
</html>

