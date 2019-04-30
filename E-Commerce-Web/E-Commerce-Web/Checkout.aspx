<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="E_Commerce_Web.Checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
	<div class="register">
		<h1>Checkout</h1>
		  	   

				 <div class="col-md-8 register-top-grid">
					
					<div class="mation">
                        <span>Customer ID</span>
                        <input type="text" id="txtCustomerID" readonly runat="server">

						<span>Reciever Name</span>
                        <input type="text" maxlength="50" id="txtRecieverName" runat="server">

                        <span>Order Address</span>
                        <input type="text" id="txtOrderAddress" runat="server">

						<span>Phone</span>
                        <input type="text" maxlength="11" id="txtPhone" runat="server">
                        
					</div>
					 <div class="clearfix"> </div>
					   
					 </div>
					 <div class="clearfix"> </div>
				
                <div>

                </div>
                    <h5> <asp:Label ID="lblMessage" style="color:MediumVioletRed;" runat="server"> </asp:Label></h5>
				<div class="register-but">
                    <asp:Button ID="btnCheckout" runat="server" class="btn btn-primary"  Text="Checkout" OnClick="btnCheckout_Click" />
				</div>
		   </div>
</div>
</asp:Content>
