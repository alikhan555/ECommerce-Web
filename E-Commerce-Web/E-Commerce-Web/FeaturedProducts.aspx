<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel.Master" AutoEventWireup="true" CodeBehind="FeaturedProducts.aspx.cs" Inherits="E_Commerce_Web.Reports.FeaturedProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Featured Products</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container-fluid">
        
        <div class="card mb-3">
          <div class="card-header">
            <i class="fas fa-table"></i>
              <asp:Label ID="lblTableHeader" runat="server" Text="Label"></asp:Label></div>
          <div class="card-body">
            <div class="table-responsive">
              <div id="dataTable_wrapper" class="dataTables_wrapper dt-bootstrap4">
                  <div class="row"><div class="col-sm-12">
                      


                      <asp:GridView ID="dataTable" class="table table-bordered dataTable" runat="server"></asp:GridView>
                      
                            
                            </div>
                     </div>
                </div>
            </div>
          </div>
          <div class="card-footer small text-muted">Updated yesterday at 11:59 PM</div>
        </div>

      </div>



</asp:Content>
