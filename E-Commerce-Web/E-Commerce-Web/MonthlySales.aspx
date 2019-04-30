<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel.Master" AutoEventWireup="true" CodeBehind="MonthlySales.aspx.cs" Inherits="E_Commerce_Web.Reports.MonthlySales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Monthly Sales</title>
</asp:Content>
    
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container-fluid">
        
        <div class="card mb-3">
          <div class="card-header">
            <i class="fas fa-table"></i>
              <asp:Label ID="lblTableHeader" runat="server" Text="Monthly Sales"></asp:Label></div>
          <div class="card-body">
            <div class="table-responsive">

                

              <div id="dataTable_wrapper" class="dataTables_wrapper dt-bootstrap4">
                  
                  
                  <div class="row">
                      <div class="col-sm-6">
                          <span>Year</span>
                          <asp:DropDownList ID="dropYear" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="dropMonthYear_SelectedIndexChanged"></asp:DropDownList>
                      </div>
                      <div class="col-sm-6">
                          <span>Month</span>
                          <asp:DropDownList ID="dropMonth" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="dropMonthYear_SelectedIndexChanged">
                              <asp:ListItem Value="%%">Whole Year</asp:ListItem>
                              <asp:ListItem Value="1">January</asp:ListItem>
                              <asp:ListItem Value="2">February</asp:ListItem>
                              <asp:ListItem Value="3">March</asp:ListItem>
                              <asp:ListItem Value="4">April</asp:ListItem>
                              <asp:ListItem Value="5">May</asp:ListItem>
                              <asp:ListItem Value="6">June</asp:ListItem>
                              <asp:ListItem Value="7">July</asp:ListItem>
                              <asp:ListItem Value="8">August</asp:ListItem>
                              <asp:ListItem Value="9">September</asp:ListItem>
                              <asp:ListItem Value="10">October</asp:ListItem>
                              <asp:ListItem Value="11">November</asp:ListItem>
                              <asp:ListItem Value="12">December</asp:ListItem>
                          </asp:DropDownList>
                      </div>
                  </div>
                  




                  
                  <div class="row">
                      <div class="col-sm-12">                      
                            <asp:GridView ID="grideView" class="table table-bordered dataTable" runat="server"></asp:GridView>
                      </div>
                  </div>
              </div>





            </div>
          </div>
          <div class="card-footer small text-muted">Updated yesterday at 11:59 PM</div>
        </div>

</asp:Content>
