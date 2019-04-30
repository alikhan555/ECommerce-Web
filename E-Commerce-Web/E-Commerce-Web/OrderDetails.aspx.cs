using E_Commerce_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Commerce_Web
{
    public partial class OrderDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblTableHeader.Text = "Order Detail";
        }

        public void FillOrderData()
        {
            if(txtOrderID.Text != "")
            {
                string qry = "SELECT OD.ProductID, ProductName, ProdudctQuentity AS 'Product Quentity' , UnitPrice , (UnitPrice * ProdudctQuentity) AS 'Total Price' "+
                             "FROM OrderDetail OD "+
                             "JOIN Products P ON OD.ProductID = P.ProductID "+
                             "WHERE OrderID = '"+txtOrderID.Text+"' ";

                grideView.DataSource = DBClient.GetDataTable(qry);
                grideView.DataBind();
            }
        }

        protected void txtOrderID_TextChanged(object sender, EventArgs e)
        {
            FillOrderData();
        }
    }
}