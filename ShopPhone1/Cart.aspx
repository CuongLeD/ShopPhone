<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="ShopPhone1.Cart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Giỏ hàng</title>
    <link rel="stylesheet" href="styles/bootstrap-337.min.css">
    <link rel="stylesheet" href="font-awsome/css/font-awesome.min.css">
    <link rel="stylesheet" href="styles/style.css">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css" integrity="sha384-50oBUHEmvpQ+1lW4y57PTFmhCaXp0ML5d60M1M7uH2+nqUivzIebhndOJK28anvf" crossorigin="anonymous">
</head>
<body>

    <div id="fb-root"></div>
  <script async defer crossorigin="anonymous" src="https://connect.facebook.net/vi_VN/sdk.js#xfbml=1&version=v3.2"></script>
   
   <div id="top"><!-- Top Begin -->       
       <div class="container"><!-- container Begin -->           
           <div class="col-md-12 offer"><!-- col-md-6 offer Begin -->               
               <h4 style="text-align: center;">Welcome to WIEE Shop. Hãy tận hưởng những giây phút mua sắm thoải mái với WIEE Shop</h4>            
               
           </div><!-- col-md-6 offer Finish -->          
       </div><!-- container Finish -->       
   </div><!-- Top Finish --> 
   <div id="navbar" class="navbar navbar-default"><!-- navbar navbar-default Begin -->       
       <div class="container"><!-- container Begin -->           
           <div class="navbar-header"><!-- navbar-header Begin -->               
               <a href="Home.aspx" class="navbar-brand home"><!-- navbar-brand home Begin -->                   
                   <img style="height: 50px;" src="images/wiee shop.png" alt="WIEE SHOP Logo" class="hidden-xs">
                   <img style="height: 50px;" src="images/wieeshop.png" alt="WIEE SHOP Logo" class="visible-xs">                   
               </a><!-- navbar-brand home Finish -->               
               <button class="navbar-toggle" data-toggle="collapse" data-target="#navigation">                   
                   <span class="sr-only">Toggle Navigation</span>                   
                   <i class="fa fa-align-justify"></i>                   
               </button>               
               <button class="navbar-toggle" data-toggle="collapse" data-target="#search">                   
                   <span class="sr-only">Toggle Search</span>                   
                   <i class="fa fa-search"></i>                   
               </button>               
           </div><!-- navbar-header Finish -->           
           <div class="navbar-collapse collapse" id="navigation"><!-- navbar-collapse collapse Begin -->               
               <div class="padding-nav"><!-- padding-nav Begin -->                   
                   <ul class="nav navbar-nav left"><!-- nav navbar-nav left Begin -->                       
                       <li>
                           <a href="Home.aspx"><i class="fas fa-home"></i> Trang chủ</a>
                       </li >
                       <li >
                           <a href="Shop.aspx"><i class="fas fa-store"></i> Shop</a>
                       </li>                       
                       <li class="active">
                           <a href="Cart.aspx"><i class="fas fa-cart-plus"></i> Giỏ hàng</a>                           
                       </li>
                       <li >
                           <a href="Blog.aspx"><i class="far fa-newspaper"></i> Tin tức</a>
                       </li>                       
                   </ul><!-- nav navbar-nav left Finish -->                   
               </div><!-- padding-nav Finish -->
                                                      
           </div><!-- navbar-collapse collapse Finish -->           
       </div><!-- container Finish -->       
   </div><!-- navbar navbar-default Finish -->

   <div id="content"><!-- #content Begin -->
       <div class="container"><!-- container Begin -->
           <div class="col-md-12"><!-- col-md-12 Begin -->
               
               <ul class="breadcrumb"><!-- breadcrumb Begin -->
                   <li>
                       <a href="Home.aspx">Trang chủ</a>
                   </li>
                   <li>
                       Giỏ hàng
                   </li>
               </ul><!-- breadcrumb Finish -->
               
           </div><!-- col-md-12 Finish -->

        <div id="cart" class="col-md-9"><!-- col-md-9 Begin -->
               
               <div class="box"><!-- box Begin -->
                   
                   <form action="Cart.aspx" method="post" enctype="multipart/form-data"><!-- form Begin -->
                       
                       <h1>Giỏ hàng</h1>                                                                                                                   
                       <div class="table-responsive"><!-- table-responsive Begin -->                           
                           <table class="table"><!-- table Begin -->                               
                               <thead><!-- thead Begin -->                                   
                                   <tr><!-- tr Begin -->                                       
                                       <th colspan="2">Sản Phẩm</th>
                                       <th>Số Lượng</th>
                                       <th>Giá</th>
                                       <th colspan="1">Tổng Tiền</th>
                                       <th colspan="1">Xóa</th>                                       
                                   </tr><!-- tr Finish -->                                   
                               </thead><!-- thead Finish -->                               
                               <tbody><!-- tbody Begin -->                                                                                                       
                                   <%Response.Write(showListPhone);
                                     showListPhone = ""; %>
                                   
                               </tbody><!-- tbody Finish -->
                               
                               <tfoot><!-- tfoot Begin -->
                                   
                                   <tr><!-- tr Begin -->
                                       
                                       <th colspan="5">Tổng tiền</th>
                                       <th colspan="2"><%Response.Write(totalPayment + " VNĐ"); %> </th>
                                       
                                   </tr><!-- tr Finish -->
                                   
                               </tfoot><!-- tfoot Finish -->
                               
                           </table><!-- table Finish -->
                           
                       </div><!-- table-responsive Finish -->
                       
                       <div class="box-footer"><!-- box-footer Begin -->
                           
                           <div class="pull-left"><!-- pull-left Begin -->
                               
                               <a href="Shop.aspx" class="btn btn-default"><!-- btn btn-default Begin -->
                                   
                                   <i class="fa fa-chevron-left"></i> Tiếp Tục Mua Sắm
                                   
                               </a><!-- btn btn-default Finish -->
                               
                           </div><!-- pull-left Finish -->
                           
                           <div class="pull-right"><!-- pull-right Begin -->
                               
                               
                               <a href="Checkout.aspx" class="btn btn-primary">
                                   
                                   Đặt Hàng <i class="fa fa-chevron-right"></i>
                                   
                               </a>
                               
                           </div><!-- pull-right Finish -->
                           
                       </div><!-- box-footer Finish -->
                       
                   </form><!-- form Finish -->
                   
               </div><!-- box Finish -->                              
               <div class="content">
                  <div class="container">
                    <div class="col-md-9">
                      <h3 style="text-align: left; font-weight: bold;">Sản Phẩm Tương Tự</h3>
                    </div>
                  </div>
               </div>
               <hr>

               <div id="row same-heigh-row"><!-- #row same-heigh-row Begin -->                                      
                   <%Response.Write(showSimilarPhone);
                      showSimilarPhone = ""; %> 
                   
               </div><!-- #row same-heigh-row Finish -->
               
           </div><!-- col-md-9 Finish -->
           
           <div class="col-md-3"><!-- col-md-3 Begin -->
               
               <div id="order-summary" class="box"><!-- box Begin -->
                   
                   <div class="box-header"><!-- box-header Begin -->
                       
                       <h3>Tóm tắt đơn hàng</h3>
                       
                   </div><!-- box-header Finish -->
                   
                   <p class="text-muted"><!-- text-muted Begin -->
                       
                       Đơn hàng từ 200,000 VNĐ trở lên sẽ được miễn phí vận chuyển
                       
                   </p><!-- text-muted Finish -->
                   
                   <div class="table-responsive"><!-- table-responsive Begin -->
                       
                       <table class="table"><!-- table Begin -->
                           
                           <tbody><!-- tbody Begin -->
                               
                               <tr><!-- tr Begin -->
                                   
                                   <td>Tổng Tiền</td>
                                   <td> <%Response.Write(totalPayment + " VNĐ"); %> </td>
                                   
                               </tr><!-- tr Finish -->
                               
                               <tr><!-- tr Begin -->
                                   
                                   <td> Phí vận chuyển </td>
                                   <td> 0 VNĐ </td>
                                   
                               </tr><!-- tr Finish -->
                               
                               <tr><!-- tr Begin -->
                                   
                                   <td> Thuế </td>
                                   <td> 0 VNĐ </td>
                                   
                               </tr><!-- tr Finish -->
                               
                               <tr class="total"><!-- tr Begin -->
                                   
                                   <td> Thành tiền </td>
                                   <th> <%Response.Write(totalPayment + " VNĐ"); %> </th>
                                   
                               </tr><!-- tr Finish -->
                               
                           </tbody><!-- tbody Finish -->
                           
                       </table><!-- table Finish -->
                       
                   </div><!-- table-responsive Finish -->
                   
               </div><!-- box Finish -->
               
           </div><!-- col-md-3 Finish -->
           
       </div><!-- container Finish -->
   </div><!-- #content Finish -->
   
   </div><!-- #footer Finish -->

 <!--Footer-->
    <div id="footer"><!-- #footer Begin -->
    <div class="container"><!-- container Begin -->
        <div class="row"><!-- row Begin -->
            
            <div class="com-sm-6 col-md-3"><!-- col-sm-6 col-md-3 Begin -->
                
                <h4 style="font-weight: bold" >Danh Mục Sản Phẩm</h4>
                
                <ul><!-- ul Begin -->                
                    <% Response.Write(categories);
                       categories = "";%>                
                </ul><!-- ul Finish -->
                
                <hr class="hidden-md hidden-lg">
                
            </div><!-- col-sm-6 col-md-3 Finish -->
            
            <div class="col-sm-6 col-md-3"><!-- col-sm-6 col-md-3 Begin -->
                
                <h4 style="font-weight: bold">Liên hệ</h4>
                
                <p><!-- p Start -->
                    <i class="fas fa-phone-volume"></i> Điện thoại 0363720461
                </p><!-- p Finish -->
                <p>
                    <i class="far fa-envelope"></i> Email : wieeshop@gmail.com
                </p>
                <p>
                    <i class="fas fa-user-friends"></i> Thành Viên Nhóm
                </p>
                <p>1. Lê Đình Cường <br> 2. Nguyễn Minh Việt <br> 3. Nguyễn Đình Lộc <br> 4. Trần Đình Thái</p>
                
                
                <hr class="hidden-md hidden-lg">
                
            </div><!-- col-sm-6 col-md-3 Finish -->
            <div class="col-sm-6 col-md-3"><!-- col-sm-6 col-md-3 Begin -->
               <h4 style="font-weight: bold" >Fanpage</h4>
                <div class="fb-page" data-href="https://www.facebook.com/WIEESHOP/" data-tabs="timeline" data-width="300" data-height="200" data-small-header="false" data-adapt-container-width="true" data-hide-cover="false" data-show-facepile="true"><blockquote cite="https://www.facebook.com/WIEESHOP/" class="fb-xfbml-parse-ignore"><a href="https://www.facebook.com/WIEESHOP/">WIEE SHOP</a></blockquote></div>
                
                <hr class="hidden-md hidden-lg">
            </div><!-- col-sm-6 col-md-3 Finish -->
            <div class="col-sm-6 col-md-3">
                <h4 style="font-weight: bold">Vị Trí Cửa Hàng</h4>
                <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d59591.68078231009!2d105.76163571407439!3d21.013469674384847!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3135acce762c2bb9%3A0xbb64e14683ccd786!2zSOG7jWMgdmnhu4duIEPDtG5nIG5naOG7hyBCxrB1IGNow61uaCBWaeG7hW4gdGjDtG5nIC0gUFRJVA!5e0!3m2!1svi!2sus!4v1555171439724!5m2!1svi!2sus" width="300" height="200" frameborder="0" style="border:0" allowfullscreen></iframe>
            </div>    
                    
                
            
        </div><!-- row Finish -->
    </div><!-- container Finish -->
</div><!-- #footer Finish -->


<div id="copyright"><!-- #copyright Begin -->
    <div class="container"><!-- container Begin -->
        <div class="col-md-12"><!-- col-md-12 Begin -->
            
            <p style="text-align: center;">&copy; 2019 WIEE SHOP All Rights Reserve</p>
            
        </div><!-- col-md-12 Finish -->
        
    </div><!-- container Finish -->
</div><!-- #copyright Finish -->
<script src="js/jquery-331.min.js"></script>
<script src="js/bootstrap-337.min.js"></script>
</body>
</html>