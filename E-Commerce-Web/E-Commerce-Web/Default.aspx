<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="E_Commerce_Web.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
	
    <div class="header-top">
		<div class="container">
		    <div class="col-sm-3 world">
					<h3><asp:Label ID="lblUserName" runat="server"></asp:Label></h3>
				</div>

            <div class="col-sm-4" >                    
                        <asp:TextBox ID="txtSearch" class="form-control" runat="server"></asp:TextBox>   
				</div>
            <div class="col-sm-1" >
                        <asp:Button ID="btnSearch" class="btn btn-default" runat="server" Text="Search" OnClick="btnSearch_Click" />
                </div>
		
			<div class="col-sm-4 header-left">
					<p class="log"><asp:HyperLink ID="HyperLogin" Text="Login" runat="server" NavigateUrl="~/Login.aspx"></asp:HyperLink>
						<span>
                            <asp:Button ID="btnLogout" runat="server" class="btn btn-danger"  Visible="false" Text="Logout" OnClick="btnLogout_Click" />
                            <asp:Label ID="lblOR" runat="server" Text="or"></asp:Label></span><asp:HyperLink ID="hyperSignUp" Text="SignUp" runat="server" NavigateUrl="~/Register.aspx"></asp:HyperLink></p>
					<div class="cart box_1">
						
                        


                        <a href="ViewCart.aspx">
                            <h3> <div class="total">
							<img src="images/cart.png" alt=""/></h3>
						</a>
						<p><asp:LinkButton ID="btnEmptyCart" runat="server" OnClick="btnEmptyCart_Click">Empty Cart</asp:LinkButton></p>




					</div>
					<div class="clearfix"> </div>
			</div>
				<div class="clearfix"> </div>
		</div>
		</div>

    <div class="banner">
	<div class="col-sm-3 banner-mat">
		<img class="img-responsive" src="images/ba1.jpg" alt="">
	</div>
	<div class="col-sm-6 matter-banner">
	 	<div class="slider">
	    	<div class="callbacks_container">
	      		<ul class="rslides callbacks callbacks1" id="slider">
	        		<li id="callbacks1_s0" class="callbacks1_on" style="display: block; float: left; position: relative; opacity: 1; z-index: 2; transition: opacity 500ms ease-in-out 0s;">
	          			<img src="images/1.jpg" alt="">
	       			 </li>
			 		 <li id="callbacks1_s1" class="" style="float: none; position: absolute; opacity: 0; z-index: 1; display: list-item; transition: opacity 500ms ease-in-out 0s;">
	          			<img src="images/2.jpg" alt="">   
	       			 </li>
					 <li id="callbacks1_s2" class="" style="float: none; position: absolute; opacity: 0; z-index: 1; display: list-item; transition: opacity 500ms ease-in-out 0s;">
	          			<img src="images/1.jpg" alt="">
	        		</li>	
	      		</ul><ul class="callbacks_tabs callbacks1_tabs"><li class="callbacks1_s1 callbacks_here"><a href="#" class="callbacks1_s1">1</a></li><li class="callbacks1_s2"><a href="#" class="callbacks1_s2">2</a></li><li class="callbacks1_s3"><a href="#" class="callbacks1_s3">3</a></li></ul>
	 	 	</div>
		</div>
	</div>
	<div class="col-sm-3 banner-mat">
		<img class="img-responsive" src="images/ba.jpg" alt="">
	</div>
	<div class="clearfix"> </div>
</div>

    <div class="content">
	<div class="container">
		<div class="content-top">
			<h1>
                <asp:Label ID="lblProductHeadder" runat="server"></asp:Label></h1>
			<div class="content-top1">




                <%
    foreach (var product in products)
    {
                        %>     
				<div class="col-md-3 col-md2" style="padding: 15px">
					<div class="col-md1 simpleCart_shelfItem" style="width:256px; height:440px;">
						<a>
                            <asp:Image ID="Image1" runat="server" />
							<img class="img-responsive" style="width:100%; height:270px;" src="<%=product.ProductImagePath%>" alt="<%=product.ProductName%>" />
						</a>
						<h3><a style="font-family:'Microsoft Sans Serif'"><%=product.ProductName%></a></h3>
						<div class="price">
								<h5 class="item_price">Rs <%=product.ProductPrice%></h5>
								<a href="?ProductID=<%=product.ProductID%>&ProductName=<%=product.ProductName%>&ProductPrice=<%=product.ProductPrice%>&action=add" class="item_add">Add To Cart</a>
								<div class="clearfix"> </div>
						</div>
					</div>
				</div>
                <% 
    } %>
                

                               



			<div class="clearfix"> </div>
			</div>	
			
		</div>
	</div>
</div>

</asp:Content>
