<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Login.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta charset="UTF-8" />
  <title>Hamburger Menu</title>
  <style>
    * {
      margin: 0;
      padding: 0;
      box-sizing: border-box;
    }
    header {
      display: flex;
      justify-content: space-between;
      align-items: center;
      background-color: #333;
      color: #fff;
      padding: 20px;
    }
    .logo {
      font-size: 30px;
      font-weight: bold;
    }
    .menu-btn {
      display: flex;
      flex-direction: column;
      justify-content: space-between;
      height: 20px;
      cursor: pointer;
    }
    .menu-btn span {
      display: block;
      height: 3px;
      width: 100%;
      background-color: #fff;
      border-radius: 3px;
      transition: all 0.3s ease-in-out;
    }
    .menu-btn.open span:nth-child(2) {
      opacity: 0;
    }
    .menu-btn.open span:nth-child(1) {
      transform: translateY(5px) rotate(45deg);
    }
    .menu-btn.open span:nth-child(3) {
      transform: translateY(-5px) rotate(-45deg);
    }
    .menu {
      display: none;
    }
    .menu.open {
      display: block;
    }
    .menu ul {
      list-style: none;
      padding: 20px;
    }
    .menu li {
      font-size: 20px;
      margin-bottom: 10px;
      cursor: pointer;
    }
  </style>
</head>
<body>
    <form id="form1" runat="server">
        <h3>
            Welcome <asp:Label ID="UsernameLabel" runat="server" />
        </h3>
        <header>
    <div class="logo">Logo</div>
    <div class="menu-btn">
      <span></span>
      <span></span>
      <span></span>
    </div>
  </header>
  <div class="menu">
    <ul>
      <li>Home</li>
      <li>About</li>
      <li>Contact</li>
    </ul>
  </div>
        <script>
            const hamburgerMenu = document.querySelector('.hamburger-menu');
            const menu = document.querySelector('.menu');

            let menuOpen = false;
            hamburgerMenu.addEventListener('click', () => {
                if (!menuOpen) {
                    hamburgerMenu.classList.add('open');
                    menu.classList.add('open');
                    menuOpen = true;
                } else {
                    hamburgerMenu.classList.remove('open');
                    menu.classList.remove('open');
                    menuOpen = false;
                }
            });
        </script>
    </form>
</body>
</html>
