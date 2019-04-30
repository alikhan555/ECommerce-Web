<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="E_Commerce_Web.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
	<div class="register">
		<h1>Register</h1>
		  	   
				 <div class="col-md-6 register-top-grid">
					
					<div class="mation">
						<span>Full Name</span>
                        <asp:TextBox ID="txtFullName" runat="server" MaxLength="50"></asp:TextBox>
					
                        <span>Email Address</span>
                        <asp:TextBox ID="txtEmail" runat="server" MaxLength="50"></asp:TextBox>

						<span>Phone</span>
                        <asp:TextBox ID="txtPhone" runat="server" MaxLength="11"></asp:TextBox>
					</div>
					 <div class="clearfix"> </div>
					   
					 </div>
				     <div class=" col-md-6 register-bottom-grid">
						   
							<div class="mation">
								<span>Password</span>
                                <asp:TextBox ID="txtPass" runat="server"></asp:TextBox>

								<span>Confirm Password</span>
                                <asp:TextBox ID="txtConfPass" runat="server"></asp:TextBox>

                                <span>Address</span>
                                <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                                
							</div>
					 </div>
					 <div class="clearfix"> </div>
				
                <div>

                </div>
                    <h5><asp:Label ID="lblMessage" ForeColor="MediumVioletRed" runat="server"></asp:Label></h5>
				<div class="register-but" >
                    <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Submit" OnClick="Button1_Click" />
				</div>
		   </div>
</div>

</asp:Content>
