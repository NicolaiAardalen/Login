<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="Login.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign up</title>
    <script>
        function ShowPassword() {
            var passwordTextbox = document.getElementById('<%= PasswordTextBox.ClientID %>');
            var showPasswordCheckbox = document.getElementById('<%= ShowPasswordCheckbox.ClientID %>');
            if (showPasswordCheckbox.checked) {
                passwordTextbox.type = "text";
            }
            else {
                passwordTextbox.type = "password";
            }
        }
        function ShowAdminPassword() {
            var adminTextbox = document.getElementById('<%= AdminTextbox.ClientID %>');
            var showAdminPasswordCheckbox = document.getElementById('<%= ShowAdminPasswordCheckbox.ClientID %>');
            if (showAdminPasswordCheckbox.checked) {
                adminTextbox.type = "text";
            }
            else {
                adminTextbox.type = "password";
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="Back" runat="server" Text="Back" OnClick="Back_Click" />
        <br />
        <br />
        <h3>
            Username
        </h3>
        <asp:TextBox ID="UsernameTextBox" runat="server" />
        <br />
        <h3>
            Email
        </h3>
        <asp:TextBox ID="EmailTextBox" runat="server" />
        <br />
        <h3>
            Password
        </h3>
        <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" />
        <asp:CheckBox ID="ShowPasswordCheckbox" runat="server" onchange="ShowPassword()" />
        <br />
        <br />
        
        <asp:Button ID="SignUpButton" runat="server" Text="Sign up!" OnClick="SignUpButton_Click" />
        <br />
        <br />
        <br />
        <br />
         Admin
        <br />
        <asp:TextBox ID="AdminTextbox" runat="server" TextMode="Password" />
        <asp:CheckBox ID="ShowAdminPasswordCheckbox" runat="server" onchange="ShowAdminPassword()" />
        <br />
        <br />
    </form>
</body>
</html>
