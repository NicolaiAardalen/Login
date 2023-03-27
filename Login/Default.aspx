<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Login.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
  <title>Main</title>
  <style>
      body {
  font-family: Arial, Helvetica, sans-serif;
  margin: 0;
}

#myLinks {
  display: none;
  position: fixed;
  top: 50px;
  left: 0;
  background-color: #333;
  width: 200px;
  padding-left: 50px;
  z-index: 1;
}

a {
  color: white;
  padding: 14px 16px;
  text-decoration: none;
  font-size: 17px;
  display: block;
}

a.icon {
  background: black;
  display: block;
  position: fixed;
  right: auto;
  top: 0;
}

a.icon:hover {
  background-color: #ddd;
  color: black;
}
  </style>
</head>
<body>
    <form id="form1" runat="server">

  <a href="javascript:void(0);" class="icon" onclick="myFunction()">
    <i class="fa fa-bars"></i>
  </a>
  <div id="myLinks">
    <a href="#news">News</a>
    <a href="#contact">Contact</a>
    <a href="#about">About</a>
  </div>

<script>
    function myFunction() {
        var x = document.getElementById("myLinks");
        if (x.style.display === "block") {
            x.style.display = "none";
        } else {
            x.style.display = "block";
        }
    }
</script>
    </form>
</body>
</html>