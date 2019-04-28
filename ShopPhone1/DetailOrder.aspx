﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailOrder.aspx.cs" Inherits="ShopPhone1.DetailOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <meta name="description" content="">
  <meta name="author" content="">

  <title>Chi tiết đơn hàng</title>

  <!-- Custom fonts for this template-->
  <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">

  <!-- Page level plugin CSS-->
  <link href="vendor/datatables/dataTables.bootstrap4.css" rel="stylesheet">

  <!-- Custom styles for this template-->
  <link href="css/sb-admin.css" rel="stylesheet">

</head>

<body id="page-top">

  <nav class="navbar navbar-expand navbar-dark bg-dark static-top">

    <a class="navbar-brand mr-1" href="index.html">Admin</a>

    <button class="btn btn-link btn-sm text-white order-1 order-sm-0" id="sidebarToggle" href="#">
      <i class="fas fa-bars"></i>
    </button>

    <!-- Navbar Search -->
    <form class="d-none d-md-inline-block form-inline ml-auto mr-0 mr-md-3 my-2 my-md-0">
      <div class="input-group">
        <input type="text" class="form-control" placeholder="Search for..." aria-label="Search" aria-describedby="basic-addon2">
        <div class="input-group-append">
          <button class="btn btn-primary" type="button">
            <i class="fas fa-search"></i>
          </button>
        </div>
      </div>
    </form>

    <!-- Navbar -->
    
  </nav>

  <div id="wrapper">

    <!-- Sidebar -->
    <ul class="sidebar navbar-nav">
      <li class="nav-item active">
        <a class="nav-link" href="Admin.aspx">
          <i class="fas fa-fw fa-tachometer-alt"></i>
          <span>Quản lý điện thoại</span>
        </a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="ManageEmployee.aspx">
          <i class="fas fa-fw fa-folder"></i>
          <span>Quản lý nhân viên</span>
        </a>        
      </li>
      <li class="nav-item">
        <a class="nav-link" href="ManageOrder.aspx">
          <i class="fas fa-fw fa-chart-area"></i>
          <span>Quản lý Đơn hàng</span></a>
      </li> 
       <li class="nav-item">
        <a class="nav-link" href="ManageCustomer.aspx">
          <i class="fas fa-fw fa-chart-area"></i>
          <span>Quản lý khách hàng</span></a>
      </li>      
    </ul>

   <div id="content-wrapper">

      <div class="container-fluid">

        <!-- Breadcrumbs-->
        <ol class="breadcrumb">
          <li class="breadcrumb-item">
            <a href="Admin.aspx">Admin</a>
          </li>
          <li class="breadcrumb-item active">Quản lý đơn hàng</li>
          <li class="breadcrumb-item active">Chi tiết đơn hàng</li>
        </ol>

        <!-- Page Content -->
        <table>
                <tr>
                    <th>ID đơn hàng:</th>
                    <td><%Response.Write(orderId);%></td>
                </tr>
              <tr>
                    <th>Tên khách hàng:</th>
                    <td><%Response.Write(customerName); %></td>
              </tr>   
              <tr>
                    <th>Nhân viên thanh toán:</th>
                    <td><%Response.Write(employeeName); %></td>
              </tr>
                <tr>
                    <th>Tổng số tiền thanh toán:</th>
                    <td><%Response.Write(totalPayment); %></td>
              </tr>   
            </table> 
        <div class="card mb-3">
          <div class="card-header">
            <i class="fas fa-table"></i>            
           <div class="card-body">
            <div class="table-responsive">
              <table class="table table-bordered" id="dataTable" " width="100%" cellspacing="0">
                <thead>
                  <tr>
                    <th>STT</th>                   
                    <th>Tên điện thoại</th>
                    <th>Số lượng</th>
                    <th>Đơn giá</th>
                    <th>Tổng tiền</th>               
                   </tr>
                </thead>
                
                <tbody>
                  <%Response.Write(show);
                    show = ""; %>
                </tbody>
              </table>
           </div>
          </div>          
        </div>
      </div>

      <!-- Sticky Footer -->
      <footer class="sticky-footer">
        <div class="container my-auto">
          <div class="copyright text-center my-auto">
            <span>Copyright © Phone Shop 2019</span>
          </div>
        </div>
      </footer>

    </div>
    <!-- /.content-wrapper -->

  </div>
  <!-- /#wrapper -->

  <!-- Scroll to Top Button-->
  <a class="scroll-to-top rounded" href="#page-top">
    <i class="fas fa-angle-up"></i>
  </a>

  <!-- Logout Modal-->
  <div class="modal fade" id="logoutModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="exampleModalLabel">Ready to Leave?</h5>
          <button class="close" type="button" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">×</span>
          </button>
        </div>
        <div class="modal-body">Select "Logout" below if you are ready to end your current session.</div>
        <div class="modal-footer">
          <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancel</button>
          <a class="btn btn-primary" href="login.html">Logout</a>
        </div>
      </div>
    </div>
  </div>

  <!-- Bootstrap core JavaScript-->
  <script src="vendor/jquery/jquery.min.js"></script>
  <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

  <!-- Core plugin JavaScript-->
  <script src="vendor/jquery-easing/jquery.easing.min.js"></script>

  <!-- Page level plugin JavaScript-->
  <script src="vendor/datatables/jquery.dataTables.js"></script>
  <script src="vendor/datatables/dataTables.bootstrap4.js"></script>

  <!-- Custom scripts for all pages-->
  <script src="js/sb-admin.min.js"></script>

  <!-- Demo scripts for this page-->
  <script src="js/demo/datatables-demo.js"></script>

</body>

</html>

