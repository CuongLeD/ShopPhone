<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ShopPhone1.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  

  <title>Login</title>

  <!-- Custom fonts for this template-->
  <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css" />

  <!-- Custom styles for this template-->
  <link href="css/sb-admin.css" rel="stylesheet" />

</head>

<body class="bg-dark">

  <div class="container">
    <div class="card card-login mx-auto mt-5">
      <div class="card-header">Login</div>
      <div class="card-body">
        <form id="form1" runat="server" >
            <table>
                <tr>
                    <td>User</td>
                    <td><asp:TextBox ID="inputUser" runat="server" /></td>
                </tr>
                <tr>
                    <td>Password</td>
                    <td><input type="password" id="inputPassword" runat="server" /></td>
                </tr>
                <tr>
                    <td><asp:Button ID="Button1" runat="server" Text="Login" OnClick="login_Click" /></td>
                </tr>
            </table>
        </form>
        
      </div>
    </div>
  </div>

 
</body>

</html>
