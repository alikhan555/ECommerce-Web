<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel.Master" AutoEventWireup="true" CodeBehind="UpdateProduct.aspx.cs" Inherits="E_Commerce_Web.UpdateProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <title>Update Product</title>
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
		<h1>Update Product</h1>

            <div class="col-md-12 register-top-grid" >

                <asp:Image ID="imgProductImg" style="width:300px; height:370px;" class="rounded mx-auto d-block" runat="server" />

            </div>

        <div class="col-md-12 register-top-grid"> 
            <div class="col-md-4 register-top-grid">
                <div class="mation">
                <span>Priduct ID</span>
                <asp:TextBox ID="txtProductID" MaxLength="50" runat="server" AutoPostBack="True" OnTextChanged="txtProductID_TextChanged"></asp:TextBox>
                     <asp:Label ID="lblIDMessage" ForeColor="MediumVioletRed" runat="server"></asp:Label>
                </div>
            </div>
        </div>

           

				 <div class="col-md-6 register-top-grid">
					
					<div class="mation">
						<span>Name</span>
                        <asp:TextBox ID="txtProductName" maxlength="50" runat="server"></asp:TextBox>

                        <span>Stock</span>
                        <asp:TextBox ID="txtProductStock" maxlength="50" runat="server"></asp:TextBox>

					</div>
					 <div class="clearfix"> </div>
					   
					 </div>
				     <div class=" col-md-6 register-bottom-grid">
						   
							<div class="mation">
								<span>Price</span>
                                <asp:TextBox ID="txtProductPrice" runat="server"></asp:TextBox>

								<span>Catagory</span>
                                <asp:DropDownList ID="dropCatagory" class="form-control" runat="server">
                                </asp:DropDownList>
                                                                
							</div>
					 </div>
					 <div class="clearfix"> </div>
	<h5><span id="ContentPlaceHolder1_lblMessage" style="color:MediumVioletRed;"></span></h5>
                        <asp:Label ID="lblMessage" runat="server" ForeColor="PaleVioletRed"></asp:Label>
				        <div class="register-but">                    
                    <asp:Button ID="btnUpdate" runat="server" class="btn btn-primary" Text="Update Product" OnClick="btnUpdate_Click" />
                    &nbsp;</div>
		        </div>			
    </div>
                <div>

                </div>
                    
</div>
        </div>

</asp:Content>
