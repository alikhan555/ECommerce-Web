using E_Commerce_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Commerce_Web
{
    public partial class ViewDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillGridView();
        }

        public void FillGridView()
        {
            if (Request.QueryString.AllKeys.Contains("View"))
            {
                lblTableHeader.Text = Request.QueryString["View"].ToString();

                string qry = "";

                if (Request.QueryString["View"] == "Product")
                {
                    qry = "SELECT ProductID AS 'ID',ProductName AS 'Name',CatagoryName AS 'Catagory',ProductPrice AS 'Price', ProductStock AS 'Stock', NoOfSold AS 'Sold'" +
                            "FROM Products P" +
                            "INNER JOIN Catagory C ON ProductCatagoryID = CatagoryID;";
                }
                else if (Request.QueryString["View"] == "Order")
                {
                    qry = "SELECT O.OrderID AS 'Order ID', email as 'Email',RecieverName AS 'Reciever Name', ReceiverAddress AS 'Receiver Address', O.Phone AS 'Receiver Phone', O.TotalPayment as 'Payment (Rs)', dateOrdered as 'Date of Order' " +
                            "FROM [order] O " +
                            "JOIN Customer C ON O.CustomerID = C.cid";
                }
                else if (Request.QueryString["View"] == "Customer")
                {
                    qry = "SELECT cid AS 'ID' , [name], email AS 'Email', phone AS 'Phone' FROM Customer";
                }

                DBClient.GetFullData(qry, dataTable);
            }
        }

    }
}