<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="ShopPhone1.Checkout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Thanh toán</title>
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


   <div id="content">
  <form  runat="server" method="post" class="form-horizontal" enctype="multipart/form-data"><!-- form-horizontal Begin -->
                   
     <div class="form-group"><!-- form-group Begin -->
         
        <label class="col-md-3 control-label"> Họ và tên </label> 
        
        <div class="col-md-6"><!-- col-md-6 Begin -->
            
            <input name="name" id="txtname" runat="server" type="text" class="form-control" required />
            
        </div><!-- col-md-6 Finish -->
         
     </div><!-- form-group Finish -->
     
     <div class="form-group"><!-- form-group Begin -->
         
        <label class="col-md-3 control-label"> SĐT </label> 
        
        <div class="col-md-6"><!-- col-md-6 Begin -->
            
            <input name="contact" type="text" id="txtPhone" runat="server" class="form-control" required />
            
        </div><!-- col-md-6 Finish -->
         
     </div><!-- form-group Finish -->
     
     <div class="form-group"><!-- form-group Begin -->
         
        <label class="col-md-3 control-label"> Địa chỉ </label> 
        
        <div class="col-md-6"><!-- col-md-6 Begin -->
            
            <input name="address" runat="server" id="txtAddress" type="text" class="form-control" required />
            
        </div><!-- col-md-6 Finish -->
         
     </div><!-- form-group Finish -->

          
     
     
     <div class="form-group"><!-- form-group Begin -->
         
        <label class="col-md-3 control-label"></label> 
        
        <div class="col-md-6"><!-- col-md-6 Begin -->
            
            <asp:Button name="submit" Text="Đặt hàng" runat="server" class="btn btn-primary form-control" OnClick="btnPaymentClick" />
            
        </div><!-- col-md-6 Finish -->
         
     </div><!-- form-group Finish -->
     
  </form>
</div>

</body>
</html>
