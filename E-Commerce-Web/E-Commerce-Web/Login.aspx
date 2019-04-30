<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="E_Commerce_Web.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="account">
	<div class="container">
		<h1>Login</h1>
		<div class="account_grid">
			   <div class="col-md-6 login-right">

					<span>Email Address</span>
					<input id="txtEmail" type="text" runat="server">
				
					<span>Password</span>
					<input id="txtPass" type="text" runat="server">
                    <h5><asp:Label ID="lblMessage" ForeColor="MediumVioletRed" runat="server"></asp:Label></h5>
					<div class="word-in">
                        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
				  	</div>
			   </div>	
			    <div class="col-md-6 login-left">
			  	 <h4>NEW CUSTOMERS</h4>
				 <p>By creating an account with our store, you will be able to move through the checkout process faster, store multiple shipping addresses, view and track your orders in your account and more.</p>
				 <a class="acount-btn" href="register.aspx">Create an Account</a>
			   </div>
			   <div class="clearfix"> </div>
			 </div>
	</div>
</div>
</asp:Content>
