<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddPhone.aspx.cs" Inherits="ShopPhone1.AddPhone" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thêm mới điện thoại</title>
    <link rel="stylesheet" type="text/css" href="Styles/AddPhone.css" />
</head>
<body>
    <form id="form1" method="post" runat="server"  enctype="multipart/form-data" action="AddPhone.aspx">
    <div>
        <asp:Label runat="server" Text="Tên điện thoại:" height="30px" width="200px"/>
        <asp:TextBox ID="txtName" runat="server" /></br>
        <asp:Label  runat="server" Text="Hãng sản xuất:"  height="30px" width="200px"/>
        <select id="select1" runat="server">
            <option>Apple</option>
            <option>SamSumg</option>
            <option>Xiaomi</option>
            <option>Nokia</option>
            <option>LG</option>
            <option>OPPO</option>
            
        </select></br>
        <asp:Label ID="Label1" runat="server" Text="Giá:"   height="30px" width="200px"/>
        <asp:TextBox ID="txtPrice" runat="server" /><br>
        <asp:Label ID="Label3" runat="server" Text="Ảnh:"   height="30px" width="200px"/>
        <asp:FileUpload ID="uploadImg" runat="server" /></br>
        <asp:Label ID="Label2" runat="server" Text="Mô tả:"  height="30px" width="200px"/>
        <asp:TextBox ID="txtDescrible" runat="server" /></br>
        
        <asp:Button ID="btnAdd" runat="server" Text="Thêm mới" OnClick="btnAddClick"/></br>
    </div>
    </form>
</body>
</html>
