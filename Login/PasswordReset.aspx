<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PasswordReset.aspx.cs" Inherits="Login.PasswordReset" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h3>
            New password
        </h3>
        <asp:TextBox ID="NewPasswordTextbox" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        <h3>
            Confirm password
        </h3>
        <asp:TextBox ID="ConfirmPasswordTextbox" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        <h3>
            Portected field
        </h3>
        <asp:TextBox ID="ProtectedStringTextbox" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="ChangePasswordButton" runat="server" Text="ChangePassword" OnClick="ChangePasswordButton_Click" style="height: 26px" />
        <asp:Label ID="Message" runat="server" Visible="false"></asp:Label>
    </form>
</body>
</html>
