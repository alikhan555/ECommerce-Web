using E_Commerce_Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Commerce_Web.Reports
{
    public partial class MonthlySales : System.Web.UI.Page
    {
        string qry;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillMonthlyDropDown();
                FillDataGrid();
            }
        }

        public void FillMonthlyDropDown()
        {
            qry = "SELECT DISTINCT CAST(YEAR(DateOrdered) AS varchar) AS 'Year' FROM [Order] ORDER BY CAST(YEAR(DateOrdered) AS varchar) DESC";

            DataTable dataTable = DBClient.GetDataTable(qry);

            DataRow dr = dataTable.NewRow();
            dr["Year"] = "%%";
            dataTable.Rows.Add(dr);


            dropYear.DataSource = dataTable;
            dropYear.DataValueField = "Year";
            dropYear.DataBind();
        }

        protected void dropMonthYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDataGrid();
        }

        public void FillDataGrid()
        {
            qry = "EXEC SPGenerateSalesReport '" + dropMonth.SelectedValue + "', '" + dropYear.SelectedValue + "'";
            DataTable dataTable = DBClient.GetDataTable(qry);

            DataRow dr1 = dataTable.NewRow();
            DataRow dr2 = dataTable.NewRow();
           
            float totalQty = 0;
            float totalPrice = 0;
            
            foreach (DataRow dr in dataTable.Rows)
            {
                totalQty += float.Parse(dr["Sold Qty"].ToString());
                totalPrice += float.Parse(dr["Total Price"].ToString());
            }

            dataTable.Rows.Add(dr1);
            dr2["Product Name"] = "TOTAL";
            dr2["Sold Qty"] = totalQty;
            dr2["Total Price"] = totalPrice;
            dataTable.Rows.Add(dr2);

            grideView.DataSource = dataTable;
            grideView.DataBind();
        }
    }
}