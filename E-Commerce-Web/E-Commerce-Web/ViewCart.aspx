<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ViewCart.aspx.cs" Inherits="E_Commerce_Web.ViewCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            
            <div class="container" style="padding:80px">
            <div class="col-lg-7" >
                <h1 >Cart Products</h1>
    <table class="table table-striped">
  <thead>
    <tr>
      <th scope="col">#</th>
      <th scope="col">Product ID</th>
      <th scope="col">Product Name</th>
      <th scope="col">Unit Price</th>
      <th scope="col">Quentity</th>
    </tr>
  </thead>
  <tbody>

      <%
          int Sno = 0;
          foreach (var product in cart)
          {
              Sno++;
              %>

            <tr>
                <th scope="row"><%=Sno%></th>
                <td><%=product.ProductID%></td>
                <td><%=product.ProductName%></td>
                <td>Rs <%=product.ProductPrice%></td>
                <td><%=product.Quentity%></td>
            </tr>
    
      <%
          }
          %>


  </tbody>
</table>

                <div>
                    <h5> <asp:Label ID="lblMessage" style="color:MediumVioletRed;" runat="server"> </asp:Label></h5>
                    <asp:Button ID="btnCheckout" Class="btn btn-success"  runat="server" Text="Checkout" OnClick="btnCheckout_Click" />
                </div>



            </div>
                </div>
                 



</asp:Content>
