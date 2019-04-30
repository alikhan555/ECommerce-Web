using E_Commerce_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Commerce_Web.Reports
{
    public partial class FeaturedProducts : System.Web.UI.Page
    {
        string qry;

        protected void Page_Load(object sender, EventArgs e)
        {
            FillFeaturedProducts();
        }

        public void FillFeaturedProducts()
        {
            lblTableHeader.Text = "Featured Products";
            dataTable.DataSource = DBClient.GetFeaturedProductsTable();
            dataTable.DataBind();
        }
    }
}