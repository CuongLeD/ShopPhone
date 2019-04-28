<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ShopPhone1.Home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Phone Store</title>
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
                       <li class="active">
                           <a href="Home.aspx"><i class="fas fa-home"></i> Trang chủ</a>
                       </li>
                       <li>
                           <a href="Shop.aspx"><i class="fas fa-store"></i> Shop</a>
                       </li>                       
                       <li>
                           <a href="Cart.aspx"><i class="fas fa-cart-plus"></i> Giỏ hàng</a>                           
                       </li>
                       <li >
                           <a href="Blog.aspx"><i class="far fa-newspaper"></i> Tin tức</a>
                       </li>                       
                   </ul><!-- nav navbar-nav left Finish -->                   
               </div><!-- padding-nav Finish -->     
               <div class="navbar-collapse collapse right"><!-- navbar-collapse collapse right Begin -->
                   
                   <button class="btn btn-primary navbar-btn" type="button" data-toggle="collapse" data-target="#search"><!-- btn btn-primary navbar-btn Begin -->
                       
                       <span class="sr-only">Toggle Search</span>
                       
                       <i class="fa fa-search"></i>
                       
                   </button><!-- btn btn-primary navbar-btn Finish -->
                   
               </div><!-- navbar-collapse collapse right Finish -->
               <div class="collapse clearfix" id="search"><!-- collapse clearfix Begin -->
                   
                   <form method="post" runat=server class="navbar-form"><!-- navbar-form Begin -->
                       
                       
                           
                           <div class="col-md-3"><!-- col-md-7 Begin -->
                                          <select name="area" id="area" class="form-control"><!-- select Begin -->
                                           <option>Hà Nội</option>
                                           <option>Thanh Hóa</option>
                                           <option>Nghệ An</option>                                           
                                           </select><!-- select Finish -->
                                   
							</div><!-- col-md-7 Finish -->
                           
                           
                           
                          <asp:Button ID="Button1" name="submit" Text="Tìm kiếm" runat="server" class="btn btn-primary form-control" OnClick="btnSearchAreaClick" />
                           
                           
                           
                       </div><!-- input-group Finish -->
                       
                   </form><!-- navbar-form Finish -->
                   
               </div><!-- collapse clearfix Finish -->          
                                                 
           </div><!-- navbar-collapse collapse Finish -->           
       </div><!-- container Finish -->       
   </div><!-- navbar navbar-default Finish -->

   


   <div class="container" id="slider"><!-- container Begin -->       
       <div class="col-md-12"><!-- col-md-12 Begin -->           
           <div class="carousel slide" id="myCarousel" data-ride="carousel"><!-- carousel slide Begin -->               
               <ol class="carousel-indicators"><!-- carousel-indicators Begin -->                   
                   <li class="active" data-target="#myCarousel" data-slide-to="0"></li>
                   <li data-target="#myCarousel" data-slide-to="1"></li>
                   <li data-target="#myCarousel" data-slide-to="2"></li>
                   <li data-target="#myCarousel" data-slide-to="3"></li>                   
               </ol><!-- carousel-indicators Finish -->               
               <div class="carousel-inner"><!-- carousel-inner Begin -->                
                     <div class='item active'>                       
                       <img src='slides_images/slide huawei p30 series 2.jpg' />                       
                     </div>
                     <div class='item'>                       
                       <img src='slides_images/slide r17 pro.jpg' />                       
                     </div>
                     <div class='item'>                       
                       <img src='slides_images/slide samsung s10 plus.jpg' />                       
                     </div>
                     <div class='item'>                       
                       <img src='slides_images/slide iphone 2.jpg' />                       
                     </div>                                                               
               </div><!-- carousel-inner Finish -->               
               <a href="#myCarousel" class="left carousel-control" data-slide="prev"><!-- left carousel-control Begin -->                   
                   <span class="glyphicon glyphicon-chevron-left"></span>
                   <span class="sr-only">Previous</span>                   
               </a><!-- left carousel-control Finish -->               
               <a href="#myCarousel" class="right carousel-control" data-slide="next"><!-- left carousel-control Begin -->                   
                   <span class="glyphicon glyphicon-chevron-right"></span>
                   <span class="sr-only">Next</span>                   
               </a><!-- left carousel-control Finish -->               
           </div><!-- carousel slide Finish -->           
       </div><!-- col-md-12 Finish -->       
   </div><!-- container Finish -->   
   <div id="advantages"><!-- #advantages Begin -->       
       <div class="container"><!-- container Begin -->           
           <div class="same-height-row"><!-- same-height-row Begin -->               
               <div class="col-sm-4"><!-- col-sm-4 Begin -->                   
                   <div class="box same-height"><!-- box same-height Begin -->                       
                       <div class="icon"><!-- icon Begin -->                           
                           <i class="fas fa-shipping-fast"></i>                           
                       </div><!-- icon Finish -->                       
                       <h3 style="color: red; font-weight: bold;">Giao Hàng</h3>                       
                       <p style="color: red; font-weight: bold;">Giao hàng tận nơi trong thời gian ngắn</p>                       
                   </div><!-- box same-height Finish -->                   
               </div><!-- col-sm-4 Finish -->               
               <div class="col-sm-4"><!-- col-sm-4 Begin -->                   
                   <div class="box same-height"><!-- box same-height Begin -->                       
                       <div class="icon"><!-- icon Begin -->                           
                           <i class="fas fa-hand-holding-usd"></i>                           
                       </div><!-- icon Finish -->                       
                       <h3 style="color: red; font-weight: bold;">Thanh Toán</h3>                       
                       <p style="color: red; font-weight: bold;" >Đa dạng phương thức thanh toán</p>                       
                   </div><!-- box same-height Finish -->                   
               </div><!-- col-sm-4 Finish -->               
               <div class="col-sm-4"><!-- col-sm-4 Begin -->                   
                   <div class="box same-height"><!-- box same-height Begin -->                       
                       <div class="icon"><!-- icon Begin -->                           
                           <i class="fa fa-thumbs-up"></i>                           
                       </div><!-- icon Finish -->                       
                       <h3 style="color: red; font-weight: bold;">100% Chính Hãng</h3>                       
                       <p style="color: red; font-weight: bold;">Đảm bảo 100% hàng chính hãng</p>                       
                   </div><!-- box same-height Finish -->                   
               </div><!-- col-sm-4 Finish -->               
           </div><!-- same-height-row Finish -->           
       </div><!-- container Finish -->       
   </div><!-- #advantages Finish -->   
   <div id="hot"><!-- #hot Begin -->       
       <div class="box"><!-- box Begin -->           
           <div class="container"><!-- container Begin -->               
               <div class="col-md-12"><!-- col-md-12 Begin -->                   
                   <h2>
                       Sản phẩm nổi bật
                   </h2>                   
               </div><!-- col-md-12 Finish -->               
           </div><!-- container Finish -->           
       </div><!-- box Finish -->       
   </div><!-- #hot Finish -->  
  <div id="content" class="container"><!-- container Begin -->       
       <div class="row"><!-- row Begin -->         
          <%Response.Write(show);
            show = "";
          %>
       </div><!-- row Finish -->       
   </div><!-- container Finish -->
    

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
