<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="E_Commerce_Web.AddProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Add New Product</title>
<link href="css/bootstrap.css" rel="stylesheet" type="text/css" media="all" />
<!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
<script src="js/jquery.min.js"></script>
<!-- Custom Theme files -->
<!--theme-style-->
<link href="css/style.css" rel="stylesheet" type="text/css" media="all" />	
<!--//theme-style-->
<meta name="viewport" content="width=device-width, initial-scale=1">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="keywords" content="Fashion Mania Responsive web template, Bootstrap Web Templates, Flat Web Templates, Andriod Compatible web template, 
Smartphone Compatible web template, free webdesigns for Nokia, Samsung, LG, SonyErricsson, Motorola web design" />
<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
<!-- start menu -->
<link href="css/memenu.css" rel="stylesheet" type="text/css" media="all" />
<script type="text/javascript" src="js/memenu.js"></script>
<script>$(document).ready(function(){$(".memenu").memenu();});</script>
<script src="js/simpleCart.min.js"> </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>

    <div class="container">
	<div class="register">
		<h1>Add New Product</h1>
		  	   
				 <div class="col-md-6 register-top-grid">
					
					<div class="mation">
						<span>Name</span>
                        <input id="txtProductName" type="text" maxlength="50" runat="server">
					
                        <span>Stock</span>
                        <input id="txtProductStock" type="text" maxlength="50" runat="server">

						<span>Image</span>
                        <asp:FileUpload ID="fileProductImage" class="form-control" runat="server" />
					</div>
					 <div class="clearfix"> </div>
					   
					 </div>
				     <div class=" col-md-6 register-bottom-grid">
						   
							<div class="mation">
								<span>Price</span>
                                <input id="txtProductPrice" type="text" runat="server">

								<span>Catagory</span>
                                <asp:DropDownList ID="dropCatagory" class="form-control" runat="server">
                                </asp:DropDownList>
                                                                
							</div>
					 </div>
					 <div class="clearfix"> </div>
				
                <div>

                </div>
                    <h5><span id="ContentPlaceHolder1_lblMessage" style="color:MediumVioletRed;"></span></h5>
        <asp:Label ID="lblMessage" runat="server" ForeColor="PaleVioletRed"></asp:Label>
				<div class="register-but">                    
                    <asp:Button ID="btnAdd" runat="server" class="btn btn-primary" Text="Add Product" OnClick="btnAdd_Click" />
                    &nbsp;</div>
		   </div>
</div>



            

        </div>
</asp:Content>
