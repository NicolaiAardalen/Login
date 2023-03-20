<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetLinkToEmail.aspx.cs" Inherits="Login.ResetLinkToEmail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="BackToLogin" runat="server" Text="Back" OnClick="BackToLogin_Click" />
        <br />
        <br />
        <asp:TextBox ID="EmailTextbox" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="SendEmailLink" runat="server" Text="Send reset link" OnClick="SendEmailLink_Click" />
    </form>
</body>
</html>
