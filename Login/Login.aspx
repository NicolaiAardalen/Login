<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Login.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <style>
        .ForgotPasswordLink {
        background: none;
        border: none;
        color: blue;
        text-decoration: underline;
        cursor: pointer;
    }
    .SignUpLink {
        background: none;
        border: none;
        color: blue;
        text-decoration: underline;
        cursor: pointer;
    }
</style>
    <script>
        function ShowPassword() {
            var passwordTextbox = document.getElementById('<%= PasswordTextbox.ClientID %>');
        var showPasswordCheckbox = document.getElementById('<%= ShowPasswordCheckbox.ClientID %>');
            if (showPasswordCheckbox.checked) {
                passwordTextbox.type = "text";
            }
            else {
                passwordTextbox.type = "password";
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <h3>
            Username/Email
        </h3>
        <asp:TextBox ID="UsernameOrEmailTextbox" runat="server"></asp:TextBox>
        <h3>
            Password
        </h3>
        <asp:TextBox ID="PasswordTextbox" runat="server" TextMode="Password" />
        <asp:CheckBox ID="ShowPasswordCheckbox" runat="server" onchange="ShowPassword()" />
        <br />
        <br />
        <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="Login_Click"/>
        <asp:Label ID="WrongPassword" runat="server" Text="Wrong password!" Visible="false" ForeColor="Red" />
        <br />
        <br />
        <asp:Button ID="ForgotPassword" runat="server" Text="Forgot your password" OnClick="ForgotPassword_Click" CssClass="ForgotPasswordLink" Width="144px" />
        <br />
        <br />
        <asp:Button ID="SignUp" runat="server" Text="Sign up" OnClick="SignUp_Click" CssClass="SignUpLink" />
    </form>
</body>
</html>