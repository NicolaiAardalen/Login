<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="Login.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h3>
            Username
        </h3>
        <asp:TextBox ID="UsernameTextBox" runat="server"></asp:TextBox>
        <br />
        <h3>
            Email
        </h3>
        <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
        <br />
        <h3>
            Password
        </h3>
        <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        
        <asp:Button ID="SignUpButton" runat="server" Text="Sign up!" OnClick="SignUpButton_Click" />
        <br />
        <br />
        <br />
        <br />
         Admin
        <br />
        <asp:TextBox ID="AdminTextbox" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <br />
    </form>
</body>
</html>
