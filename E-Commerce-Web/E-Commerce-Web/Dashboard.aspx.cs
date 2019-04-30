using E_Commerce_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Commerce_Web
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CountRecoreds();
        }

        public void CountRecoreds()
        {
            lblTotalCustomers.Text = DBClient.CountRecords("Customer").ToString() + " Customers!";
            lblTotalOrders.Text = DBClient.CountRecords("Order").ToString() + " Orders!";
            lblTotalProducts.Text = DBClient.CountRecords("Products").ToString() + " Products!";
        }
    }
}